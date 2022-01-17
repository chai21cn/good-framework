using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoodFramework.Abp.BackgroundTasks;

public interface IJobStore
{
    Task<List<JobInfo>> GetWaitingListAsync(
        int maxResultCount,
        CancellationToken cancellationToken = default);

    Task<List<JobInfo>> GetAllPeriodTasksAsync(
        CancellationToken cancellationToken = default);

    Task<JobInfo> FindAsync(string jobId);

    Task StoreAsync(JobInfo jobInfo);

    Task StoreLogAsync(JobEventData eventData);

    Task CleanupAsync(
        int maxResultCount,
        TimeSpan jobExpiratime,
        CancellationToken cancellationToken = default);
}
