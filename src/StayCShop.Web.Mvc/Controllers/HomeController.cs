using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using StayCShop.Controllers;

namespace StayCShop.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : StayCShopControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
