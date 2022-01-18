using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.MessageService.Groups
{
    public class GroupSearchInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
