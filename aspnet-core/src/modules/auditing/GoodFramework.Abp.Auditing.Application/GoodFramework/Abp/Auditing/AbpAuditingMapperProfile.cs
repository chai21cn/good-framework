using AutoMapper;
using GoodFramework.Abp.Auditing.AuditLogs;
using GoodFramework.Abp.Auditing.Logging;
using GoodFramework.Abp.Auditing.SecurityLogs;
using GoodFramework.Abp.AuditLogging;
using GoodFramework.Abp.Logging;

namespace GoodFramework.Abp.Auditing
{
    public class AbpAuditingMapperProfile : Profile
    {
        public AbpAuditingMapperProfile()
        {
            CreateMap<AuditLogAction, AuditLogActionDto>()
                .MapExtraProperties();
            CreateMap<EntityPropertyChange, EntityPropertyChangeDto>();
            CreateMap<EntityChange, EntityChangeDto>()
                .MapExtraProperties();
            CreateMap<AuditLog, AuditLogDto>()
                .MapExtraProperties();

            CreateMap<SecurityLog, SecurityLogDto>()
                .MapExtraProperties();

            CreateMap<LogField, LogFieldDto>();
            CreateMap<LogException, LogExceptionDto>();
            CreateMap<LogInfo, LogDto>();
        }
    }
}
