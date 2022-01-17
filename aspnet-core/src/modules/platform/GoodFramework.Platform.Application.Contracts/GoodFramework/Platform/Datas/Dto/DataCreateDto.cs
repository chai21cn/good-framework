using System;

namespace GoodFramework.Platform.Datas
{
    public class DataCreateDto : DataCreateOrUpdateDto
    {
        public Guid? ParentId { get; set; }
    }
}
