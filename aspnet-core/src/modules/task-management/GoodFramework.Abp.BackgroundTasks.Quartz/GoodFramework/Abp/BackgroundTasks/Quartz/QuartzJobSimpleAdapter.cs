using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace GoodFramework.Abp.BackgroundTasks.Quartz;

public class QuartzJobSimpleAdapter<TJobRunnable> : IJob
    where TJobRunnable : IJobRunnable
{
    protected IServiceProvider ServiceProvider { get; }

    public QuartzJobSimpleAdapter(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    public async virtual Task Execute(IJobExecutionContext context)
    {
        using var scope = ServiceProvider.CreateScope();
        var jobExecuter = scope.ServiceProvider.GetRequiredService<IJobRunnableExecuter>();

        var jobContext = new JobRunnableContext(
            typeof(TJobRunnable),
            scope.ServiceProvider,
            context.MergedJobDataMap.ToImmutableDictionary());

        await jobExecuter.ExecuteAsync(jobContext);

        context.Result = jobContext.Result;
    }
}
