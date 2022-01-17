using System.Threading.Tasks;
using Volo.Abp.Auditing;

namespace GoodFramework.Abp.AuditLogging
{
    public interface IAuditLogInfoToAuditLogConverter
    {
        Task<AuditLog> ConvertAsync(AuditLogInfo auditLogInfo);
    }
}
