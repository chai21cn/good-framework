using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Good.Framework.Data;
using Volo.Abp.DependencyInjection;

namespace Good.Framework.EntityFrameworkCore
{
    public class EntityFrameworkCoreFrameworkDbSchemaMigrator
        : IFrameworkDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreFrameworkDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the FrameworkDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<FrameworkDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
