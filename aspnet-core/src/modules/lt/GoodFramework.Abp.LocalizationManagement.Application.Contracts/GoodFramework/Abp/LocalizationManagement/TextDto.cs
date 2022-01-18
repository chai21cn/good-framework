using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.LocalizationManagement
{
    public class TextDto : EntityDto<int>
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string CultureName { get; set; }
        public string ResourceName { get; set; }
    }
}
