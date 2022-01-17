using GoodFramework.Abp.BackgroundTasks;
using GoodFramework.Abp.TaskManagement.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;

namespace GoodFramework.Abp.TaskManagement;

[Authorize(TaskManagementPermissions.BackgroundJobs.Default)]
public class BackgroundJobInfoAppService : TaskManagementApplicationService, IBackgroundJobInfoAppService
{
    protected BackgroundJobManager BackgroundJobManager { get; }
    protected IBackgroundJobInfoRepository BackgroundJobInfoRepository { get; }

    public BackgroundJobInfoAppService(
        BackgroundJobManager backgroundJobManager,
        IBackgroundJobInfoRepository backgroundJobInfoRepository)
    {
        BackgroundJobManager = backgroundJobManager;
        BackgroundJobInfoRepository = backgroundJobInfoRepository;
    }

    [Authorize(TaskManagementPermissions.BackgroundJobs.Create)]
    public virtual async Task<BackgroundJobInfoDto> CreateAsync(BackgroundJobInfoCreateDto input)
    {
        if (await BackgroundJobInfoRepository.CheckNameAsync(input.Group, input.Name))
        {
            throw new BusinessException(TaskManagementErrorCodes.JobNameAlreadyExists)
                .WithData("Group", input.Group)
                .WithData("Name", input.Name);
        }

        var jobId = GuidGenerator.Create();
        var backgroundJobInfo = new BackgroundJobInfo(
            jobId.ToString(),
            input.Name,
            input.Group,
            input.Type,
            input.Args,
            input.BeginTime,
            input.EndTime,
            input.Priority,
            input.MaxCount,
            input.MaxTryCount,
            CurrentTenant.Id);

        UpdateByInput(backgroundJobInfo, input);

        await BackgroundJobInfoRepository.InsertAsync(backgroundJobInfo, autoSave: true);

        if (backgroundJobInfo.IsEnabled && backgroundJobInfo.JobType == JobType.Period)
        {
            await BackgroundJobManager.QueueAsync(backgroundJobInfo);
        }

        return ObjectMapper.Map<BackgroundJobInfo, BackgroundJobInfoDto>(backgroundJobInfo);
    }

    [Authorize(TaskManagementPermissions.BackgroundJobs.Delete)]
    public virtual async Task DeleteAsync(string id)
    {
        var backgroundJobInfo = await BackgroundJobInfoRepository.GetAsync(id);

        await BackgroundJobManager.DeleteAsync(backgroundJobInfo);
    }

    public virtual async Task<BackgroundJobInfoDto> GetAsync(string id)
    {
        var backgroundJobInfo = await BackgroundJobInfoRepository.GetAsync(id);

        return ObjectMapper.Map<BackgroundJobInfo, BackgroundJobInfoDto>(backgroundJobInfo);
    }

    public virtual async Task<PagedResultDto<BackgroundJobInfoDto>> GetListAsync(BackgroundJobInfoGetListInput input)
    {
        var filter = new BackgroundJobInfoFilter
        {
            IsAbandoned = input.IsAbandoned,
            JobType = input.JobType,
            BeginCreationTime = input.BeginCreationTime,
            EndCreationTime = input.EndCreationTime,
            BeginLastRunTime = input.BeginLastRunTime,
            EndLastRunTime = input.EndLastRunTime,
            BeginTime = input.BeginTime,
            EndTime = input.EndTime,
            Filter = input.Filter,
            Group = input.Group,
            Name = input.Name,
            Priority = input.Priority,
            Status = input.Status,
            Type = input.Type
        };
        var totalCount = await BackgroundJobInfoRepository.GetCountAsync(filter);
        var backgroundJobInfos = await BackgroundJobInfoRepository.GetListAsync(
            filter, input.Sorting, input.MaxResultCount, input.SkipCount);

        return new PagedResultDto<BackgroundJobInfoDto>(totalCount,
            ObjectMapper.Map<List<BackgroundJobInfo>, List<BackgroundJobInfoDto>>(backgroundJobInfos));
    }

    [Authorize(TaskManagementPermissions.BackgroundJobs.Pause)]
    public virtual async Task PauseAsync(string id)
    {
        var backgroundJobInfo = await BackgroundJobInfoRepository.GetAsync(id);

        await BackgroundJobManager.PauseAsync(backgroundJobInfo);
    }

    [Authorize(TaskManagementPermissions.BackgroundJobs.Resume)]
    public virtual async Task ResumeAsync(string id)
    {
        var backgroundJobInfo = await BackgroundJobInfoRepository.GetAsync(id);

        await BackgroundJobManager.ResumeAsync(backgroundJobInfo);
    }

    [Authorize(TaskManagementPermissions.BackgroundJobs.Trigger)]
    public virtual async Task TriggerAsync(string id)
    {
        var backgroundJobInfo = await BackgroundJobInfoRepository.GetAsync(id);

        await BackgroundJobManager.TriggerAsync(backgroundJobInfo);
    }

