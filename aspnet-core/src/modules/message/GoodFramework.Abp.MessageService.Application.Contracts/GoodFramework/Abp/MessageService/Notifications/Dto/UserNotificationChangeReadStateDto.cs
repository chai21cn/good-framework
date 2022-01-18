using GoodFramework.Abp.Notifications;
using System.ComponentModel.DataAnnotations;

namespace GoodFramework.Abp.MessageService.Notifications
{
    public class UserNotificationChangeReadStateDto
    {
        [Required]
        public long NotificationId { get; set; }

        [Required]
        public NotificationReadState ReadState { get; set; } = NotificationReadState.Read;
    }
}
