using GoodFramework.Platform.Routes;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;

namespace GoodFramework.Platform.Layouts
{
    public class GetLayoutListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public bool Reverse { get; set; }

        [DynamicStringLength(typeof(LayoutConsts), nameof(LayoutConsts.MaxFrameworkLength))]
        public string Framework { get; set; }
    }
}
