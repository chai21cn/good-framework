using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace GoodFramework.Abp.Localization.Dynamic
{
    [DependsOn(typeof(AbpLocalizationModule))]
    public class AbpLocalizationDynamicModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHostedService<DynamicLocalizationInitializeService>();
        }
    }
}
