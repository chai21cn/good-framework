using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Good.Framework
{
    [Dependency(ReplaceServices = true)]
    public class FrameworkBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Framework";
    }
}
