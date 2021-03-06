using System;
using Volo.Abp.MultiTenancy;

namespace GoodFramework.Platform.Routes
{
    public class RoleRouteEto : IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public Guid RouteId { get; set; }
        public string RoleName { get; set; }
    }
}
