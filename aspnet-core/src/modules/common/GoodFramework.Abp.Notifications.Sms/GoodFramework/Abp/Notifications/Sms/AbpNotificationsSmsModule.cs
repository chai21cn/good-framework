using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.Sms;

namespace GoodFramework.Abp.Notifications.Sms
{
    [DependsOn(
        typeof(AbpNotificationModule),
        typeof(AbpSmsModule))]
    public class AbpNotificationsSmsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var preSmsActions = context.Services.GetPreConfigureActions<AbpNotificationsSmsOptions>();
            Configure<AbpNotificationsSmsOptions>(options =>
            {
                preSmsActions.Configure(options);
            });

            Configure<AbpNotificationOptions>(options =>
            {
                options.PublishProviders.Add<SmsNotificationPublishProvider>();

                var smsOptions = preSmsActions.Configure();

                options.NotificationDataMappings
                       .MappingDefault(
                            SmsNotificationPublishProvider.ProviderName,
                            data => NotificationData.ToStandardData(smsOptions.TemplateParamsPrefix, data));
            });
        }
    }
}
