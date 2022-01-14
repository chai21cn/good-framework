using AutoMapper;
using Good.Framework.Platform.Datas;
using Good.Framework.Platform.Layouts;
using Good.Framework.Platform.Menus;
using Good.Framework.Platform.Versions;

namespace Good.Framework.Platform
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
