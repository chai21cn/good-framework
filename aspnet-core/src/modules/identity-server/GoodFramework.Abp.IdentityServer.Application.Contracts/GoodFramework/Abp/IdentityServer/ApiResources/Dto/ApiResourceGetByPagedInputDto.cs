using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.IdentityServer.ApiResources
{
    public class ApiResourceGetByPagedInputDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
