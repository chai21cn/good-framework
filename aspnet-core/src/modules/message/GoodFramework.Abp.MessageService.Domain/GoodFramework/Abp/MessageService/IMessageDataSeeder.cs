using System;
using System.Threading.Tasks;

namespace GoodFramework.Abp.MessageService
{
    public interface IMessageDataSeeder
    {
        Task SeedAsync(Guid? tenantId = null);
    }
}
