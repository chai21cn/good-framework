using AutoMapper;

namespace GoodFramework.Abp.LocalizationManagement
{
    public class LocalizationManagementDomainMapperProfile : Profile
    {
        public LocalizationManagementDomainMapperProfile()
        {
            CreateMap<Text, TextEto>();
        }
    }
}
