using GoodFramework.DbMigrator.Data;
using Microsoft.EntityFrameworkCore;

namespace GoodFramework.Abp.MessageService.EntityFrameworkCore;

public class MessageServiceDbContextFactory : BaseDbContextFactory<MessageServiceDbContext>
{
    protected override void PreCreateDbContext() {
        MessageServiceEfCoreEntityExtensionMappings.Configure();
    }

    protected override MessageServiceDbContext CreateDbContext(DbContextOptions<MessageServiceDbContext> options) {
        return new MessageServiceDbContext(options);
    }
}
