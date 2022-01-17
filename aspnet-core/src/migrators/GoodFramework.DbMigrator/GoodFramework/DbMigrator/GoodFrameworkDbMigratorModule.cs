using GoodFramework.Abp.UI.Navigation.VueVbenAdmin;
using GoodFramework.Basic;
using GoodFramework.Basic.EntityFrameworkCore;
using GoodFramework.Platform;
using GoodFramework.Platform.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace GoodFramework.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(BasicEntityFrameworkCoreModule),
        typeof(BasicApplicationContractsModule),
        typeof(PlatformEntityFrameworkCoreModule),
        typeof(PlatformApplicationContractsModule),
        typeof(AbpUINavigationVueVbenAdminModule)
        )]
    public class GoodFrameworkDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
