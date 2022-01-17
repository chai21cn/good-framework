using Volo.Abp.Application.Services;
using Volo.Abp.AuditLogging.Localization;

namespace GoodFramework.Abp.Auditing
{
    public abstract class AuditingApplicationServiceBase : ApplicationService
    {
        protected AuditingApplicationServiceBase()
        {
            LocalizationResource = typeof(AuditLoggingResource);
            ObjectMapperContext = typeof(AbpAuditingApplicationModule);
        }
    }
}
