using GoodFramework.Abp.IdGenerator.Snowflake;

namespace GoodFramework.Abp.Serilog.Enrichers.UniqueId;

public class AbpSerilogEnrichersUniqueIdOptions
{
    public SnowflakeIdOptions SnowflakeIdOptions { get; set; }
    public AbpSerilogEnrichersUniqueIdOptions()
    {
        SnowflakeIdOptions = new SnowflakeIdOptions();
    }
}
