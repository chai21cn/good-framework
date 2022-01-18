using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GoodFramework.Abp.OssManagement
{
    public interface IShareFileAppService : IApplicationService
    {
        Task<GetFileShareDto> GetAsync(string url);
    }
}
