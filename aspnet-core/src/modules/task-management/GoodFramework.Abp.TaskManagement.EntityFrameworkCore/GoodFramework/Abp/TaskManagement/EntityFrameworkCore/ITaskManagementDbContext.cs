using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace GoodFramework.Abp.TaskManagement.EntityFrameworkCore;

[ConnectionStringName(TaskManagementDbProperties.ConnectionStringName)]
public interface ITaskManagementDbContext :IEfCoreDbContext
{
}
