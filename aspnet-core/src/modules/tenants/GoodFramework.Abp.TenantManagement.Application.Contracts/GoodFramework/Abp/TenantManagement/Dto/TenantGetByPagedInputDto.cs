using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.TenantManagement
{
    public class TenantGetByPagedInputDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}