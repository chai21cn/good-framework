using Volo.Abp.Domain.Entities;

namespace GoodFramework.Abp.TaskManagement;

public class BackgroundJobInfoUpdateDto : BackgroundJobInfoCreateOrUpdateDto, IHasConcurrencyStamp
{
    public string ConcurrencyStamp { get; set; }
}
