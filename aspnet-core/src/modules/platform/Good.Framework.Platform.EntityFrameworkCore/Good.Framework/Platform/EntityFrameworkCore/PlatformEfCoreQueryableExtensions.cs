using Good.Framework.Platform.Datas;
using Good.Framework.Platform.Layouts;
using Good.Framework.Platform.Menus;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Good.Framework.Platform.EntityFrameworkCore
{
    public static class PlatformEfCoreQueryableExtensions
    {

        public static IQueryable<Layout> IncludeDetails(this IQueryable<Layout> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable;
        }

        public static IQueryable<Menu> IncludeDetails(this IQueryable<Menu> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable;
        }

        public static IQueryable<Data> IncludeDetails(this IQueryable<Data> queryable, bool include = true)
        {
            if (!include)
            {
                return queryable;
            }

            return queryable
                .AsSplitQuery()
                .Include(x => x.Items);
        }
    }
}
