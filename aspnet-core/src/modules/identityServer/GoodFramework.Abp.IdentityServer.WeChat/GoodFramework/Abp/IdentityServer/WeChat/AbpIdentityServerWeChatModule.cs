using GoodFramework.Abp.Identity.WeChat;
using GoodFramework.Abp.IdentityServer.WeChat.MiniProgram;
using GoodFramework.Abp.IdentityServer.WeChat.Official;
using GoodFramework.Abp.WeChat.MiniProgram;
using GoodFramework.Abp.WeChat.Official;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.IdentityServer;
using Volo.Abp.IdentityServer.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace GoodFramework.Abp.IdentityServer.WeChat
{
    [DependsOn(
        typeof(AbpWeChatOfficialModule),
        typeof(AbpWeChatMiniProgramModule),
        typeof(AbpIdentityWeChatModule),
        typeof(AbpIdentityServerDomainModule))]
    public class AbpIdentityServerWeChatModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            PreConfigure<IIdentityServerBuilder>(builder =>
            {
                builder.AddProfileService<WeChatMiniProgramProfileService>();

                // TODO: 两个类型不通用配置项,不然只需要一个
                builder.AddExtensionGrantValidator<WeChatMiniProgramGrantValidator>();
                builder.AddExtensionGrantValidator<WeChatOfficialGrantValidator>();
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpIdentityServerWeChatModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AbpIdentityServerResource>()
                    .AddVirtualJson("/GoodFramework/Abp/IdentityServer/WeChat/Localization");
            });

            context.Services
                .AddAuthentication()
                .AddWeChat();
        }
    }
}
