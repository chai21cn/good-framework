using GoodFramework.Abp.MessageService.Chat;
using GoodFramework.Abp.MessageService.Groups;
using GoodFramework.Abp.MessageService.Notifications;
using GoodFramework.Abp.MessageService.Subscriptions;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace GoodFramework.Abp.MessageService.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpMessageServiceDomainModule),
        typeof(AbpEntityFrameworkCoreModule))]
    public class AbpMessageServiceEntityFrameworkCoreModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context) {
            MessageServiceEfCoreEntityExtensionMappings.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MessageServiceDbContext>(options =>
            {
                options.AddRepository<Notification, EfCoreNotificationRepository>();
                options.AddRepository<UserNotification, EfCoreUserNotificationRepository>();
                options.AddRepository<UserSubscribe, EfCoreUserSubscribeRepository>();

                options.AddRepository<ChatGroup, EfCoreGroupRepository>();
                options.AddRepository<UserChatGroup, EfCoreUserChatGroupRepository>();
                options.AddRepository<UserChatCard, EfCoreUserChatCardRepository>();
                options.AddRepository<UserChatSetting, EfCoreUserChatSettingRepository>();

                options.AddRepository<UserChatFriend, EfCoreUserChatFriendRepository>();

                options.AddDefaultRepositories(includeAllEntities: true);
            });
        }
    }
}
