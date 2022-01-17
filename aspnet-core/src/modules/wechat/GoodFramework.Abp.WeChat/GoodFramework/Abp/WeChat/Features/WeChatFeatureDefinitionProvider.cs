using GoodFramework.Abp.WeChat.Localization;
using Volo.Abp.Features;
using Volo.Abp.Localization;

namespace GoodFramework.Abp.WeChat.Features
{
    public class WeChatFeatureDefinitionProvider : FeatureDefinitionProvider
    {
        public override void Define(IFeatureDefinitionContext context)
        {
            context.AddGroup(WeChatFeatures.GroupName, L("Features:WeChat"));
        }

        protected LocalizableString L(string name)
        {
            return LocalizableString.Create<WeChatResource>(name);
        }
    }
}
