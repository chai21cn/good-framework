using Good.Framework.Platform.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Settings;

namespace Good.Framework.Platform
{
    public abstract class PlatformControllerBase : AbpController
    {
        protected ISettingProvider SettingProvider => LazyServiceProvider.LazyGetRequiredService<ISettingProvider>();

        protected PlatformControllerBase()
        {
            LocalizationResource = typeof(PlatformResource);
        }
    }
}
