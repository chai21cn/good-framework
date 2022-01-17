using Volo.Abp.ExceptionHandling;
using Volo.Abp.Modularity;

namespace GoodFramework.Abp.Wrapper
{
    [DependsOn(typeof(AbpExceptionHandlingModule))]
    public class AbpWrapperModule: AbpModule
    {

    }
}
