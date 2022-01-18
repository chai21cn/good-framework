using System.Threading.Tasks;

namespace GoodFramework.Abp.IM.Messages
{
    public interface IMessageSender
    {
        Task<string> SendMessageAsync(ChatMessage chatMessage);
    }
}
