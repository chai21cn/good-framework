using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.IdentityServer.Clients
{
    public class ClientGetByPagedDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
