using GoodFramework.Abp.Auditing;
using GoodFramework.Abp.Identity;
using GoodFramework.Abp.Identity.EntityFrameworkCore;
using GoodFramework.Abp.IdentityServer;
using GoodFramework.Abp.IdentityServer.EntityFrameworkCore;
using GoodFramework.Abp.IdentityServer.WeChat;
using GoodFramework.Abp.Localization.CultureMap;
using GoodFramework.Abp.LocalizationManagement;
using GoodFramework.Abp.LocalizationManagement.EntityFrameworkCore;
using GoodFramework.Abp.OssManagement;
using GoodFramework.Abp.OssManagement.FileSystem;
using GoodFramework.Abp.OssManagement.FileSystem.ImageSharp;
using GoodFramework.Abp.OssManagement.SettingManagement;
using GoodFramework.Abp.Serilog.Enrichers.Application;
using GoodFramework.Abp.Serilog.Enrichers.UniqueId;
using GoodFramework.Abp.SettingManagement;
using GoodFramework.Abp.TenantManagement;
using GoodFramework.Basic;
using GoodFramework.Basic.EntityFrameworkCore;
using GoodFramework.Basic.MultiTenancy;
using GoodFramework.Platform;
using GoodFramework.Platform.EntityFrameworkCore;
using GoodFramework.Platform.HttpApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Basic.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.FileSystem;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.Localization;
using Volo.Abp.Json;
using Volo.Abp.Json.SystemTextJson;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;

