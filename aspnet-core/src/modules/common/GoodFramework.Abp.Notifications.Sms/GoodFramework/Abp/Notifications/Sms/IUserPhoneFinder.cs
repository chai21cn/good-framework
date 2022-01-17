using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GoodFramework.Abp.Notifications.Sms
{
    public interface IUserPhoneFinder
    {
        Task<IEnumerable<string>> FindByUserIdsAsync(
            IEnumerable<Guid> userIds,
            CancellationToken cancellation = default);
    }
}
