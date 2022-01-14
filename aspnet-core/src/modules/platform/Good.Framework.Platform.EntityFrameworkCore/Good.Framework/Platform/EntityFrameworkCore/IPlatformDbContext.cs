using Good.Framework.Platform.Datas;
using Good.Framework.Platform.Layouts;
using Good.Framework.Platform.Menus;
using Good.Framework.Platform.Versions;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Good.Framework.Platform.EntityFrameworkCore
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