namespace GoodFramework
{
    [DependsOn(
        // ??????
        typeof(BasicHttpApiModule),
        typeof(BasicApplicationModule),
        typeof(BasicEntityFrameworkCoreModule),
        // ??????????????????
        typeof(PlatformHttpApiModule),
        typeof(PlatformApplicationModule),
        typeof(PlatformEntityFrameworkCoreModule),
        // LocalizationManagement
        typeof(AbpLocalizationManagementHttpApiModule),
        typeof(AbpLocalizationManagementApplicationModule),
        typeof(AbpLocalizationManagementEntityFrameworkCoreModule),
        // Account
        typeof(AbpAccountHttpApiModule),
        typeof(AbpAccountApplicationModule),
        // AbpIdentity
        typeof(AbpIdentityHttpApiModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),
        // AbpIdentityServer
        typeof(AbpIdentityServerSmsValidatorModule),
        typeof(AbpIdentityServerWeChatModule),
        typeof(AbpIdentityServerEntityFrameworkCoreModule),
        // ????????????
        //typeof(AbpBackgroundTasksJobsModule),
        //typeof(AbpBackgroundTasksQuartzModule),
        //typeof(AbpBackgroundTasksExceptionHandlingModule),
        //typeof(TaskManagementHttpApiModule),
        //typeof(TaskManagementApplicationModule),
        //typeof(TaskManagementEntityFrameworkCoreModule),
        // MessageService
        //typeof(AbpIMSignalRModule),
        //typeof(AbpMessageServiceApplicationModule),
        //typeof(AbpMessageServiceHttpApiModule),
        //typeof(AbpMessageServiceEntityFrameworkCoreModule),
        // Notifications
        //typeof(AbpNotificationsSmsModule),
        //typeof(AbpNotificationsSignalRModule),
        //typeof(AbpNotificationsWeChatMiniProgramModule),
        //typeof(AbpNotificationsExceptionHandlingModule),
        // OSS??????
        //typeof(AbpOssManagementAliyunModule),
        typeof(AbpOssManagementFileSystemModule),           // ?????????????????????????????????
        typeof(AbpOssManagementFileSystemImageSharpModule), // ????????????????????????????????????
        typeof(AbpOssManagementApplicationModule),
        typeof(AbpOssManagementHttpApiModule),
        typeof(AbpOssManagementSettingManagementModule),
        // TenantManagement
        typeof(AbpTenantManagementApplicationModule),
        typeof(AbpTenantManagementHttpApiModule),
        // ??????
        typeof(AbpSettingManagementHttpApiModule),
        typeof(AbpSettingManagementApplicationModule),
        // ??????
        typeof(AbpAuditingApplicationModule),
        typeof(AbpAuditingHttpApiModule),
        // ??????
        typeof(AbpSerilogEnrichersApplicationModule),
        typeof(AbpSerilogEnrichersUniqueIdModule),
        typeof(AbpAspNetCoreSerilogModule),
        // typeof(AbpLoggingSerilogElasticsearchModule),
        // typeof(AbpAuditLoggingElasticsearchModule),
        // ABP??????
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreMultiTenancyModule),
        typeof(AbpAspNetCoreMvcUiBasicThemeModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpAccountWebIdentityServerModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpSwashbuckleModule)
    )]
    public class GoodFrameworkHttpApiHostModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            ConfigureBundles();
            ConfigureUrls(configuration);
            ConfigureConventionalControllers();
            ConfigureAuthentication(context, configuration);
            ConfigureLocalization();
            ConfigureVirtualFileSystem(context);
            ConfigureCors(context, configuration);
            ConfigureSwaggerServices(context, configuration);

            ConfigureDbContext();
            ConfigureBlobStoring();
            ConfigureJsonSerializer();
        }

        private void ConfigureBundles()
        {
            Configure<AbpBundlingOptions>(options =>
            {
                options.StyleBundles.Configure(
                    BasicThemeBundles.Styles.Global,
                    bundle => { bundle.AddFiles("/global-styles.css"); }
                );
            });
        }

        private void ConfigureUrls(IConfiguration configuration)
        {
            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
                options.RedirectAllowedUrls.AddRange(configuration["App:RedirectAllowedUrls"].Split(','));

                options.Applications["Angular"].RootUrl = configuration["App:ClientUrl"];
                options.Applications["Angular"].Urls[AccountUrlNames.PasswordReset] = "account/reset-password";
            });
        }

        private void ConfigureBlobStoring() {
            Configure<AbpBlobStoringOptions>(options =>
            {
                options.Containers.ConfigureAll((containerName, containerConfiguration) =>
                {
                    containerConfiguration.UseFileSystem(fileSystem =>
                    {
                        fileSystem.BasePath = Path.Combine(Directory.GetCurrentDirectory(), "file-blob-storing");
                    });
                });
            });
        }

        private void ConfigureDbContext() {
            // ??????Ef
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });
        }

        private void ConfigureJsonSerializer() {
            // ????????????????????????
            Configure<AbpJsonOptions>(options =>
            {
                options.DefaultDateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            });
            // ??????????????????????????????
            Configure<AbpSystemTextJsonSerializerOptions>(options =>
            {
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
            });
        }

        private void ConfigureVirtualFileSystem(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<BasicDomainSharedModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath, "..", "..", "modules", "basic", "GoodFramework.Basic.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<BasicDomainModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath, "..", "..", "modules", "basic", "GoodFramework.Basic.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<BasicApplicationContractsModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath, "..", "..", "modules", "basic", "GoodFramework.Basic.Application.Contracts"));
                    options.FileSets.ReplaceEmbeddedByPhysical<BasicApplicationModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath, "..", "..", "modules", "basic", "GoodFramework.Basic.Application"));
                });
            }
        }

        private void ConfigureConventionalControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(BasicApplicationModule).Assembly);
            });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                    options.Audience = "GoodFramework";
                    options.BackchannelHttpHandler = new HttpClientHandler
                    {
                        ServerCertificateCustomValidationCallback =
                            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                    };
                });
        }

        private static void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAbpSwaggerGenWithOAuth(
                configuration["AuthServer:Authority"],
                new Dictionary<string, string>
                {
                    {"GoodFramework", "GoodFramework API"}
                },
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo {Title = "GoodFramework API", Version = "v1"});
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                });
        }

        private void ConfigureLocalization()
        {
            // ???????????????????????????
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "????????????"));
                options.Languages.Add(new LanguageInfo("en", "en", "English"));

                options.Resources
                       .Get<IdentityResource>()
                       .AddVirtualJson("/Localization/Resources");
                options
                    .AddLanguagesMapOrUpdate(
                        "vue-admin-element-ui",
                        new NameValue("zh-Hans", "zh"),
                        new NameValue("en", "en"));

                // vben admin ????????????
                options
                    .AddLanguagesMapOrUpdate(
                        "vben-admin-ui",
                        new NameValue("zh_CN", "zh-Hans"));

                options.Resources.AddDynamic();
            });

            Configure<AbpLocalizationCultureMapOptions>(options =>
            {
                var zhHansCultureMapInfo = new CultureMapInfo
                {
                    TargetCulture = "zh-Hans",
                    SourceCultures = new string[] { "zh", "zh_CN", "zh-CN" }
                };

                options.CulturesMaps.Add(zhHansCultureMapInfo);
                options.UiCulturesMaps.Add(zhHansCultureMapInfo);
            });

            Configure<RequestLocalizationOptions>(options =>
            {
                options.RequestCultureProviders.Insert(0, new AbpCultureMapRequestCultureProvider());
            });
        }

        private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddCors(options =>
            {
                options.AddDefaultPolicy( builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });
        }

        #region ??????
        //private void ConfigreExceptionHandling() {
        //    // ??????????????????????????????
        //    Configure<AbpExceptionHandlingOptions>(options =>
        //    {
        //        //  ?????????????????????????????????
        //        options.Handlers.Add<Volo.Abp.Data.AbpDbConcurrencyException>();
        //        options.Handlers.Add<AbpInitializationException>();
        //        options.Handlers.Add<ObjectDisposedException>();
        //        options.Handlers.Add<StackOverflowException>();
        //        options.Handlers.Add<OutOfMemoryException>();
        //        options.Handlers.Add<System.Data.Common.DbException>();
        //        options.Handlers.Add<Microsoft.EntityFrameworkCore.DbUpdateException>();
        //        options.Handlers.Add<System.Data.DBConcurrencyException>();
        //    });
        //    // ????????????????????????????????????????????????
        //    Configure<AbpEmailExceptionHandlingOptions>(options =>
        //    {
        //        // ????????????????????????
        //        options.SendStackTrace = true;
        //    });

        //    Configure<Volo.Abp.AspNetCore.ExceptionHandling.AbpExceptionHandlingOptions>(options =>
        //    {
        //        // ????????????????????????
        //        options.SendExceptionsDetailsToClients = false;
        //    });
        //}

        //private void ConfigureCaching(IConfiguration configuration) {
        //    Configure<AbpDistributedCacheOptions>(options =>
        //    {
        //        // ??????????????????,?????????????????????????????????????????????????????????
        //        options.KeyPrefix = "GoodFramework.Abp.Application";
        //        // ????????????30???
        //        options.GlobalCacheEntryOptions.SlidingExpiration = TimeSpan.FromDays(30d);
        //        // ????????????60???
        //        options.GlobalCacheEntryOptions.AbsoluteExpiration = DateTimeOffset.Now.AddDays(60d);
        //    });

        //    Configure<RedisCacheOptions>(options =>
        //    {
        //        var redisConfig = ConfigurationOptions.Parse(options.Configuration);
        //        options.ConfigurationOptions = redisConfig;
        //        options.InstanceName = configuration["Redis:InstanceName"];
        //    });
        //}

        //private void ConfigureMultiTenancy(IConfiguration configuration) {
        //    // ?????????
        //    Configure<AbpMultiTenancyOptions>(options =>
        //    {
        //        options.IsEnabled = true;
        //    });

        //    var tenantResolveCfg = configuration.GetSection("App:Domains");
        //    if (tenantResolveCfg.Exists()) {
        //        Configure<AbpTenantResolveOptions>(options =>
        //        {
        //            var domains = tenantResolveCfg.Get<string[]>();
        //            foreach (var domain in domains) {
        //                options.AddDomainTenantResolver(domain);
        //            }
        //        });
        //    }
        //}
        #endregion

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAbpRequestLocalization();

            if (!env.IsDevelopment())
            {
                app.UseErrorPage();
            }

            app.UseCorrelationId();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseJwtTokenMiddleware();

            if (MultiTenancyConsts.IsEnabled)
            {
                app.UseMultiTenancy();
            }
            // ?????????
            app.UseMapRequestLocalization();

            app.UseUnitOfWork();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseAbpSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GoodFramework API");

                var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
                c.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
                c.OAuthClientSecret(configuration["AuthServer:SwaggerClientSecret"]);
                c.OAuthScopes("GoodFramework");
            });

            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();
        }
    }
}
