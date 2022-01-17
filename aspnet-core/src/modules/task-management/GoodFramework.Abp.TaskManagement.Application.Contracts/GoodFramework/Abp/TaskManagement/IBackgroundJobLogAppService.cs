using Volo.Abp.Application.Services;

namespace GoodFramework.Abp.TaskManagement;

public interface IBackgroundJobLogAppService : 
    IReadOnlyAppService<
        BackgroundJobLogDto,
        long,
        BackgroundJobLogGetListInput>,
    IDeleteAppService<long>
{
}
