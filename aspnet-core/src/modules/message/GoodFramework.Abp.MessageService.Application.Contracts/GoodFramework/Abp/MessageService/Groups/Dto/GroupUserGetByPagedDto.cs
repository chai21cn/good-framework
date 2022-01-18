using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.MessageService.Groups
{
    public class GroupUserGetByPagedDto : PagedAndSortedResultRequestDto
    {
        [Required]
        public long GroupId { get; set; }

        public string Filter { get; set; }
    }
}
