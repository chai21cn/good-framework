using Volo.Abp.BlobStoring;

namespace GoodFramework.Abp.BlobStoring.Tencent
{
    public interface ITencentBlobNameCalculator
    {
        string Calculate(BlobProviderArgs args);
    }
}
