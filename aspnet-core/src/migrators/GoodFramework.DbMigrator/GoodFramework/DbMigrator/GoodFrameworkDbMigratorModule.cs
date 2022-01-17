using GoodFramework.Abp.Auditing;
using GoodFramework.Abp.AuditLogging.EntityFrameworkCore;
using GoodFramework.Abp.Identity;
using GoodFramework.Abp.Identity.EntityFrameworkCore;
using GoodFramework.Abp.TaskManagement;
using GoodFramework.Abp.TaskManagement.EntityFrameworkCore;
using GoodFramework.Abp.UI.Navigation.VueVbenAdmin;
using GoodFramework.Basic;
using GoodFramework.Basic.EntityFrameworkCore;
using GoodFramework.Platform;
using GoodFramework.Platform.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace GoodFramework.DbMigrator;


[DependsOn(
    typeof(AbpAutofacModule),
    // 基础
    typeof(BasicEntityFrameworkCoreModule),
    typeof(BasicApplicationContractsModule),
    // 框架菜单
    typeof(PlatformEntityFrameworkCoreModule),
    typeof(PlatformApplicationContractsModule),
    typeof(AbpUINavigationVueVbenAdminModule),
    // 后台任务
    typeof(TaskManagementEntityFrameworkCoreModule),
    typeof(TaskManagementApplicationContractsModule),
    // ABP
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpAuditingApplicationContractsModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule)
    )]
public class GoodFrameworkDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context) {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
