using System.Threading.Tasks;

namespace GoodFramework.Abp.SettingManagement
{
    public interface ISettingAppService : IReadonlySettingAppService
    {
        Task SetGlobalAsync(UpdateSettingsDto input);

        Task SetCurrentTenantAsync(UpdateSettingsDto input);
    }
}
