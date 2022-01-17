using Volo.Abp.Modularity;

namespace GoodFramework.Abp.IdentityServer.EntityFrameworkCore
{
    [DependsOn(typeof(GoodFramework.Abp.IdentityServer.AbpIdentityServerDomainModule))]
    [DependsOn(typeof(Volo.Abp.IdentityServer.EntityFrameworkCore.AbpIdentityServerEntityFrameworkCoreModule))]
    public class AbpIdentityServerEntityFrameworkCoreModule : AbpModule
    {
    }
}
