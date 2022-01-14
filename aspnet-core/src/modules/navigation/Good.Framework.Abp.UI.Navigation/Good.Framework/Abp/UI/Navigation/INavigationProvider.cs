using System.Collections.Generic;
using System.Threading.Tasks;

namespace Good.Framework.Abp.UI.Navigation
{
    public interface INavigationProvider
    {
        Task<IReadOnlyCollection<ApplicationMenu>> GetAllAsync();
    }
}
