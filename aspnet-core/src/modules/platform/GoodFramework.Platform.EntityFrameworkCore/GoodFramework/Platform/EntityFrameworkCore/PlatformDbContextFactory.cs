using GoodFramework.DbMigrator.Data;
using Microsoft.EntityFrameworkCore;

namespace GoodFramework.Platform.EntityFrameworkCore
{
    public class PlatformDbContextFactory : BaseDbContextFactory<PlatformDbContext>
    {
        protected override void PreCreateDbContext() {
            PlatformEfCoreEntityExtensionMappings.Configure();
        }

        protected override PlatformDbContext CreateDbContext(DbContextOptions<PlatformDbContext> options) {
            return new PlatformDbContext(options);
        }
    }
}
