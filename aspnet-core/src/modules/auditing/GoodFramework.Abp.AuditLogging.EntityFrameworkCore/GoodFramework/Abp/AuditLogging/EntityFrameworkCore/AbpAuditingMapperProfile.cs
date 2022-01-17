using AutoMapper;

namespace GoodFramework.Abp.AuditLogging.EntityFrameworkCore
{
    public class AbpAuditingMapperProfile : Profile
    {
        public AbpAuditingMapperProfile()
        {
            CreateMap<Volo.Abp.AuditLogging.AuditLogAction, GoodFramework.Abp.AuditLogging.AuditLogAction>()
                .MapExtraProperties();
            CreateMap<Volo.Abp.AuditLogging.EntityPropertyChange, GoodFramework.Abp.AuditLogging.EntityPropertyChange>();
            CreateMap<Volo.Abp.AuditLogging.EntityChange, GoodFramework.Abp.AuditLogging.EntityChange>()
                .MapExtraProperties();
            CreateMap<Volo.Abp.AuditLogging.AuditLog, GoodFramework.Abp.AuditLogging.AuditLog>()
                .MapExtraProperties();

            CreateMap<Volo.Abp.Identity.IdentitySecurityLog, GoodFramework.Abp.AuditLogging.SecurityLog>()
                .MapExtraProperties();
        }
    }
}
