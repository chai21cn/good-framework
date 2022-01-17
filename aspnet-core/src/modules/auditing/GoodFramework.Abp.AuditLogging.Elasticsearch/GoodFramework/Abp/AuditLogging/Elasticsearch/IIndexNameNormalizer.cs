namespace GoodFramework.Abp.AuditLogging.Elasticsearch
{
    public interface IIndexNameNormalizer
    {
        string NormalizeIndex(string index);
    }
}
