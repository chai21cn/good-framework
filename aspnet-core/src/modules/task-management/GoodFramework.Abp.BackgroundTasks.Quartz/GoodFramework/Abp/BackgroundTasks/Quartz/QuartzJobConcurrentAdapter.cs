using System;
using Quartz;

namespace GoodFramework.Abp.BackgroundTasks.Quartz;

[DisallowConcurrentExecution]
public class QuartzJobConcurrentAdapter<TJobRunnable> : QuartzJobSimpleAdapter<TJobRunnable>
    where TJobRunnable : IJobRunnable
{
    public QuartzJobConcurrentAdapter(IServiceProvider serviceProvider)
        : base(serviceProvider)
    {
    }
}
