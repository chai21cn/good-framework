using GoodFramework.Platform.Routes;
using Volo.Abp.Validation;

namespace GoodFramework.Platform.Menus
{
    public class GetMenuInput
    {
        [DynamicStringLength(typeof(LayoutConsts), nameof(LayoutConsts.MaxFrameworkLength))]
        public string Framework { get; set; }
    }
}
