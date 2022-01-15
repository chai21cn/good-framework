using System.Threading.Tasks;

namespace Good.Framework.DbMigrator.Domain.Data
{
    public interface IFrameworkDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
