using Volo.Abp.Application.Dtos;

namespace Good.Framework.Platform.Datas
{
    public class GetDataListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
