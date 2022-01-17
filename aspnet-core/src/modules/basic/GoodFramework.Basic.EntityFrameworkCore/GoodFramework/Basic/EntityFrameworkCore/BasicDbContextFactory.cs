using GoodFramework.DbMigrator.Data;
using Microsoft.EntityFrameworkCore;

namespace GoodFramework.Basic.EntityFrameworkCore;

public class BasicDbContextFactory : BaseDbContextFactory<BasicDbContext>
{
    protected override void PreCreateDbContext()
    {
        BasicEfCoreEntityExtensionMappings.Configure();
    }

    protected override BasicDbContext CreateDbContext(DbContextOptions<BasicDbContext> options)
    {
        return new BasicDbContext(options);
    }
}
