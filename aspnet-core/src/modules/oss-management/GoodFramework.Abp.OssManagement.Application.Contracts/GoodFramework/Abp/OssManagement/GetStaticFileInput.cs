using System.ComponentModel.DataAnnotations;

namespace GoodFramework.Abp.OssManagement
{
    public class GetStaticFileInput
    {
        [Required]
        public string Name { get; set; }

        public string Path { get; set; }

        public string Bucket { get; set; }

        public string Process { get; set; }
    }
}
