using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace GoodFramework.Abp.LocalizationManagement
{
    public interface ILanguageRepository : IRepository<Language, Guid>
    {
        Task<Language> FindByCultureNameAsync(
            string cultureName,
            CancellationToken cancellationToken = default);

        Task<List<Language>> GetActivedListAsync(CancellationToken cancellationToken = default);
    }
}
