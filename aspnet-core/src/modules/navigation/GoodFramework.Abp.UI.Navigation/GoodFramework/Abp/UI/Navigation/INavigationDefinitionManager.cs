using System.Collections.Generic;

namespace GoodFramework.Abp.UI.Navigation
{
    public interface INavigationDefinitionManager
    {
        IReadOnlyList<NavigationDefinition> GetAll();
    }
}
