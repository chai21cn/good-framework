using Volo.Abp.BlobStoring;

namespace GoodFramework.Abp.BlobStoring.Aliyun
{
    public interface IAliyunBlobNameCalculator
    {
        string Calculate(BlobProviderArgs args);
    }
}
