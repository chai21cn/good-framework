using System.Threading.Tasks;

namespace GoodFramework.Abp.OssManagement
{
    public interface IFileValidater
    {
        Task ValidationAsync(UploadFile input);
    }
}
