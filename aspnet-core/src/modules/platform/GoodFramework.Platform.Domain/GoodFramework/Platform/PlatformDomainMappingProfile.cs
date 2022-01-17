using AutoMapper;
using GoodFramework.Platform.Routes;
using GoodFramework.Platform.Versions;

namespace GoodFramework.Platform
{
    public class PlatformDomainMappingProfile : Profile
    {
        public PlatformDomainMappingProfile()
        {
            CreateMap<Route, RouteEto>();

            CreateMap<AppVersion, AppVersionEto>()
                .ForMember(eto => eto.FileCount, map => map.MapFrom(src => src.Files.Count));
        }
    }
}
