using GoodFramework.Abp.BlobStoring.Tencent;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace GoodFramework.Abp.OssManagement.Tencent
{
    [DependsOn(
        typeof(AbpBlobStoringTencentCloudModule),
        typeof(AbpOssManagementDomainModule))]
    public class AbpOssManagementTencentModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddTransient<IOssContainerFactory, TencentOssContainerFactory>();
        }
    }
}
