using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.TenantManagement;

namespace GoodFramework.Abp.MultiTenancy.RemoteService.EventBus.Distributed
{
    public class TenantDeleteEventHandler : IDistributedEventHandler<EntityDeletedEto<TenantEto>>, ITransientDependency
    {
        private readonly IDistributedCache<TenantConfigurationCacheItem> _cache;

        public TenantDeleteEventHandler(
            IDistributedCache<TenantConfigurationCacheItem> cache)
        {
            _cache = cache;
        }

        public virtual async Task HandleEventAsync(EntityDeletedEto<TenantEto> eventData)
        {
            await _cache.RemoveAsync(
                 TenantConfigurationCacheItem.CalculateCacheKey(eventData.Entity.Id.ToString()));

            await _cache.RemoveAsync(
                TenantConfigurationCacheItem.CalculateCacheKey(eventData.Entity.Name));
        }
    }
}
