using Volo.Abp.Application.Services;
using Volo.Abp.TenantManagement.Localization;

namespace GoodFramework.Abp.TenantManagement
{
    public abstract class TenantManagementAppServiceBase : ApplicationService
    {
        protected TenantManagementAppServiceBase()
        {
            ObjectMapperContext = typeof(AbpTenantManagementApplicationModule);
            LocalizationResource = typeof(AbpTenantManagementResource);
        }
    }
}
