using GoodFramework.DbMigrator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace GoodFramework.Abp.LocalizationManagement.EntityFrameworkCore;

[ExposeServices(typeof(IGoodFrameworkDbSchemaMigrator))]
public class EntityFrameworkCoreLocalizationDbSchemaMigrator
    : IGoodFrameworkDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreLocalizationDbSchemaMigrator(
        IServiceProvider serviceProvider) {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync() {
        /* We intentionally resolving the FrameworkDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<LocalizationDbContext>()
            .Database
            .MigrateAsync();
    }
}
