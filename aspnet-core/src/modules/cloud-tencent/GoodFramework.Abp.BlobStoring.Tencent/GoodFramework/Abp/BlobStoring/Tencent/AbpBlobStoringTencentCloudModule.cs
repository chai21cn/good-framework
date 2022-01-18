using GoodFramework.Abp.Tencent;
using Volo.Abp.BlobStoring;
using Volo.Abp.Modularity;

namespace GoodFramework.Abp.BlobStoring.Tencent;

[DependsOn(
    typeof(AbpBlobStoringModule),
    typeof(AbpTencentCloudModule))]
public class AbpBlobStoringTencentCloudModule : AbpModule
{
}