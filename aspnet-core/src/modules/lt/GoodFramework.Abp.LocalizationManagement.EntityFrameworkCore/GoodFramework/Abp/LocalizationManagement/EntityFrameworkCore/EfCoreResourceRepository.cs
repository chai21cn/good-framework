using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GoodFramework.Abp.LocalizationManagement.EntityFrameworkCore
{
    public class EfCoreResourceRepository : EfCoreRepository<LocalizationDbContext, Resource, Guid>,
        IResourceRepository
    {
        public EfCoreResourceRepository(
            IDbContextProvider<LocalizationDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<bool> ExistsAsync(
            string name, 
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync()).AnyAsync(x => x.Name.Equals(name));
        }

        public virtual async Task<Resource> FindByNameAsync(
            string name, 
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync()).Where(x => x.Name.Equals(name))
              .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }
    }
}
