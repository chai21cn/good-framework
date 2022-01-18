using System.ComponentModel.DataAnnotations;

namespace GoodFramework.Abp.MessageService.Notifications
{
    public class NotificationGetByIdDto
    {
        [Required]
        public long NotificationId { get; set; }
    }
}
