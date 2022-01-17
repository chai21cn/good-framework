using GoodFramework.Abp.IdGenerator;
using Serilog.Core;
using Serilog.Events;

namespace GoodFramework.Abp.Serilog.Enrichers.UniqueId
{
    public class UniqueIdEnricher : ILogEventEnricher
    {
        internal static IDistributedIdGenerator DistributedIdGenerator;

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            logEvent.AddOrUpdateProperty(
                propertyFactory.CreateProperty(
                    AbpSerilogUniqueIdConsts.UniqueIdPropertyName,
                    DistributedIdGenerator.Create()));
        }
    }
}
