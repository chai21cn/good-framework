using Volo.Abp.Settings;

namespace Good.Framework.Settings
{
    public class FrameworkSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(FrameworkSettings.MySetting1));
        }
    }
}
