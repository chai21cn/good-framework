using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.IdentityServer.ApiScopes
{
    public class GetApiScopeInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
