using Volo.Abp.Modularity;

namespace GoodFramework.Basic;

[DependsOn(
    typeof(BasicApplicationModule),
    typeof(BasicDomainTestModule)
    )]
public class BasicApplicationTestModule : AbpModule
{

}
