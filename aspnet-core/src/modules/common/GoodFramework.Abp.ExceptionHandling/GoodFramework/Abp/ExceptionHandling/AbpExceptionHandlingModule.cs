using GoodFramework.Abp.ExceptionHandling.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace GoodFramework.Abp.ExceptionHandling
{
    [DependsOn(typeof(AbpLocalizationModule))]
    public class AbpExceptionHandlingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources.Add<ExceptionHandlingResource>("en");
            });
        }
    }
}
