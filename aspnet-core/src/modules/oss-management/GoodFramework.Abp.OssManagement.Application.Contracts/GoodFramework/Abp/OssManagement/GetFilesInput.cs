using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.OssManagement
{
    public class GetFilesInput: LimitedResultRequestDto
    {
        public string Filter { get; set; }
        public string Path { get; set; }
    }
}
