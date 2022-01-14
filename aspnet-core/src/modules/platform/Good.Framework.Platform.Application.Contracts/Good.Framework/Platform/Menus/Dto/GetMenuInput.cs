using Good.Framework.Platform.Routes;
using Volo.Abp.Validation;

namespace Good.Framework.Platform.Menus
{
    public class GetMenuInput
    {
        [DynamicStringLength(typeof(LayoutConsts), nameof(LayoutConsts.MaxFrameworkLength))]
        public string Framework { get; set; }
    }
}
