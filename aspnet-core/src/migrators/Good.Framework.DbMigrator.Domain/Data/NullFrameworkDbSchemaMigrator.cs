using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Good.Framework.DbMigrator.Domain.Data
{
    /* This is used if database provider does't define
     * IFrameworkDbSchemaMigrator implementation.
     */
    public class NullFrameworkDbSchemaMigrator : IFrameworkDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}