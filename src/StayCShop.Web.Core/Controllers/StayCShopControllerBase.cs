using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace StayCShop.Controllers
{
    public abstract class StayCShopControllerBase: AbpController
    {
        protected StayCShopControllerBase()
        {
            LocalizationSourceName = StayCShopConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