    [Authorize(TaskManagementPermissions.BackgroundJobs.Stop)]
    public virtual async Task StopAsync(string id)
    {
        var backgroundJobInfo = await BackgroundJobInfoRepository.GetAsync(id);

        await BackgroundJobManager.StopAsync(backgroundJobInfo);
    }

    [Authorize(TaskManagementPermissions.BackgroundJobs.Start)]
    public virtual async Task StartAsync(string id)
    {
        var backgroundJobInfo = await BackgroundJobInfoRepository.GetAsync(id);

        await BackgroundJobManager.QueueAsync(backgroundJobInfo);
    }

    [Authorize(TaskManagementPermissions.BackgroundJobs.Update)]
    public virtual async Task<BackgroundJobInfoDto> UpdateAsync(string id, BackgroundJobInfoUpdateDto input)
    {
        var backgroundJobInfo = await BackgroundJobInfoRepository.GetAsync(id);

        var resetJob = backgroundJobInfo.JobType == input.JobType;

        UpdateByInput(backgroundJobInfo, input);

        backgroundJobInfo.SetConcurrencyStampIfNotNull(input.ConcurrencyStamp);

        await BackgroundJobManager.UpdateAsync(backgroundJobInfo, resetJob);

        return ObjectMapper.Map<BackgroundJobInfo, BackgroundJobInfoDto>(backgroundJobInfo);
    }

    [Authorize(TaskManagementPermissions.BackgroundJobs.Delete)]
    public virtual async Task BulkDeleteAsync(BackgroundJobInfoBatchInput input)
    {
        if (!input.JobIds.Any())
        {
            return;
        }
        var jobs = await GetListAsync(input);

        await BackgroundJobManager.BulkDeleteAsync(jobs);
    }

    [Authorize(TaskManagementPermissions.BackgroundJobs.Stop)]
    public virtual async Task BulkStopAsync(BackgroundJobInfoBatchInput input)
    {
        if (!input.JobIds.Any())
        {
            return;
        }
        var jobs = await GetListAsync(input);

        await BackgroundJobManager.BulkStopAsync(jobs);
    }

    [Authorize(TaskManagementPermissions.BackgroundJobs.Start)]
    public virtual async Task BulkStartAsync(BackgroundJobInfoBatchInput input)
    {
        if (!input.JobIds.Any())
        {
            return;
        }
        var jobs = await GetListAsync(input);

        await BackgroundJobManager.BulkQueueAsync(jobs);
    }

    [Authorize(TaskManagementPermissions.BackgroundJobs.Trigger)]
    public virtual async Task BulkTriggerAsync(BackgroundJobInfoBatchInput input)
    {
        if (!input.JobIds.Any())
        {
            return;
        }
        var jobs = await GetListAsync(input);

        await BackgroundJobManager.BulkTriggerAsync(jobs);
    }

    [Authorize(TaskManagementPermissions.BackgroundJobs.Resume)]
    public virtual async Task BulkResumeAsync(BackgroundJobInfoBatchInput input)
    {
        if (!input.JobIds.Any())
        {
            return;
        }
        var jobs = await GetListAsync(input);

        await BackgroundJobManager.BulkResumeAsync(jobs);
    }

    [Authorize(TaskManagementPermissions.BackgroundJobs.Pause)]
    public virtual async Task BulkPauseAsync(BackgroundJobInfoBatchInput input)
    {
        if (!input.JobIds.Any())
        {
            return;
        }
        var jobs = await GetListAsync(input);

        await BackgroundJobManager.BulkPauseAsync(jobs);
    }

    protected virtual async Task<IEnumerable<BackgroundJobInfo>> GetListAsync(BackgroundJobInfoBatchInput input)
    {
        var quaryble = await BackgroundJobInfoRepository.GetQueryableAsync();
        quaryble = quaryble.Where(x => input.JobIds.Contains(x.Id));

        return await AsyncExecuter.ToListAsync(quaryble);
    }

    protected virtual void UpdateByInput(BackgroundJobInfo backgroundJobInfo, BackgroundJobInfoCreateOrUpdateDto input)
    {
        backgroundJobInfo.IsEnabled = input.IsEnabled;
        backgroundJobInfo.LockTimeOut = input.LockTimeOut;
        backgroundJobInfo.Description = input.Description;
        backgroundJobInfo.MaxCount = input.MaxCount;
        backgroundJobInfo.MaxTryCount = input.MaxTryCount;
        backgroundJobInfo.Args = input.Args;

        backgroundJobInfo.SetPriority(input.Priority);
        switch (input.JobType)
        {
            case JobType.Once:
                backgroundJobInfo.SetOnceJob(input.Interval);
                break;
            case JobType.Persistent:
                backgroundJobInfo.SetPersistentJob(input.Interval);
                break;
            case JobType.Period:
                backgroundJobInfo.SetPeriodJob(input.Cron);
                break;
        }
    }
}
