using GoodFramework.Basic.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace GoodFramework.Basic.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class BasicController : AbpControllerBase
{
    protected BasicController()
    {
        LocalizationResource = typeof(BasicResource);
    }
}
