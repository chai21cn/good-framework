using GoodFramework.DbMigrator;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace GoodFramework.Abp.TaskManagement.EntityFrameworkCore;

[DependsOn(
    typeof(TaskManagementDomainModule),
    typeof(AbpEntityFrameworkCoreModule),
    typeof(GoodFrameworkDbMigratorDomainModule)
    )]
public class TaskManagementEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context) {
        TaskManagementEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<TaskManagementDbContext>(options =>
        {
            options.AddRepository<BackgroundJobInfo, EfCoreBackgroundJobInfoRepository>();
            options.AddRepository<BackgroundJobLog, EfCoreBackgroundJobLogRepository>();
        });
    }
}
