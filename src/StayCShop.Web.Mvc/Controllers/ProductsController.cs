using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using StayCShop.Products.Dto;
using StayCShop.Products;
using StayCShop.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using StayCShop.Images;
using StayCShop.ProductCategories;
using StayCShop.ProductDiscounts;

namespace StayCShop.Web.Controllers
{
    public class ProductsController : StayCShopControllerBase
    {
        private readonly IProductAppService _productAppService;
        private readonly IImageAppService _imageAppService;
        private readonly IProductCategoryAppService _productCategoryAppService;
        private readonly IProductDiscountAppService _productDiscountAppService;

        public ProductsController(IProductAppService productAppService,
            IImageAppService imageAppService,
            IProductCategoryAppService productCategoryAppService,
            IProductDiscountAppService productDiscountAppService)
        {
            _productAppService = productAppService;
            _imageAppService = imageAppService;
            _productCategoryAppService = productCategoryAppService;
            _productDiscountAppService = productDiscountAppService;
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

        public IActionResult Categories(int productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }  
        
        public IActionResult Discounts(int productId)
        {
            ViewBag.ProductId = productId;
            return View();
        }

        public async Task<IActionResult> EditImageModal(int id, int productId)
        {
            ViewBag.ProductId = productId;
            var model = await _imageAppService.GetForEdit(new NullableIdDto(id));
            return PartialView("_EditImageModal", model);
        }

        public async Task<IActionResult> EditCategoryModal(int id, int productId)
        {
            ViewBag.ProductId = productId;
            var model = await _productCategoryAppService.GetForEdit(new NullableIdDto(id));
            return PartialView("_EditCategoryModal", model);
        }

        public async Task<IActionResult> EditDiscountModal(int id, int productId)
        {
            ViewBag.ProductId = productId;
            var model = await _productDiscountAppService.GetForEdit(new NullableIdDto(id));
            return PartialView("_EditDiscountModal", model);
        }
    }
}
