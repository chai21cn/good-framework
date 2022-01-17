using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodFramework.Abp.UI.Navigation
{
    public interface INavigationProvider
    {
        Task<IReadOnlyCollection<ApplicationMenu>> GetAllAsync();
    }
}
