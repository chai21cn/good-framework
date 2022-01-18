using Volo.Abp.Modularity;

namespace GoodFramework.Abp.MessageService
{
    [DependsOn(
        typeof(AbpMessageServiceApplicationContractsModule),
        typeof(AbpMessageServiceDomainModule))]
    public class AbpMessageServiceApplicationModule : AbpModule
    {

    }
}
