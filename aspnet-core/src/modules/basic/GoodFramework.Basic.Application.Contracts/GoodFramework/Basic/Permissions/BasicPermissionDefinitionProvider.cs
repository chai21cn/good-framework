using GoodFramework.Basic.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace GoodFramework.Basic.Permissions;

public class BasicPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BasicPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(BasicPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BasicResource>(name);
    }
}
