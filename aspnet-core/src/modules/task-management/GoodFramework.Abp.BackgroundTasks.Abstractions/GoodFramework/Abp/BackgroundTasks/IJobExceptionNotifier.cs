using JetBrains.Annotations;
using System.Threading.Tasks;

namespace GoodFramework.Abp.BackgroundTasks;

public interface IJobExceptionNotifier
{
    Task NotifyAsync([NotNull] JobExceptionNotificationContext context);
}
