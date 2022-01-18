using GoodFramework.Abp.IM.Localization;
using GoodFramework.Abp.RealTime;
using GoodFramework.Abp.IdGenerator;
using Volo.Abp.EventBus;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace GoodFramework.Abp.IM
{
    [DependsOn(
        typeof(AbpEventBusModule),
        typeof(AbpRealTimeModule),
        typeof(AbpLocalizationModule),
        typeof(AbpIdGeneratorModule))]
    public class AbpIMModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpIMModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<AbpIMResource>()
                    .AddVirtualJson("/GoodFramework/Abp/IM/Localization/Resources");
            });
        }
    }
}
