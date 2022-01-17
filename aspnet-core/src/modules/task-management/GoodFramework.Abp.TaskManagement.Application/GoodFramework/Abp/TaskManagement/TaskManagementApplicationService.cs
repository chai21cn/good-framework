using GoodFramework.Abp.TaskManagement.Localization;
using Volo.Abp.Application.Services;

namespace GoodFramework.Abp.TaskManagement;

public abstract class TaskManagementApplicationService : ApplicationService
{
    protected TaskManagementApplicationService()
    {
        LocalizationResource = typeof(TaskManagementResource);
        ObjectMapperContext = typeof(TaskManagementApplicationModule);
    }
}
