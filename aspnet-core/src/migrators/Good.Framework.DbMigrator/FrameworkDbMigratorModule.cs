using Good.Framework.Abp.UI.Navigation.VueVbenAdmin;
using Good.Framework.EntityFrameworkCore;
using Good.Framework.Platform;
using Good.Framework.Platform.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Good.Framework.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(FrameworkEntityFrameworkCoreModule),
        typeof(FrameworkApplicationContractsModule),
        typeof(PlatformEntityFrameworkCoreModule),
        typeof(PlatformApplicationContractsModule),
        typeof(AbpUINavigationVueVbenAdminModule)
        )]
    public class FrameworkDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
