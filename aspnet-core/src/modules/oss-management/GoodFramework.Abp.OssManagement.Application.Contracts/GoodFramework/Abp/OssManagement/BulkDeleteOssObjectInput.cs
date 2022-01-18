using System.ComponentModel.DataAnnotations;

namespace GoodFramework.Abp.OssManagement
{
    public class BulkDeleteOssObjectInput
    {
        [Required]
        public string Bucket { get; set; }

        public string Path { get; set; }

        [Required]
        public string[] Objects { get; set; }
    }
}
