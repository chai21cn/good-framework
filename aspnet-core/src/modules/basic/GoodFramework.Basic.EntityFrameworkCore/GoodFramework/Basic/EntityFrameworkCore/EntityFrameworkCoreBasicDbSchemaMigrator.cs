using GoodFramework.DbMigrator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace GoodFramework.Basic.EntityFrameworkCore;

[ExposeServices(typeof(IGoodFrameworkDbSchemaMigrator))]
public class EntityFrameworkCoreBasicDbSchemaMigrator
    : IGoodFrameworkDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreBasicDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the BasicDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<BasicDbContext>()
            .Database
            .MigrateAsync();
    }
}
