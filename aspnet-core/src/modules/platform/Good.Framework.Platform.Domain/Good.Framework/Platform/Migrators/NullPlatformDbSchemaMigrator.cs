using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Good.Framework.Platform.Migrators
{
    /* This is used if database provider does't define
     * IPlatformDbSchemaMigrator implementation.
     */
    public class NullPlatformDbSchemaMigrator : IPlatformDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}