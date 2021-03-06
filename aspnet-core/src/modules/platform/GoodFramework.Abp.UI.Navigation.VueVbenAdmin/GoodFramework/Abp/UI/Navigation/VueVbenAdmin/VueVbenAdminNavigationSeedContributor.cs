using GoodFramework.Platform.Datas;
using GoodFramework.Platform.Layouts;
using GoodFramework.Platform.Menus;
using GoodFramework.Platform.Routes;
using GoodFramework.Platform.Utils;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using ValueType = GoodFramework.Platform.Datas.ValueType;

namespace GoodFramework.Abp.UI.Navigation.VueVbenAdmin
{
    public class VueVbenAdminNavigationSeedContributor : NavigationSeedContributor
    {
        private static int _lastCodeNumber = 0;
        protected ICurrentTenant CurrentTenant { get; }
        protected IGuidGenerator GuidGenerator { get; }
        protected IRouteDataSeeder RouteDataSeeder { get; }
        protected IDataDictionaryDataSeeder DataDictionaryDataSeeder { get; }
        protected IMenuRepository MenuRepository { get; }
        protected ILayoutRepository LayoutRepository { get; }
        protected AbpUINavigationVueVbenAdminOptions Options { get; }

        public VueVbenAdminNavigationSeedContributor(
            ICurrentTenant currentTenant,
            IRouteDataSeeder routeDataSeeder,
            IMenuRepository menuRepository,
            ILayoutRepository layoutRepository,
            IGuidGenerator guidGenerator,
            IDataDictionaryDataSeeder dataDictionaryDataSeeder,
            IOptions<AbpUINavigationVueVbenAdminOptions> options)
        {
            CurrentTenant = currentTenant;
            GuidGenerator = guidGenerator;
            RouteDataSeeder = routeDataSeeder;
            MenuRepository = menuRepository;
            LayoutRepository = layoutRepository;
            DataDictionaryDataSeeder = dataDictionaryDataSeeder;

            Options = options.Value;
        }

        public override async Task SeedAsync(NavigationSeedContext context)
        {
            var uiDataItem = await SeedUIFrameworkDataAsync(CurrentTenant.Id);

            var layoutData = await SeedLayoutDataAsync(CurrentTenant.Id);

            var layout = await SeedDefaultLayoutAsync(layoutData, uiDataItem);

            var latMenu = await MenuRepository.GetLastMenuAsync();

            if (int.TryParse(CodeNumberGenerator.GetLastCode(latMenu?.Code ?? "0"), out int _lastNumber))
            {
                Interlocked.Exchange(ref _lastCodeNumber, _lastNumber);
            }

            await SeedDefinitionMenusAsync(layout, layoutData, context.Menus, context.MultiTenancySides);
        }

        private async Task SeedDefinitionMenusAsync(
            Layout layout,
            Data data, 
            IReadOnlyCollection<ApplicationMenu> menus,
            MultiTenancySides multiTenancySides)
        {
            foreach (var menu in menus)
            {
                if (!menu.MultiTenancySides.HasFlag(multiTenancySides))
                {
                    continue;
                }

                var menuMeta = new Dictionary<string, object>()
                {
                    { "title", menu.DisplayName },
                    { "icon", menu.Icon ?? "" },
                    { "hideTab", false },
                    { "ignoreAuth", false },
                };
                menuMeta.AddIfNotContains(menu.ExtraProperties);

                var seedMenu = await SeedMenuAsync(
                    layout:         layout,
                    data:           data,
                    name:           menu.Name,
                    path:           menu.Url,
                    code:           CodeNumberGenerator.CreateCode(GetNextCode()),
                    component:      layout.Path,
                    displayName:    menu.DisplayName,
                    redirect:       menu.Redirect,
                    description:    menu.Description,
                    parentId:       null,
                    tenantId:       layout.TenantId,
                    meta:           menuMeta,
                    roles:          new string[] { "admin" });

                await SeedDefinitionMenuItemsAsync(layout, data, seedMenu, menu.Items, multiTenancySides);
            }
        }

        private async Task SeedDefinitionMenuItemsAsync(
            Layout layout, 
            Data data, 
            Menu menu, 
            ApplicationMenuList items,
            MultiTenancySides multiTenancySides)
        {
            int index = 1;
            foreach (var item in items)
            {
                if (!item.MultiTenancySides.HasFlag(multiTenancySides))
                {
                    continue;
                }

                var menuMeta = new Dictionary<string, object>()
                {
                    { "title", item.DisplayName },
                    { "icon", item.Icon ?? "" },
                    { "hideTab", false },
                    { "ignoreAuth", false },
                };
                menuMeta.AddIfNotContains(item.ExtraProperties);

                var seedMenu = await SeedMenuAsync(
                    layout: layout,
                    data: data,
                    name: item.Name,
                    path: item.Url,
                    code: CodeNumberGenerator.AppendCode(menu.Code, CodeNumberGenerator.CreateCode(index)),
                    component: item.Component.IsNullOrWhiteSpace() ? layout.Path : item.Component,
                    displayName: item.DisplayName,
                    redirect: item.Redirect,
                    description: item.Description,
                    parentId: menu.Id,
                    tenantId: menu.TenantId,
                    meta: menuMeta,
                    roles: new string[] { "admin" });

                await SeedDefinitionMenuItemsAsync(layout, data, seedMenu, item.Items, multiTenancySides);

                index++;
            }
        }

