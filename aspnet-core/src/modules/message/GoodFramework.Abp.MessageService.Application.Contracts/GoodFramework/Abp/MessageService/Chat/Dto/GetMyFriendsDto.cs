using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.MessageService.Chat
{
    public class GetMyFriendsDto : ISortedResultRequest
    {
        public string Sorting { get; set; }
    }
}
