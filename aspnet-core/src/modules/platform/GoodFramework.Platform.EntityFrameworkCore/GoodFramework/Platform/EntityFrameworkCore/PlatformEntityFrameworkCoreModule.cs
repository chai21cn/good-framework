using GoodFramework.DbMigrator;
using GoodFramework.Platform.Datas;
using GoodFramework.Platform.Layouts;
using GoodFramework.Platform.Menus;
using GoodFramework.Platform.Versions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace GoodFramework.Platform.EntityFrameworkCore
{
    [DependsOn(
        typeof(PlatformDomainModule),
        typeof(AbpEntityFrameworkCoreModule),
        typeof(GoodFrameworkDbMigratorDomainModule)
        )]
    public class PlatformEntityFrameworkCoreModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context) {
            PlatformEfCoreEntityExtensionMappings.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context) {
            context.Services.AddAbpDbContext<PlatformDbContext>(options => {
                options.AddRepository<Data, EfCoreDataRepository>();
                options.AddRepository<Menu, EfCoreMenuRepository>();
                options.AddRepository<UserMenu, EfCoreUserMenuRepository>();
                options.AddRepository<RoleMenu, EfCoreRoleMenuRepository>();
                options.AddRepository<Layout, EfCoreLayoutRepository>();
                options.AddRepository<AppVersion, EfCoreVersionRepository>();

                options.AddDefaultRepositories(includeAllEntities: true);

                options.Entity<AppVersion>(appVersion => {
                    appVersion.DefaultWithDetailsFunc = (x) =>
                        x.Include(q => q.Files);
                });
            });
        }
    }
}