        private async Task<Menu> SeedMenuAsync(
            Layout layout,
            Data data,
            string name,
            string path,
            string code,
            string component,
            string displayName,
            string redirect = "",
            string description = "",
            Guid? parentId = null,
            Guid? tenantId = null,
            Dictionary<string, object> meta = null,
            string[] roles = null,
            Guid[] users = null,
            bool isPublic = false
            )
        {
            var menu = await RouteDataSeeder.SeedMenuAsync(
                layout,
                name,
                path,
                code,
                component,
                displayName,
                redirect,
                description,
                parentId,
                tenantId,
                isPublic
                );
            foreach (var item in data.Items)
            {
                menu.SetProperty(item.Name, item.DefaultValue);
            }
            if (meta != null)
            {
                foreach (var item in meta)
                {
                    menu.SetProperty(item.Key, item.Value);
                }
            }

            if (roles != null)
            {
                foreach (var role in roles)
                {
                    await RouteDataSeeder.SeedRoleMenuAsync(role, menu, tenantId);
                }
            }

            if (users != null)
            {
                foreach (var user in users)
                {
                    await RouteDataSeeder.SeedUserMenuAsync(user, menu, tenantId);
                }
            }

            return menu;
        }

        private async Task<DataItem> SeedUIFrameworkDataAsync(Guid? tenantId)
        {
            var data = await DataDictionaryDataSeeder
                .SeedAsync(
                    "UI Framework",
                    CodeNumberGenerator.CreateCode(10),
                    "UI??????",
                    "UI Framework",
                    null,
                    tenantId,
                    true);

            data.AddItem(
                GuidGenerator,
                Options.UI,
                Options.UI,
                Options.UI,
                ValueType.String,
                Options.UI,
                isStatic: true);

            return data.FindItem(Options.UI);
        }

        private async Task<Layout> SeedDefaultLayoutAsync(Data data, DataItem uiDataItem)
        {
            var layout = await RouteDataSeeder.SeedLayoutAsync(
               Options.LayoutName,
               Options.LayoutPath, // ??????????????????????????????,???????????????LAYOUT?????????????????????
               Options.LayoutName,
               data.Id,
               uiDataItem.Name,
               "",
               Options.LayoutName,
               data.TenantId
               );

            return layout;
        }

        private async Task<Data> SeedLayoutDataAsync(Guid? tenantId)
        {
            var data = await DataDictionaryDataSeeder
                .SeedAsync(
                    Options.LayoutName,
                    CodeNumberGenerator.CreateCode(10),
                    "Vben Admin ????????????",
                    "Vben Admin Layout Meta Dictionary",
                    null,
                    tenantId,
                    true);

            data.AddItem(
                GuidGenerator,
                "hideMenu",
                "??????????????????",
                "false",
                ValueType.Boolean,
                "??????????????????????????????",
                isStatic: true);
            data.AddItem(
                GuidGenerator,
                "icon",
                "??????",
                "",
                ValueType.String,
                "???????????????????????????",
                isStatic: true);
            data.AddItem(
                GuidGenerator,
                "currentActiveMenu",
                "?????????????????????",
                "",
                ValueType.String,
                "???????????????????????????????????????????????????",
                isStatic: true);
            data.AddItem(
                GuidGenerator,
                "ignoreKeepAlive",
                "KeepAlive??????",
                "false",
                ValueType.Boolean,
                "????????????KeepAlive??????",
                isStatic: true);
            data.AddItem(
                GuidGenerator,
                "frameSrc",
                "IFrame??????",
                "",
                ValueType.String,
                "??????iframe?????????",
                isStatic: true);
            data.AddItem(
                GuidGenerator,
                "transitionName",
                "??????????????????",
                "",
                ValueType.String,
                "?????????????????????????????????",
                isStatic: true);
            data.AddItem(
                GuidGenerator,
                "roles",
                "?????????????????????",
                "",
                ValueType.Array,
                "?????????????????????????????????????????????Role???????????????",
                isStatic: true);
            data.AddItem(
                GuidGenerator,
                "title",
                "????????????",
                "",
                ValueType.String,
                "??????title ????????????",
                false,
                isStatic: true);
            data.AddItem(
                GuidGenerator,
                "carryParam",
                "???tab?????????",
                "false",
                ValueType.Boolean,
                "?????????????????????????????????????????????tab????????????????????????????????????true",
                isStatic: true);
            data.AddItem(
                GuidGenerator,
                "hideBreadcrumb",
                "???????????????",
                "false",
                ValueType.Boolean,
                "??????????????????????????????????????????",
                isStatic: true);
            data.AddItem(
               GuidGenerator,
               "ignoreAuth",
               "????????????",
               "false",
               ValueType.Boolean,
               "??????????????????????????????????????????Role???????????????",
                isStatic: true);
            data.AddItem(
                GuidGenerator,
                "hideChildrenInMenu",
                "?????????????????????",
                "false",
                ValueType.Boolean,
                "?????????????????????",
                isStatic: true);
            data.AddItem(
                GuidGenerator,
                "hideTab",
                "?????????????????????",
                "false",
                ValueType.Boolean,
                "?????????????????????????????????",
                isStatic: true);
            data.AddItem(
                GuidGenerator,
                "affix",
                "???????????????",
                "false",
                ValueType.Boolean,
                "?????????????????????",
                isStatic: true);
            data.AddItem(
                GuidGenerator,
                "frameFormat",
                "?????????IFrame",
                "false",
                ValueType.Boolean,
                "??????????????????frame???{token}: ????????????iframe????????????token?????????");

            return data;
        }

        private int GetNextCode()
        {
            Interlocked.Increment(ref _lastCodeNumber);
            return _lastCodeNumber;
        }
    }
}
