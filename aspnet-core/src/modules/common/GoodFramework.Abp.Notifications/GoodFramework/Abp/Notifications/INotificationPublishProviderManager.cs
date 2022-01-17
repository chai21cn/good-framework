using System.Collections.Generic;

namespace GoodFramework.Abp.Notifications
{
    public interface INotificationPublishProviderManager
    {
        List<INotificationPublishProvider> Providers { get; }
    }
}
