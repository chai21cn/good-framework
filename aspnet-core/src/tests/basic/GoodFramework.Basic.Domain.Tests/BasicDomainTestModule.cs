using GoodFramework.Basic.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace GoodFramework.Basic;

[DependsOn(
    typeof(BasicEntityFrameworkCoreTestModule)
    )]
public class BasicDomainTestModule : AbpModule
{

}
