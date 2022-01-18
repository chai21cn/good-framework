using GoodFramework.Abp.SettingManagement;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;

namespace GoodFramework.Abp.Tencent.SettingManagement;

[DependsOn(
    typeof(AbpTencentCloudModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpSettingManagementDomainModule),
    typeof(AbpAspNetCoreMvcModule))]
public class AbpTencentCloudSettingManagementModule : AbpModule
{

}