using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace GoodFramework.Abp.MessageService
{
    [Dependency(TryRegister = true)]
    public class NullMessageDataSeeder : IMessageDataSeeder, ISingletonDependency
    {
        public Task SeedAsync(Guid? tenantId = null)
        {
            return Task.CompletedTask;
        }
    }
}
