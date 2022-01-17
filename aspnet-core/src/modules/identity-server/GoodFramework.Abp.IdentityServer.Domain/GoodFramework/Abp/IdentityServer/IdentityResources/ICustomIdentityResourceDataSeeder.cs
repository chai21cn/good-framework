using System.Threading.Tasks;

namespace GoodFramework.Abp.IdentityServer.IdentityResources
{
    public interface ICustomIdentityResourceDataSeeder
    {
        Task CreateCustomResourcesAsync();
    }
}
