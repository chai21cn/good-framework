using System;
using System.Collections.Generic;
using System.Text;
using GoodFramework.Basic.Localization;
using Volo.Abp.Application.Services;

namespace GoodFramework.Basic;

/* Inherit your application services from this class.
 */
public abstract class BasicAppService : ApplicationService
{
    protected BasicAppService()
    {
        LocalizationResource = typeof(BasicResource);
    }
}
