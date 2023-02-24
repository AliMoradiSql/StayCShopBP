using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using StayCShop.Brands;
using StayCShop.Brands.Dto;
using StayCShop.Controllers;
using StayCShop.Web.Models.Users;
using System.Threading.Tasks;

namespace StayCShop.Web.Controllers
{
    public class BrandsController : StayCShopControllerBase
    {
        private readonly IBrandAppService _brandAppService;

        public BrandsController(IBrandAppService brandAppService)
        {
            _brandAppService = brandAppService;
        }

        public IActionResult Index()
        {

            return View(new GetForEditBrandDto());
        }

        public async Task<ActionResult> CreateOrEditBrandModal(int? Id)
        {
            var model = await _brandAppService.GetForEdit(new NullableIdDto(Id));
            return PartialView("_CreateOrEditBrandModal", model);
        }

    }
}
