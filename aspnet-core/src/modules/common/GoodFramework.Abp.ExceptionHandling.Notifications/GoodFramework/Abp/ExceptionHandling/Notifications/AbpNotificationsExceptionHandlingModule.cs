using GoodFramework.Abp.ExceptionHandling.Localization;
using GoodFramework.Abp.Notifications;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace GoodFramework.Abp.ExceptionHandling.Notifications
{
    [DependsOn(
        typeof(AbpExceptionHandlingModule),
        typeof(AbpNotificationModule))]
    public class AbpNotificationsExceptionHandlingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpNotificationsExceptionHandlingModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<ExceptionHandlingResource>()
                    .AddVirtualJson("/GoodFramework/Abp/ExceptionHandling/Notifications/Localization/Resources");
            });
        }
    }
}
