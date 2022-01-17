using Volo.Abp.Application.Dtos;

namespace GoodFramework.Platform.Datas
{
    public class GetDataListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
