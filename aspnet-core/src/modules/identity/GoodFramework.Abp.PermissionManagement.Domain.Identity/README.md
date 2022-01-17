# GoodFramework.Abp.PermissionManagement.Domain.Identity

重写 **GoodFramework.Abp.PermissionManagement.Domain**

当查询用户权限时,先获取用户角色组权限

#### 注意

此模块已经引用 **Volo.Abp.PermissionManagement.Identity.AbpPermissionManagementDomainIdentityModule** 无需再次引用

## 配置使用


```csharp
[DependsOn(typeof(GoodFramework.Abp.PermissionManagement.Identity.AbpPermissionManagementDomainIdentityModule))]
public class YouProjectModule : AbpModule
{
  // other
}
