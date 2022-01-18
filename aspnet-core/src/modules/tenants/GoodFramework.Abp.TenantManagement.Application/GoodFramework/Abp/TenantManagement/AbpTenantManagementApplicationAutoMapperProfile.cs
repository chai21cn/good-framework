using AutoMapper;
using Volo.Abp.TenantManagement;

namespace GoodFramework.Abp.TenantManagement
{
    public class AbpTenantManagementApplicationAutoMapperProfile : Profile
    {
        public AbpTenantManagementApplicationAutoMapperProfile()
        {
            CreateMap<TenantConnectionString, TenantConnectionStringDto>();

            CreateMap<Tenant, TenantDto>()
                .MapExtraProperties();
        }
    }
}
