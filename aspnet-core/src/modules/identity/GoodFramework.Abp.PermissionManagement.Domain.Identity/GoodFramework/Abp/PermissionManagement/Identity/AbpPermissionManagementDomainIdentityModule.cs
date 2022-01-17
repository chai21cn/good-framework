using Volo.Abp.Modularity;

namespace GoodFramework.Abp.PermissionManagement.Identity
{
    [DependsOn(
        typeof(AbpPermissionManagementDomainModule),
        typeof(Volo.Abp.PermissionManagement.Identity.AbpPermissionManagementDomainIdentityModule)
        )]
    public class AbpPermissionManagementDomainIdentityModule : AbpModule
    {

    }
}
