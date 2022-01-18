using GoodFramework.Abp.Notifications;
using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.MessageService.Notifications
{
    public class UserNotificationGetByPagedDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public NotificationReadState? ReadState { get; set; }
    }
}
