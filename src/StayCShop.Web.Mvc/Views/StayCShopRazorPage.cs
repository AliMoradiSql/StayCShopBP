using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace StayCShop.Web.Views
{
    public abstract class StayCShopRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected StayCShopRazorPage()
        {
            LocalizationSourceName = StayCShopConsts.LocalizationSourceName;
        }
    }
}
