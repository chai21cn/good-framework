using System.Collections.Generic;

namespace GoodFramework.Abp.IM.Messages
{
    public interface IMessageSenderProviderManager
    {
        List<IMessageSenderProvider> Providers { get; }
    }
}
