using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using StayCShop.Discounts;
using StayCShop.Discounts.Dto;
using StayCShop.Categories;
using StayCShop.Controllers;
using StayCShop.Web.Models.Users;
using System.Threading.Tasks;

namespace StayCShop.Web.Controllers
{
    public class DiscountsController : StayCShopControllerBase
    {
        private readonly IDiscountAppService _discountAppService;

        public DiscountsController(IDiscountAppService discountAppService)
        {
            _discountAppService = discountAppService;
        }

        public IActionResult Index()
        {

            return View(new GetForEditDiscountDto());
        }

        public async Task<ActionResult> CreateOrEditDiscountModal(int? Id)
        {
            var model = await _discountAppService.GetForEdit(new NullableIdDto(Id));
            return PartialView("_CreateOrEditDiscountModal", model);
        }

    }
}
