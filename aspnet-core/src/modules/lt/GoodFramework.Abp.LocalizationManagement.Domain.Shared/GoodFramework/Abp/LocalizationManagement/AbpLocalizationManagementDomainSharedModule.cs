using GoodFramework.Abp.LocalizationManagement.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.VirtualFileSystem;

namespace GoodFramework.Abp.LocalizationManagement
{
    [DependsOn(
        typeof(AbpValidationModule),
        typeof(AbpLocalizationModule))]
    public class AbpLocalizationManagementDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context) {
            LocalizationGlobalFeatureConfigurator.Configure();
            LocalizationModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpLocalizationManagementDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<LocalizationManagementResource>("en")
                    .AddVirtualJson("/GoodFramework/Abp/LocalizationManagement/Localization/Resources");
            });
        }
    }
}
