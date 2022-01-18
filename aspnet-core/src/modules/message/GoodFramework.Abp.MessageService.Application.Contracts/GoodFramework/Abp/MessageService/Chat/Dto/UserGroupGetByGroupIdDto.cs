using System.ComponentModel.DataAnnotations;

namespace GoodFramework.Abp.MessageService.Chat
{
    public class UserGroupGetByGroupIdDto
    {
        [Required]
        public long GroupId { get; set; }
    }
}
