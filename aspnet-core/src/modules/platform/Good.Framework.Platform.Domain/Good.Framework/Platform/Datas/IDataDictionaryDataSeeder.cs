using System;
using System.Threading;
using System.Threading.Tasks;

namespace Good.Framework.Platform.Datas
{
    public interface IDataDictionaryDataSeeder
    {
        Task<Data> SeedAsync(
            string name,
            string code,
            string displayName,
            string description = "",
            Guid? parentId = null,
            Guid? tenantId = null,
            bool isStatic = false,
            CancellationToken cancellationToken = default);
    }
}
