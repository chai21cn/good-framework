using System;
using Volo.Abp.MultiTenancy;

namespace Good.Framework.Platform.Routes
{
    public class UserRouteEto : IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public Guid RouteId { get; set; }
        public Guid UserId { get; set; }
    }
}
