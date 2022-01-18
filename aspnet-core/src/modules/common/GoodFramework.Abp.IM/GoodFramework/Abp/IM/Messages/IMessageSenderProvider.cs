using System.Threading.Tasks;

namespace GoodFramework.Abp.IM.Messages
{
    public interface IMessageSenderProvider
    {
        string Name { get; }
        Task SendMessageAsync(ChatMessage chatMessage);
    }
}
