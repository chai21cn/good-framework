using GoodFramework.Abp.Aliyun.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace GoodFramework.Abp.Aliyun.SettingManagement
{
    public class AliyunSettingPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var wechatGroup = context.AddGroup(
                AliyunSettingPermissionNames.GroupName,
                L("Permission:Aliyun"));

            wechatGroup.AddPermission(
                AliyunSettingPermissionNames.Settings, L("Permission:Aliyun.Settings"));
        }

        protected LocalizableString L(string name)
        {
            return LocalizableString.Create<AliyunResource>(name);
        }
    }
}
