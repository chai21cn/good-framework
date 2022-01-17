using GoodFramework.Abp.Features.LimitValidation;
using GoodFramework.Abp.WeChat.Localization;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace GoodFramework.Abp.WeChat.MiniProgram
{
    [DependsOn(
        typeof(AbpWeChatModule),
        typeof(AbpFeaturesLimitValidationModule))]
    public class AbpWeChatMiniProgramModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpWeChatMiniProgramModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<WeChatResource>()
                    .AddVirtualJson("/GoodFramework/Abp/WeChat/MiniProgram/Localization/Resources");
            });

            context.Services.AddHttpClient(AbpWeChatMiniProgramConsts.HttpClient, options =>
            {
                options.BaseAddress = new Uri("https://api.weixin.qq.com");
            });

            context.Services.AddAbpDynamicOptions<AbpWeChatMiniProgramOptions, AbpWeChatMiniProgramOptionsManager>();
        }
    }
}
