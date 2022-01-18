using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.LocalizationManagement
{
    public class GetLanguagesInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
