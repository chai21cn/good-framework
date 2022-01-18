using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace GoodFramework.Abp.OssManagement
{
    [DependsOn(
        typeof(AbpOssManagementDomainSharedModule),
        typeof(AbpDddApplicationContractsModule))]
    public class AbpOssManagementApplicationContractsModule : AbpModule
    {
    }
}
