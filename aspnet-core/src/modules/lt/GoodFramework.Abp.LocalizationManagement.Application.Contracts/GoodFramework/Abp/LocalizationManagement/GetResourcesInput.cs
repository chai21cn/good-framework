using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.LocalizationManagement
{
    public class GetResourcesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
