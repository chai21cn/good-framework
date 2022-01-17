using GoodFramework.Platform.Routes;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace GoodFramework.Platform.Layouts
{
    public class LayoutCreateDto : LayoutCreateOrUpdateDto
    {
        public Guid DataId { get; set; }

        [Required]
        [DynamicStringLength(typeof(LayoutConsts), nameof(LayoutConsts.MaxFrameworkLength))]
        public string Framework { get; set; }
    }
}
