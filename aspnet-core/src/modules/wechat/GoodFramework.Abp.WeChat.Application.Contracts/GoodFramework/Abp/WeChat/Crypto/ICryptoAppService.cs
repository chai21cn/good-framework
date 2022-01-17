using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace GoodFramework.Abp.WeChat.Crypto
{
    public interface ICryptoAppService : IApplicationService
    {
        Task<UserInfoDto> GetUserInfoAsync(GetUserInfoInput input);
    }
}
