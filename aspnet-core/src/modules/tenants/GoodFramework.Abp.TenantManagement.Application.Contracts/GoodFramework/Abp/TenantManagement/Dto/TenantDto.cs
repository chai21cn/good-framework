using System;
using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.TenantManagement
{
    public class TenantDto : ExtensibleFullAuditedEntityDto<Guid>
    {
        public string Name { get; set; }
    }
}