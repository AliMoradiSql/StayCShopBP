using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using StayCShop.Authorization;

namespace StayCShop.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class StayCShopNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
              
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fas fa-home",
                        requiresAuthentication: true
                    )
              
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "fas fa-theater-masks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, StayCShopConsts.LocalizationSourceName);
        }
    }
}