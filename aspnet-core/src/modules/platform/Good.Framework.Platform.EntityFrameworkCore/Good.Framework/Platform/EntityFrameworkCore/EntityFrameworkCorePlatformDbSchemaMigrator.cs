using Good.Framework.DbMigrator.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Good.Framework.Platform.EntityFrameworkCore
{
    [ExposeServices(typeof(IFrameworkDbSchemaMigrator))]
    public class EntityFrameworkCorePlatformDbSchemaMigrator
        : IFrameworkDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCorePlatformDbSchemaMigrator(
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
                .GetRequiredService<PlatformDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
