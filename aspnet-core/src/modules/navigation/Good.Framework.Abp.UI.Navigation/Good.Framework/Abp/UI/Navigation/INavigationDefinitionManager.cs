using System.Collections.Generic;

namespace Good.Framework.Abp.UI.Navigation
{
    public interface INavigationDefinitionManager
    {
        IReadOnlyList<NavigationDefinition> GetAll();
    }
}
