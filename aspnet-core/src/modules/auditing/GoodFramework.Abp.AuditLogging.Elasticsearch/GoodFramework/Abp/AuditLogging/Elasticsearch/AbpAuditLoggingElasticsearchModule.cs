using GoodFramework.Abp.Elasticsearch;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Json;
using Volo.Abp.Modularity;

namespace GoodFramework.Abp.AuditLogging.Elasticsearch
{
    [DependsOn(
        typeof(AbpAuditLoggingModule),
        typeof(AbpElasticsearchModule),
        typeof(AbpJsonModule))]
    public class AbpAuditLoggingElasticsearchModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            Configure<AbpAuditLoggingElasticsearchOptions>(configuration.GetSection("AuditLogging:Elasticsearch"));

            context.Services.AddHostedService<IndexInitializerService>();
        }
    }
}
