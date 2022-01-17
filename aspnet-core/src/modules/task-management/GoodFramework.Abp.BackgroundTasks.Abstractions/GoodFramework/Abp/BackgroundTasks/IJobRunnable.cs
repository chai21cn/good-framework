using System.Threading.Tasks;

namespace GoodFramework.Abp.BackgroundTasks;

/// <summary>
/// 任务类需要实现此接口
/// </summary>
public interface IJobRunnable
{
    Task ExecuteAsync(JobRunnableContext context);
}
