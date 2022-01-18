using System.Threading.Tasks;
using Volo.Abp.Users;

namespace GoodFramework.Abp.MessageService.Chat
{
    public interface IChatDataSeeder
    {
        Task SeedAsync(
            IUserData user);
    }
}
