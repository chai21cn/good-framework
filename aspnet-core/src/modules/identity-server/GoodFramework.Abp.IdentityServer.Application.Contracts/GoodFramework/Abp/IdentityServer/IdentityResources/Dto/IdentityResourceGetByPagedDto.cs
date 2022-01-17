using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.IdentityServer.IdentityResources
{
    public class IdentityResourceGetByPagedDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
