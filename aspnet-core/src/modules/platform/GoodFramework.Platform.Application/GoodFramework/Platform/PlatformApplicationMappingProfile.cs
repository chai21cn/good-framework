using AutoMapper;
using GoodFramework.Platform.Datas;
using GoodFramework.Platform.Layouts;
using GoodFramework.Platform.Menus;
using GoodFramework.Platform.Versions;

namespace GoodFramework.Platform
{
    public class PlatformApplicationMappingProfile : Profile
    {
        public PlatformApplicationMappingProfile()
        {
            CreateMap<VersionFile, VersionFileDto>();
            CreateMap<AppVersion, VersionDto>();

            CreateMap<DataItem, DataItemDto>();
            CreateMap<Data, DataDto>();
            CreateMap<Menu, MenuDto>()
                .ForMember(dto => dto.Meta, map => map.MapFrom(src => src.ExtraProperties));
            CreateMap<Layout, LayoutDto>()
                .ForMember(dto => dto.Meta, map => map.MapFrom(src => src.ExtraProperties));
        }
    }
}
