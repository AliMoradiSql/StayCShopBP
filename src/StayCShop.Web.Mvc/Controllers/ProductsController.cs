using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using StayCShop.Products.Dto;
using StayCShop.Products;
using StayCShop.Controllers;
using System.Threading.Tasks;

namespace StayCShop.Web.Controllers
{
    public class ProductsController : StayCShopControllerBase
    {
        private readonly IProductAppService _productAppService;

        public ProductsController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public IActionResult Index()
        {

            return View(new GetForEditProductDto());
        }

        public async Task<ActionResult> CreateOrEditProductModal(int? Id)
        {
            var model = await _productAppService.GetForEdit(new NullableIdDto(Id));
            return PartialView("_CreateOrEditProductModal", model);
        }
    }
}
