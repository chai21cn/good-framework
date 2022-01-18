using GoodFramework.Abp.Auditing;
using GoodFramework.Abp.AuditLogging.EntityFrameworkCore;
using GoodFramework.Abp.Identity;
using GoodFramework.Abp.Identity.EntityFrameworkCore;
using GoodFramework.Abp.LocalizationManagement;
using GoodFramework.Abp.LocalizationManagement.EntityFrameworkCore;
using GoodFramework.Abp.MessageService;
using GoodFramework.Abp.MessageService.EntityFrameworkCore;
using GoodFramework.Abp.OssManagement;
using GoodFramework.Abp.TaskManagement;
using GoodFramework.Abp.TaskManagement.EntityFrameworkCore;
using GoodFramework.Abp.TenantManagement;
using GoodFramework.Abp.UI.Navigation.VueVbenAdmin;
using GoodFramework.Basic;
using GoodFramework.Basic.EntityFrameworkCore;
using GoodFramework.Platform;
using GoodFramework.Platform.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.EntityFrameworkCore;
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
    // Localization
    typeof(AbpLocalizationManagementEntityFrameworkCoreModule),
    typeof(AbpLocalizationManagementApplicationContractsModule),
    // MessageService
    typeof(AbpMessageServiceEntityFrameworkCoreModule),
    typeof(AbpMessageServiceApplicationContractsModule),
    // OssManagement
    typeof(AbpOssManagementApplicationContractsModule),
    // TenantManagement
    typeof(AbpTenantManagementApplicationContractsModule),
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

        ConfigureDbContext();
    }

    private void ConfigureDbContext() {
        // 配置Ef
        Configure<AbpDbContextOptions>(options =>
        {
            options.UseSqlServer();
        });
    }
}
