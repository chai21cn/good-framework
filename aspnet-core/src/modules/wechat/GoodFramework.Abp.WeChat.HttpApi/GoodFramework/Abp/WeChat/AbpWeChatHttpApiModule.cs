using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace GoodFramework.Abp.WeChat
{
    [DependsOn(
        typeof(AbpWeChatApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class AbpWeChatHttpApiModule : AbpModule
    {
    }
}
