using Good.Framework.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Good.Framework
{
    [DependsOn(
        typeof(FrameworkEntityFrameworkCoreTestModule)
        )]
    public class FrameworkDomainTestModule : AbpModule
    {

    }
}