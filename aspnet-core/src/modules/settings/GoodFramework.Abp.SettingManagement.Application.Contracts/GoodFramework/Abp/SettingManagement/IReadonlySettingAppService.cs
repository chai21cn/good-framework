using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace GoodFramework.Abp.SettingManagement
{
    public interface IReadonlySettingAppService : IApplicationService
    {
        Task<SettingGroupResult> GetAllForGlobalAsync();

        Task<SettingGroupResult> GetAllForCurrentTenantAsync();
    }
}
