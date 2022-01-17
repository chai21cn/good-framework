using Volo.Abp.Modularity;

namespace GoodFramework.Abp.PermissionManagement
{
    [DependsOn(
        typeof(Volo.Abp.PermissionManagement.AbpPermissionManagementDomainModule))]
    public class AbpPermissionManagementDomainModule : AbpModule
    {

    }
}
