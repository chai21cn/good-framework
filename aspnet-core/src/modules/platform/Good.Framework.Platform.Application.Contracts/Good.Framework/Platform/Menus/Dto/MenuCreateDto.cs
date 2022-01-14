using System;
using System.ComponentModel.DataAnnotations;

namespace Good.Framework.Platform.Menus
{
    public class MenuCreateDto : MenuCreateOrUpdateDto
    {
        public Guid? ParentId { get; set; }

        [Required]
        public Guid LayoutId { get; set; }
    }
}
