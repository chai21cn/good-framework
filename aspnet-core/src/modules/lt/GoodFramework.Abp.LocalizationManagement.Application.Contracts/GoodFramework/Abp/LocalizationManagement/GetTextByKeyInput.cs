using System.ComponentModel.DataAnnotations;
using Volo.Abp.Validation;

namespace GoodFramework.Abp.LocalizationManagement
{
    public class GetTextByKeyInput
    {
        [Required]
        [DynamicStringLength(typeof(TextConsts), nameof(TextConsts.MaxKeyLength))]
        public string Key { get; set; }

        [Required]
        [DynamicStringLength(typeof(LanguageConsts), nameof(LanguageConsts.MaxCultureNameLength))]
        public string CultureName { get; set; }

        [Required]
        [DynamicStringLength(typeof(ResourceConsts), nameof(ResourceConsts.MaxNameLength))]
        public string ResourceName { get; set; }
    }
}
