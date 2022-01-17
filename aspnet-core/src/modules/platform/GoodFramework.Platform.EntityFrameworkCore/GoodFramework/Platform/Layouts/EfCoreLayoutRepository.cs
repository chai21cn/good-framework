using GoodFramework.Platform.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace GoodFramework.Platform.Layouts
{
    public class EfCoreLayoutRepository : EfCoreRepository<PlatformDbContext, Layout, Guid>, ILayoutRepository
    {
        public EfCoreLayoutRepository(IDbContextProvider<PlatformDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public virtual async Task<Layout> FindByNameAsync(
            string name,
            bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetails)
                .Where(x => x.Name == name)
                .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<int> GetCountAsync(
            string framework = "",
            string filter = "", 
            CancellationToken cancellationToken = default)
        {
            return await (await GetDbSetAsync())
                .WhereIf(!framework.IsNullOrWhiteSpace(), x => x.Framework.Equals(framework))
                .WhereIf(!filter.IsNullOrWhiteSpace(), x =>
                        x.Name.Contains(filter) || x.DisplayName.Contains(filter) ||
                        x.Description.Contains(filter) || x.Redirect.Contains(filter))
                .CountAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<Layout>> GetPagedListAsync(
            string framework = "",
            string filter = "",
            string sorting = nameof(Layout.Name),
            bool reverse = false,
            bool includeDetails = false, 
            int skipCount = 0, 
            int maxResultCount = 10,
            CancellationToken cancellationToken = default)
        {
            sorting ??= nameof(Layout.Name);
            sorting = reverse ? sorting + " DESC" : sorting;

            return await (await GetDbSetAsync())
                .IncludeDetails(includeDetails)
                .WhereIf(!framework.IsNullOrWhiteSpace(), x => x.Framework.Equals(framework))
                .WhereIf(!filter.IsNullOrWhiteSpace(), x =>
                        x.Name.Contains(filter) || x.DisplayName.Contains(filter) ||
                        x.Description.Contains(filter) || x.Redirect.Contains(filter))
                .OrderBy(sorting)
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public override async Task<IQueryable<Layout>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }

        [System.Obsolete("将在abp框架移除之后删除")]
        public override IQueryable<Layout> WithDetails()
        {
            return GetQueryable().IncludeDetails();
        }
    }
}
