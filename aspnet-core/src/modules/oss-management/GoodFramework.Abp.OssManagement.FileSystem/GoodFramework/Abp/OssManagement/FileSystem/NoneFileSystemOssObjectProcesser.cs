using System.Threading.Tasks;

namespace GoodFramework.Abp.OssManagement.FileSystem
{
    public class NoneFileSystemOssObjectProcesser : IFileSystemOssObjectProcesserContributor
    {
        public Task ProcessAsync(FileSystemOssObjectContext context)
        {
            context.SetContent(context.OssObject.Content);

            return Task.CompletedTask;
        }
    }
}
