using GoodFramework.Abp.Identity;
using GoodFramework.Abp.WeChat.MiniProgram;
using Volo.Abp.Modularity;

namespace GoodFramework.Abp.Account
{
    [DependsOn(
        typeof(Volo.Abp.Account.AbpAccountApplicationModule),
        typeof(AbpAccountApplicationContractsModule),
        typeof(AbpIdentityDomainModule),
        typeof(AbpWeChatMiniProgramModule))]
    public class AbpAccountApplicationModule : AbpModule
    {

    }
}
