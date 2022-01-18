using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace GoodFramework.Abp.LocalizationManagement
{
    public interface ITextAppService : 
        ICrudAppService<
            TextDto,
            TextDifferenceDto,
            int,
            GetTextsInput,
            CreateTextInput,
            UpdateTextInput>
    {
        Task<TextDto> GetByCultureKeyAsync(GetTextByKeyInput input);
    }
}
