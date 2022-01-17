using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace GoodFramework.Abp.Logging
{
    public class AbpLoggingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            Configure<AbpLoggingEnricherPropertyNames>(configuration.GetSection("Logging"));
        }
    }
}
