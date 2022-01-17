using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace GoodFramework.Platform.Menus
{
    /// <summary>
    /// 用户菜单
    /// </summary>
    public class UserMenu : AuditedEntity<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; protected set; }

        public virtual Guid MenuId { get; protected set; }

        public virtual Guid UserId { get; protected set; }

        protected UserMenu() { }

        public UserMenu(
            Guid id,
            Guid menuId,
            Guid userId,
            Guid? tenantId = null)
            : base(id)
        {
            MenuId = menuId;
            UserId = userId;
            TenantId = tenantId;
        }

        public override object[] GetKeys()
        {
            return new object[] { MenuId, UserId };
        }
    }
}
