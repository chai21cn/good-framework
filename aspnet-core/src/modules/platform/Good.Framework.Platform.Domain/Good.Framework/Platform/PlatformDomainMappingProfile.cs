using AutoMapper;
using Good.Framework.Platform.Routes;
using Good.Framework.Platform.Versions;

namespace Good.Framework.Platform
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
