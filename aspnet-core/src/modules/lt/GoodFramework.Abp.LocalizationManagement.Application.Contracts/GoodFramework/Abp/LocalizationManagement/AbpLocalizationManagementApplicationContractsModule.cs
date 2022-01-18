using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace GoodFramework.Abp.LocalizationManagement
{
    [DependsOn(
        typeof(AbpAuthorizationModule),
        typeof(AbpLocalizationManagementDomainSharedModule))]
    public class AbpLocalizationManagementApplicationContractsModule : AbpModule
    {

    }
}
