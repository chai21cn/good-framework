using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace GoodFramework.Abp.LocalizationManagement
{
    public interface ILanguageAppService : 
        ICrudAppService<
            LanguageDto,
            Guid,
            GetLanguagesInput,
            CreateOrUpdateLanguageInput,
            CreateOrUpdateLanguageInput
            >
    {
        Task<ListResultDto<LanguageDto>> GetAllAsync();
    }
}
