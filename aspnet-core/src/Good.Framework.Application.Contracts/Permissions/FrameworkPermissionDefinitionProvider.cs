using Good.Framework.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Good.Framework.Permissions
{
    public class FrameworkPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(FrameworkPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(FrameworkPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<FrameworkResource>(name);
        }
    }
}
