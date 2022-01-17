using Volo.Abp.Modularity;

namespace GoodFramework.Abp.IdentityServer
{
    [DependsOn(typeof(Volo.Abp.IdentityServer.AbpIdentityServerDomainModule))]
    public class AbpIdentityServerDomainModule : AbpModule
    {
    }
}
