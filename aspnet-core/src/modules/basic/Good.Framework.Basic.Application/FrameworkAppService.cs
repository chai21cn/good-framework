using System;
using System.Collections.Generic;
using System.Text;
using Good.Framework.Localization;
using Volo.Abp.Application.Services;

namespace Good.Framework
{
    /* Inherit your application services from this class.
     */
    public abstract class FrameworkAppService : ApplicationService
    {
        protected FrameworkAppService()
        {
            LocalizationResource = typeof(FrameworkResource);
        }
    }
}
