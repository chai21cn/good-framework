using System.ComponentModel.DataAnnotations;

namespace GoodFramework.Abp.MessageService.Notifications
{
    public class UserNotificationGetByNameDto
    {
        [Required]
        [StringLength(NotificationConsts.MaxNameLength)]
        public string NotificationName { get; set; }
    }
}
