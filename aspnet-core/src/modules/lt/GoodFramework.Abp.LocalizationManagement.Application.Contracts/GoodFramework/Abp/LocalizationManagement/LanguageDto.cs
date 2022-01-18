using System;
using Volo.Abp.Application.Dtos;

namespace GoodFramework.Abp.LocalizationManagement
{
    public class LanguageDto : AuditedEntityDto<Guid>
    {
        public bool Enable { get; set; }
        public string CultureName { get; set; }
        public string UiCultureName { get; set; }
        public string DisplayName { get; set; }
        public string FlagIcon { get; set; }
    }
}
