using Good.Framework.Platform.Routes;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace Good.Framework.Platform.Menus
{
    public class MenuGetByUserInput
    {
        [Required]
        public Guid UserId { get; set; }

        public string[] Roles { get; set; } = new string[0];

        [DynamicStringLength(typeof(LayoutConsts), nameof(LayoutConsts.MaxFrameworkLength))]
        public string Framework { get; set; }
    }
}
