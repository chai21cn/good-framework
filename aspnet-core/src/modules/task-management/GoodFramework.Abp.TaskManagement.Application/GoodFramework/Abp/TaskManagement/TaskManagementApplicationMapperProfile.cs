using AutoMapper;

namespace GoodFramework.Abp.TaskManagement;

public class TaskManagementApplicationMapperProfile : Profile
{
    public TaskManagementApplicationMapperProfile()
    {
        CreateMap<BackgroundJobInfo, BackgroundJobInfoDto>();
        CreateMap<BackgroundJobLog, BackgroundJobLogDto>();
    }
}
