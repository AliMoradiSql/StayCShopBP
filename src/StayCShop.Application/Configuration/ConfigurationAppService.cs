using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using StayCShop.Configuration.Dto;

namespace StayCShop.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : StayCShopAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
