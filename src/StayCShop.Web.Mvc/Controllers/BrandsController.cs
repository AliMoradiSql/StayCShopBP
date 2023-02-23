using Microsoft.AspNetCore.Mvc;
using StayCShop.Controllers;

namespace StayCShop.Web.Controllers
{
    public class BrandsController : StayCShopControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
