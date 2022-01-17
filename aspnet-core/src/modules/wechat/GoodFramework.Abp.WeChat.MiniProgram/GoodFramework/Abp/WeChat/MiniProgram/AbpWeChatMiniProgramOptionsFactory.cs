using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace GoodFramework.Abp.WeChat.MiniProgram
{
    public class AbpWeChatMiniProgramOptionsFactory : ITransientDependency
    {
        protected IOptions<AbpWeChatMiniProgramOptions> Options { get; }

        public AbpWeChatMiniProgramOptionsFactory(
            IOptions<AbpWeChatMiniProgramOptions> options)
        {
            Options = options;
        }

        public virtual async Task<AbpWeChatMiniProgramOptions> CreateAsync()
        {
            await Options.SetAsync();

            return Options.Value;
        }
    }
}
