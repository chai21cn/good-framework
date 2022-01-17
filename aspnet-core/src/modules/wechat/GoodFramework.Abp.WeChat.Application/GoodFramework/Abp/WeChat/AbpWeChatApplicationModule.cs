using GoodFramework.Abp.WeChat.MiniProgram;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace GoodFramework.Abp.WeChat
{
    [DependsOn(
        typeof(AbpWeChatMiniProgramModule),
        typeof(AbpWeChatApplicationContractsModule),
        typeof(AbpDddApplicationModule))]
    public class AbpWeChatApplicationModule : AbpModule
    {
    }
}
