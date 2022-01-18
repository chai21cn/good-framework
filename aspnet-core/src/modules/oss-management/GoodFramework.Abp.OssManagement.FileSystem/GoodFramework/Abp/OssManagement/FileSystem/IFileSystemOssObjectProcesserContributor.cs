using System.Threading.Tasks;

namespace GoodFramework.Abp.OssManagement.FileSystem
{
    public interface IFileSystemOssObjectProcesserContributor
    {
        Task ProcessAsync(FileSystemOssObjectContext context);
    }
}
