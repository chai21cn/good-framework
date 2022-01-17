using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.Identity
{
    public class IdentityClaimTypeGetByPagedDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
