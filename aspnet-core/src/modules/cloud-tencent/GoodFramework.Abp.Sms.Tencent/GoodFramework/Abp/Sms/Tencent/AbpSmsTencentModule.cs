using GoodFramework.Abp.Tencent;
using GoodFramework.Abp.Tencent.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Sms;
using Volo.Abp.VirtualFileSystem;

namespace GoodFramework.Abp.Sms.Tencent
{
    [DependsOn(
        typeof(AbpSmsModule),
        typeof(AbpTencentCloudModule))]
    public class AbpSmsTencentModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpSmsTencentModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                       .Get<TencentCloudResource>()
                       .AddVirtualJson("/GoodFramework/Abp/Sms/Tencent/Localization/Resources");
            });
        }
    }
}
