using GoodFramework.DbMigrator.Data;
using Microsoft.EntityFrameworkCore;

namespace GoodFramework.Abp.TaskManagement.EntityFrameworkCore;

public class TaskManagementDbContextFactory : BaseDbContextFactory<TaskManagementDbContext>
{
    protected override void PreCreateDbContext() {
        TaskManagementEfCoreEntityExtensionMappings.Configure();
    }

    protected override TaskManagementDbContext CreateDbContext(DbContextOptions<TaskManagementDbContext> options) {
        return new TaskManagementDbContext(options);
    }
}
