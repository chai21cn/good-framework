namespace GoodFramework.Abp.UI.Navigation
{
    public class NavigationDefinition
    {
        public ApplicationMenu Menu { get; }
        public NavigationDefinition(ApplicationMenu menu)
        {
            Menu = menu;
        }
    }
}
