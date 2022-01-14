using Good.Framework.Platform.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Good.Framework.Platform.Menus
{
    public class EfCoreUserMenuRepository : EfCoreRepository<PlatformDbContext, UserMenu, Guid>, IUserMenuRepository
    {
        public EfCoreUserMenuRepository(
            IDbContextProvider<PlatformDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }

        public virtual async Task<bool> UserHasInMenuAsync(
            Guid userId, 
            string menuName, 
            CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();
            return await
                (from userMenu in dbContext.Set<UserMenu>()
                 join menu in dbContext.Set<Menu>()
                      on userMenu.MenuId equals menu.Id
                 where userMenu.UserId.Equals(userId)
                 select menu)
                 .AnyAsync(
                    x => x.Name.Equals(menuName),
                    GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<UserMenu>> GetListByUserIdAsync(
            Guid userId,
            CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.Where(x => x.UserId.Equals(userId))
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task InsertAsync(IEnumerable<UserMenu> userMenus, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();
            await dbSet.AddRangeAsync(userMenus, GetCancellationToken(cancellationToken));
        }
    }
}
