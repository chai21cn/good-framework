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
    public interface IPlatformDbContext : IEfCoreDbContext
    {
        DbSet<Menu> Menus { get; set; }
        DbSet<Layout> Layouts { get; set; }
        DbSet<Data> Datas { get; set; }
        DbSet<AppVersion> AppVersions { get; set; }
    }
}
