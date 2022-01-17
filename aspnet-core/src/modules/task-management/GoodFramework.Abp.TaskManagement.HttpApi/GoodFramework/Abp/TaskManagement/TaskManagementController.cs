using GoodFramework.Abp.TaskManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace GoodFramework.Abp.TaskManagement;

public abstract class TaskManagementController : AbpControllerBase
{
    protected TaskManagementController()
    {
        LocalizationResource = typeof(TaskManagementResource);
    }
}
