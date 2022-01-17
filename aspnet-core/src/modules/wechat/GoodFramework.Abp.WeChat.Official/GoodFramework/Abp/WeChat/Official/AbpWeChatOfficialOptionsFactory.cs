using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace GoodFramework.Abp.WeChat.Official
{
    public class AbpWeChatOfficialOptionsFactory : ITransientDependency
    {
        protected IOptions<AbpWeChatOfficialOptions> Options { get; }

        public AbpWeChatOfficialOptionsFactory(
            IOptions<AbpWeChatOfficialOptions> options)
        {
            Options = options;
        }

        public virtual async Task<AbpWeChatOfficialOptions> CreateAsync()
        {
            await Options.SetAsync();

            return Options.Value;
        }
    }
}
