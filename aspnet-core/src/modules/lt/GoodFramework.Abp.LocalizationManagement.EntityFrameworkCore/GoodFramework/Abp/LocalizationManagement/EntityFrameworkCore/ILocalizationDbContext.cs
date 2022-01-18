using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace GoodFramework.Abp.LocalizationManagement.EntityFrameworkCore
{
    [ConnectionStringName(LocalizationDbProperties.ConnectionStringName)]
    public interface ILocalizationDbContext : IEfCoreDbContext
    {
    }
}
