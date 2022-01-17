using System;
using System.ComponentModel.DataAnnotations;

namespace GoodFramework.Abp.Identity
{
    public class IdentityUserOrganizationUnitUpdateDto
    {
        [Required]
        public Guid[] OrganizationUnitIds { get; set; }
    }
}
