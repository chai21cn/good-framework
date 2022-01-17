using AutoMapper;
using GoodFramework.Abp.BackgroundTasks;

namespace GoodFramework.Abp.TaskManagement;

public class TaskManagementDomainMapperProfile : Profile
{
    public TaskManagementDomainMapperProfile()
    {
        CreateMap<BackgroundJobInfo, JobInfo>();
    }
}
