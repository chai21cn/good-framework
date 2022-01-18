using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GoodFramework.Abp.LocalizationManagement
{
    public interface IResourceAppService : 
        ICrudAppService<
            ResourceDto,
            Guid,
            GetResourcesInput,
            CreateOrUpdateResourceInput,
            CreateOrUpdateResourceInput>
    {
        Task<ListResultDto<ResourceDto>> GetAllAsync();
    }
}
