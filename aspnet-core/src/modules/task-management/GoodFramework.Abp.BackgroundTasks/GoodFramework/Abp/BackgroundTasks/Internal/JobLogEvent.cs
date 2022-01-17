using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace GoodFramework.Abp.BackgroundTasks.Internal;

/// <summary>
/// 存储任务日志
/// </summary>
/// <remarks>
/// 任务类型标记了<see cref="DisableAuditingAttribute"/> 特性则不会记录日志
/// </remarks>
public class JobLogEvent : JobEventBase<JobLogEvent>, ITransientDependency
{
    protected async override Task OnJobAfterExecutedAsync(JobEventContext context)
    {
        if (context.EventData.Type.IsDefined(typeof(DisableAuditingAttribute), true))
        {
            return;
        }
        var store = context.ServiceProvider.GetRequiredService<IJobStore>();
        var currentTenant = context.ServiceProvider.GetRequiredService<ICurrentTenant>();

        using (currentTenant.Change(context.EventData.TenantId))
        {
            await store.StoreLogAsync(context.EventData);
        }
    }
}
