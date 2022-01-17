using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.Identity
{
    public class OrganizationUnitGetUnaddedUserByPagedDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
