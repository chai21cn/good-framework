using Good.Framework.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Good.Framework.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class FrameworkController : AbpControllerBase
    {
        protected FrameworkController()
        {
            LocalizationResource = typeof(FrameworkResource);
        }
    }
}