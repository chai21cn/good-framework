using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using Volo.Abp.EntityFrameworkCore;

namespace GoodFramework.DbMigrator.Data
{
    public abstract class BaseDbContextFactory<TDbContext> : IDesignTimeDbContextFactory<TDbContext>
        where TDbContext : AbpDbContext<TDbContext>
    {
        public TDbContext CreateDbContext(string[] args)
        {
            this.PreCreateDbContext();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<TDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return this.CreateDbContext(builder.Options);
        }

        protected abstract void PreCreateDbContext();
        protected abstract TDbContext CreateDbContext(DbContextOptions<TDbContext> options);

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../GoodFramework.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
