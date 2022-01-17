using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace GoodFramework.DbMigrator.Data
{
    /* This is used if database provider does't define
     * IFrameworkDbSchemaMigrator implementation.
     */
    public class NullGoodFrameworkDbSchemaMigrator : IGoodFrameworkDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}