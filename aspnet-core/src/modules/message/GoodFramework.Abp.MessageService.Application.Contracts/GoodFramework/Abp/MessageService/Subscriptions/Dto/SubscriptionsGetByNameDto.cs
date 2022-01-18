using GoodFramework.Abp.MessageService.Notifications;
using System.ComponentModel.DataAnnotations;

namespace GoodFramework.Abp.MessageService.Subscriptions
{
    public class SubscriptionsGetByNameDto
    {
        [Required]
        [StringLength(NotificationConsts.MaxNameLength)]
        public string Name { get; set; }
    }
}
