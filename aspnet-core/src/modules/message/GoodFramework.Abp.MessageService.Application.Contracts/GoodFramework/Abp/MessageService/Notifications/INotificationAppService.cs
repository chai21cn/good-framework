using System.Threading.Tasks;

namespace GoodFramework.Abp.MessageService.Notifications
{
    public interface INotificationAppService
    {
        Task SendAsync(NotificationSendDto input);
    }
}
