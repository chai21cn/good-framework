using IdentityServer4.Models;
using System.Collections.Generic;

namespace GoodFramework.Abp.IdentityServer.IdentityResources
{
    public class CustomIdentityResourceDataSeederOptions
    {
        public IList<IdentityResource> Resources { get; }
        public CustomIdentityResourceDataSeederOptions()
        {
            Resources = new List<IdentityResource>();
        }
    }
}
