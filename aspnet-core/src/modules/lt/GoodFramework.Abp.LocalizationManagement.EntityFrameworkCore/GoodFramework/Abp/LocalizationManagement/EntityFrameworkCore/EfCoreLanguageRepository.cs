using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GoodFramework.Abp.LocalizationManagement.EntityFrameworkCore
{
    public class EfCoreLanguageRepository : EfCoreRepository<LocalizationDbContext, Language, Guid>,
        ILanguageRepository
    {
        public EfCoreLanguageRepository(
            IDbContextProvider<LocalizationDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<Language> FindByCultureNameAsync(
            string cultureName,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync()).Where(x => x.CultureName.Equals(cultureName))
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<Language>> GetActivedListAsync(CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync()).Where(x => x.Enable)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }
    }
}
