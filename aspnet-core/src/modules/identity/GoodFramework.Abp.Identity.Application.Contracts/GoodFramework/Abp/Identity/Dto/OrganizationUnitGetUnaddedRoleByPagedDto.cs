using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.Identity
{
    public class OrganizationUnitGetUnaddedRoleByPagedDto : PagedAndSortedResultRequestDto
    {

        public string Filter { get; set; }
    }
}
