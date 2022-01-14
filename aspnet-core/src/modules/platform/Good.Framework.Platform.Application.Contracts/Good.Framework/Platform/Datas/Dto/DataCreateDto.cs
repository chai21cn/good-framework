using System;

namespace Good.Framework.Platform.Datas
{
    public class DataCreateDto : DataCreateOrUpdateDto
    {
        public Guid? ParentId { get; set; }
    }
}
