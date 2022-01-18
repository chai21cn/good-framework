using GoodFramework.Abp.OssManagement.Localization;
using Volo.Abp.Application.Services;

namespace GoodFramework.Abp.OssManagement
{
    public abstract class OssManagementApplicationServiceBase : ApplicationService
    {
        protected OssManagementApplicationServiceBase()
        {
            LocalizationResource = typeof(AbpOssManagementResource);
            ObjectMapperContext = typeof(AbpOssManagementApplicationModule);
        }
    }
}
