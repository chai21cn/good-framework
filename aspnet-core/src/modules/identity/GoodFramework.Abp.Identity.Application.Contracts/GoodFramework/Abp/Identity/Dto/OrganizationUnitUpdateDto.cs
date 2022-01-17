using Volo.Abp.ObjectExtending;

namespace GoodFramework.Abp.Identity
{
    public class OrganizationUnitUpdateDto : ExtensibleObject
    {
        public string DisplayName { get; set; }
    }
}
