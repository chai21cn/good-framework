using System.Threading.Tasks;

namespace GoodFramework.Abp.AuditLogging.Elasticsearch
{
    public interface IIndexInitializer
    {
        Task InitializeAsync();
    }
}
