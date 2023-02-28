using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using StayCShop.Products.Dto;
using StayCShop.Products;
using StayCShop.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using StayCShop.Images;

namespace StayCShop.Web.Controllers
{
    public class ProductsController : StayCShopControllerBase
    {
        private readonly IProductAppService _productAppService;
        private readonly IImageAppService _imageAppService;

        public ProductsController(IProductAppService productAppService, IImageAppService imageAppService)
        {
            _productAppService = productAppService;
            _imageAppService = imageAppService;
        }

        public IActionResult Index()
        {

            return View(new GetForEditProductDto());
        }

        public ActionResult CreateOrEditProductModal(int? Id)
        {
           
            return PartialView("_CreateOrEditProductModal");
        }


        public async Task<IActionResult> Detail(int id)
        {
            var model = await _productAppService.GetForEdit(new NullableIdDto(id));
            return View(model);
        }


        public IActionResult Images(int productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }

        public async Task<IActionResult> EditImageModal(int id,int productId)
        {
            ViewBag.ProductId = productId;
            var model = await _imageAppService.GetForEdit(new NullableIdDto(id));
            return PartialView("_EditImageModal",model);
        }
    }
}
