using System;
using System.ComponentModel.DataAnnotations;

namespace GoodFramework.Abp.Identity
{
    public class IdentityRoleAddOrRemoveOrganizationUnitDto
    {
        [Required]
        public Guid[] OrganizationUnitIds { get; set; }
    }
}
