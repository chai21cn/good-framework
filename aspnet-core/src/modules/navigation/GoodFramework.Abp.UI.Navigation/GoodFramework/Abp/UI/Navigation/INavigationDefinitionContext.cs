namespace GoodFramework.Abp.UI.Navigation
{
    public interface INavigationDefinitionContext
    {
        void Add(params NavigationDefinition[] definitions);
    }
}
