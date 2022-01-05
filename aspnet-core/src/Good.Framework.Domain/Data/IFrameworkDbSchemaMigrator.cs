using System.Threading.Tasks;

namespace Good.Framework.Data
{
    public interface IFrameworkDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
