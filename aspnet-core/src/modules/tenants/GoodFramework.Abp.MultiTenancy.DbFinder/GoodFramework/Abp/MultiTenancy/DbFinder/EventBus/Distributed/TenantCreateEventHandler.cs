using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;
using Volo.Abp.Uow;

namespace GoodFramework.Abp.MultiTenancy.DbFinder.EventBus.Distributed
{
    public class TenantCreateEventHandler : IDistributedEventHandler<EntityCreatedEto<TenantEto>>, ITransientDependency
    {
        private readonly ILogger<TenantCreateEventHandler> _logger;
        private readonly ICurrentTenant _currentTenant;
        private readonly ITenantRepository _tenantRepository;
        private readonly IDistributedCache<TenantConfigurationCacheItem> _cache;

        public TenantCreateEventHandler(
            ICurrentTenant currentTenant,
            ITenantRepository tenantRepository,
            ILogger<TenantCreateEventHandler> logger,
            IDistributedCache<TenantConfigurationCacheItem> cache)
        {
            _cache = cache;
            _logger = logger;
            _currentTenant = currentTenant;
            _tenantRepository = tenantRepository;
        }

        [UnitOfWork]
        public virtual async Task HandleEventAsync(EntityCreatedEto<TenantEto> eventData)
        {
            try
            {
                using (_currentTenant.Change(null))
                {
                    var tenant = await _tenantRepository.FindAsync(eventData.Entity.Id, true);
                    if (tenant == null)
                    {
                        return;
                    }
                    var connectionStrings = new ConnectionStrings();
                    foreach (var tenantConnectionString in tenant.ConnectionStrings)
                    {
                        connectionStrings[tenantConnectionString.Name] = tenantConnectionString.Value;
                    }
                    var cacheItem = new TenantConfigurationCacheItem(tenant.Id, tenant.Name, connectionStrings);

                    await _cache.SetAsync(
                        TenantConfigurationCacheItem.CalculateCacheKey(eventData.Entity.Id.ToString()),
                        cacheItem);

                    await _cache.SetAsync(
                        TenantConfigurationCacheItem.CalculateCacheKey(eventData.Entity.Name),
                        cacheItem);
                }
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
        }
    }
}
