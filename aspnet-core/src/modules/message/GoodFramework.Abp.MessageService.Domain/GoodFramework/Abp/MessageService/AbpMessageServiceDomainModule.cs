using GoodFramework.Abp.MessageService.Chat;
using GoodFramework.Abp.MessageService.Localization;
using GoodFramework.Abp.MessageService.Mapper;
using GoodFramework.Abp.MessageService.ObjectExtending;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace GoodFramework.Abp.MessageService
{
    [DependsOn(
        typeof(AbpAutoMapperModule),
        typeof(AbpCachingModule),
        typeof(AbpMessageServiceDomainSharedModule))]
    public class AbpMessageServiceDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<MessageServiceDomainAutoMapperProfile>(validate: true);
            });
        }

        public override void PostConfigureServices(ServiceConfigurationContext context)
        {
            ModuleExtensionConfigurationHelper.ApplyEntityConfigurationToEntity(
                MessageServiceModuleExtensionConsts.ModuleName,
                MessageServiceModuleExtensionConsts.EntityNames.Message,
                typeof(Message)
            );
        }
    }
}
