using System.Threading.Tasks;

namespace Good.Framework.Platform.Migrators
{
    public interface IPlatformDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
