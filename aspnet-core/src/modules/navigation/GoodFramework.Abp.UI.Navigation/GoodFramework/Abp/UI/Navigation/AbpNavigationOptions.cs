using Volo.Abp.Collections;

namespace GoodFramework.Abp.UI.Navigation
{
    public class AbpNavigationOptions
    {
        public ITypeList<INavigationDefinitionProvider> DefinitionProviders { get; }

        public ITypeList<INavigationSeedContributor> NavigationSeedContributors { get; }

        public AbpNavigationOptions()
        {
            DefinitionProviders = new TypeList<INavigationDefinitionProvider>();
            NavigationSeedContributors = new TypeList<INavigationSeedContributor>();
        }
    }
}
