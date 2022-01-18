using System;

namespace GoodFramework.Abp.MultiTenancy
{
    public class ConnectionStringCreatedEventData
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
