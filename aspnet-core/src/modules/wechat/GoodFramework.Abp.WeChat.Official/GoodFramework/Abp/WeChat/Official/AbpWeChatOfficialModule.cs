using GoodFramework.Abp.WeChat.Localization;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace GoodFramework.Abp.WeChat.Official
{
    [DependsOn(
        typeof(AbpWeChatModule))]
    public class AbpWeChatOfficialModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpWeChatOfficialModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<WeChatResource>()
                    .AddVirtualJson("/GoodFramework/Abp/WeChat/Official/Localization/Resources");
            });

            context.Services.AddAbpDynamicOptions<AbpWeChatOfficialOptions, AbpWeChatOfficialOptionsManager>();
        }
    }
}
