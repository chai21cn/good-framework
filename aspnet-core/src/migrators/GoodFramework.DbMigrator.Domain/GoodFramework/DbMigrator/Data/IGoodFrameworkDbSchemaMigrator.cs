using System.Threading.Tasks;

namespace GoodFramework.DbMigrator.Data
{
    public interface IGoodFrameworkDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
