using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.Identity
{
    public class OrganizationUnitGetByPagedDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
