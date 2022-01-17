using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace GoodFramework
{
    [Dependency(ReplaceServices = true)]
    public class GoodFrameworkBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "GoodFramework";
    }
}
