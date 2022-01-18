using GoodFramework.Abp.OssManagement;
using Volo.Abp.BlobStoring;
using Volo.Abp.Modularity;

namespace GoodFramework.Abp.BlobStoring.OssManagement
{
    [DependsOn(typeof(AbpBlobStoringModule))]
    [DependsOn(typeof(AbpOssManagementHttpApiClientModule))]
    public class AbpBlobStoringOssManagementModule : AbpModule
    {
    }
}
