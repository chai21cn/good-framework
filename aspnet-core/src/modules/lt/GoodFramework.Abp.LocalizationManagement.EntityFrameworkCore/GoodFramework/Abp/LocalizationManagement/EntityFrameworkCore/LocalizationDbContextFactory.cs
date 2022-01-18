using GoodFramework.DbMigrator.Data;
using Microsoft.EntityFrameworkCore;

namespace GoodFramework.Abp.LocalizationManagement.EntityFrameworkCore;

public class LocalizationDbContextFactory : BaseDbContextFactory<LocalizationDbContext>
{
    protected override void PreCreateDbContext() {
        LocalizationEfCoreEntityExtensionMappings.Configure();
    }

    protected override LocalizationDbContext CreateDbContext(DbContextOptions<LocalizationDbContext> options) {
        return new LocalizationDbContext(options);
    }
}
