using Good.Framework.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Good.Framework.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(FrameworkEntityFrameworkCoreModule),
        typeof(FrameworkApplicationContractsModule)
        )]
    public class FrameworkDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
