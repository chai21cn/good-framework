﻿using Volo.Abp.AspNetCore;
using Volo.Abp.Modularity;

namespace Good.Framework.Abp.Localization.CultureMap
{
    [DependsOn(typeof(AbpAspNetCoreModule))]
    public class AbpLocalizationCultureMapModule : AbpModule
    {
    }
}
