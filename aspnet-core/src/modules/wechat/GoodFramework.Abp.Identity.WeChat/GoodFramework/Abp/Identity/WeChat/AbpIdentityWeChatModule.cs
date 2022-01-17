using GoodFramework.Abp.WeChat;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace GoodFramework.Abp.Identity.WeChat
{
    [DependsOn(
        typeof(AbpWeChatModule),
        typeof(AbpIdentityDomainModule))]
    public class AbpIdentityWeChatModule : AbpModule
    {
    }
}
