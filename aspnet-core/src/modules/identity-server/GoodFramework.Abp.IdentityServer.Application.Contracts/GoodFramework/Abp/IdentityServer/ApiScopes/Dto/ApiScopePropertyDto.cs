using System;
using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.IdentityServer.ApiScopes
{
    public class ApiScopePropertyDto : EntityDto<Guid>
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
