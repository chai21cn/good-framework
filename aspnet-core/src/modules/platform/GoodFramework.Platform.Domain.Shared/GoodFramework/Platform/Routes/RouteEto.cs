using System;
using Volo.Abp.MultiTenancy;

namespace GoodFramework.Platform.Routes
{
    public class RouteEto : IMultiTenant
    {
        public Guid? TenantId { get; set; }
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Redirect { get; set; }
    }
}
