using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace GoodFramework.Abp.WeChat
{
    [DependsOn(
        typeof(AbpDddApplicationContractsModule))]
    public class AbpWeChatApplicationContractsModule : AbpModule
    {
    }
}
