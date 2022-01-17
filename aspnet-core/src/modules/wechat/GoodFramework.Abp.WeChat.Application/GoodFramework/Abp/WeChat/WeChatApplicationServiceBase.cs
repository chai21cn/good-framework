using GoodFramework.Abp.WeChat.Localization;
using Volo.Abp.Application.Services;

namespace GoodFramework.Abp.WeChat
{
    public abstract class WeChatApplicationServiceBase : ApplicationService
    {
        protected WeChatApplicationServiceBase()
        {
            LocalizationResource = typeof(WeChatResource);
            ObjectMapperContext = typeof(AbpWeChatApplicationModule);
        }
    }
}
