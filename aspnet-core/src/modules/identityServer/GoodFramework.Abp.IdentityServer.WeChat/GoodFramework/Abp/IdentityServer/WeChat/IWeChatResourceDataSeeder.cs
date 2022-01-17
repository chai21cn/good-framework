using System.Threading.Tasks;

namespace GoodFramework.Abp.IdentityServer
{
    public interface IWeChatResourceDataSeeder
    {
        Task CreateStandardResourcesAsync();
    }
}
