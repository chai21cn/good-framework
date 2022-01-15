using Volo.Abp.Modularity;

namespace Good.Framework
{
    [DependsOn(
        typeof(FrameworkApplicationModule),
        typeof(FrameworkDomainTestModule)
        )]
    public class FrameworkApplicationTestModule : AbpModule
    {

    }
}