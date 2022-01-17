using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Quartz;
using System;
using System.Collections.Generic;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Timing;

namespace GoodFramework.Abp.BackgroundTasks.Quartz;

public class QuartzJobExecutorProvider : IQuartzJobExecutorProvider, ISingletonDependency
{
    public ILogger<QuartzJobExecutorProvider> Logger { protected get; set; }

    protected IClock Clock { get; }
    protected AbpBackgroundTasksOptions Options { get; }
    protected IQuartzKeyBuilder KeyBuilder { get; }
    public QuartzJobExecutorProvider(
        IClock clock,
        IQuartzKeyBuilder keyBuilder,
        IOptions<AbpBackgroundTasksOptions> options)
    {
        Clock = clock;
        Options = options.Value;
        KeyBuilder = keyBuilder;

        Logger = NullLogger<QuartzJobExecutorProvider>.Instance;
    }

    public IJobDetail CreateJob(JobInfo job)
    {
        var jobType = Options.JobProviders.GetOrDefault(job.Type) ?? Type.GetType(job.Type);
        if (jobType == null)
        {
            Logger.LogWarning($"The task: {job.Group} - {job.Name}: {job.Type} is not registered and cannot create an instance of the performer type.");
            return null;
        }

        var adapterType = typeof(QuartzJobSimpleAdapter<>);

        // 注释, 通过触发器监听锁定
        //if (job.LockTimeOut > 0)
        //{
        //    adapterType = typeof(QuartzJobConcurrentAdapter<>);
        //}

        if (!typeof(IJob).IsAssignableFrom(jobType))
        {
            jobType = adapterType.MakeGenericType(jobType);
        }

        // 改为 JobId作为名称
        var jobBuilder = JobBuilder.Create(jobType)
                .WithIdentity(KeyBuilder.CreateJobKey(job))
                .WithDescription(job.Description);

        jobBuilder.UsingJobData(nameof(JobInfo.Id), job.Id);
        jobBuilder.UsingJobData(nameof(JobInfo.LockTimeOut), job.LockTimeOut);
        jobBuilder.UsingJobData(new JobDataMap(job.Args));
        if (job.TenantId.HasValue)
        {
            jobBuilder.UsingJobData(nameof(JobInfo.TenantId), job.TenantId.ToString());
        }

        return jobBuilder.Build();
    }

    public ITrigger CreateTrigger(JobInfo job)
    {
        var triggerBuilder = TriggerBuilder.Create();

        switch (job.JobType)
        {
            case JobType.Period:
                if (!CronExpression.IsValidExpression(job.Cron))
                {
                    Logger.LogWarning($"The task: {job.Group} - {job.Name} periodic task Cron expression was invalid and the task trigger could not be created.");
                    return null;
                }
                if (job.GetCanBeTriggered() == 0)
                {
                    Logger.LogWarning($"The task: {job.Group} - {job.Name} reached trigger peak and the task trigger could not be created.");
                    return null;
                }
                triggerBuilder
                    .WithIdentity(KeyBuilder.CreateTriggerKey(job))
                    .WithDescription(job.Description)
                    .EndAt(job.EndTime)
                    .ForJob(KeyBuilder.CreateJobKey(job))
                    .WithPriority((int)job.Priority)
                    .WithCronSchedule(job.Cron);
                if (job.BeginTime > Clock.Now)
                {
                    triggerBuilder = triggerBuilder.StartAt(job.BeginTime);
                }
                break;
            case JobType.Once:
            case JobType.Persistent:
            default:
                var maxCount = job.GetCanBeTriggered();
                if (maxCount == 0)
                {
                    Logger.LogWarning($"The task: {job.Group} - {job.Name} reached trigger peak and the task trigger could not be created.");
                    return null;
                }

                // Quartz 需要减一位
                maxCount -= 1;
                if (maxCount < -1)
                {
                    maxCount = -1;
                }

                triggerBuilder
                    .WithIdentity(KeyBuilder.CreateTriggerKey(job))
                    .WithDescription(job.Description)
                    .StartAt(Clock.Now.AddSeconds(job.Interval))
                    .EndAt(job.EndTime)
                    .ForJob(KeyBuilder.CreateJobKey(job))
                    .WithPriority((int)job.Priority)
                    .WithSimpleSchedule(x =>
                        x.WithIntervalInSeconds(job.Interval)
                         .WithRepeatCount(maxCount));
                break;
        }

        return triggerBuilder.Build();
    }
}
