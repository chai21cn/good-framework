using System.ComponentModel.DataAnnotations;

namespace Good.Framework.Platform.Versions
{
    public class VersionDeleteDto
    {
        [Required]
        [StringLength(AppVersionConsts.MaxVersionLength)]
        public string Version { get; set; }

        public PlatformType PlatformType { get; set; }
    }
}
