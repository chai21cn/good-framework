using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace GoodFramework.Abp.TaskManagement;

[DependsOn(typeof(TaskManagementDomainSharedModule))]
[DependsOn(typeof(AbpDddApplicationContractsModule))]
public class TaskManagementApplicationContractsModule : AbpModule
{
}
