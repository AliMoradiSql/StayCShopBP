using Abp.AspNetCore.Mvc.ViewComponents;

namespace StayCShop.Web.Views
{
    public abstract class StayCShopViewComponent : AbpViewComponent
    {
        protected StayCShopViewComponent()
        {
            LocalizationSourceName = StayCShopConsts.LocalizationSourceName;
        }
    }
}
