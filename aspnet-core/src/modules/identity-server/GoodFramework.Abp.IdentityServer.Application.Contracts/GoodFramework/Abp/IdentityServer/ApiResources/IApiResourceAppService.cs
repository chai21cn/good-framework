using System;
using Volo.Abp.Application.Services;

namespace GoodFramework.Abp.IdentityServer.ApiResources
{
    public interface IApiResourceAppService : 
        ICrudAppService<
            ApiResourceDto,
            Guid,
            ApiResourceGetByPagedInputDto,
            ApiResourceCreateDto,
            ApiResourceUpdateDto>
    {
    }
}
