using GoodFramework.Platform.Datas;
using GoodFramework.Platform.Layouts;
using GoodFramework.Platform.Menus;
using GoodFramework.Platform.Versions;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace GoodFramework.Platform.EntityFrameworkCore
{
    [ConnectionStringName(PlatformDbProperties.ConnectionStringName)]
    public class PlatformDbContext : AbpDbContext<PlatformDbContext>, IPlatformDbContext
    {
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Layout> Layouts { get; set; }
        public DbSet<Data> Datas { get; set; }

        public DbSet<AppVersion> AppVersions { get; set; }

        public PlatformDbContext(DbContextOptions<PlatformDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigurePlatform();

            base.OnModelCreating(builder);
        }
    }
}
