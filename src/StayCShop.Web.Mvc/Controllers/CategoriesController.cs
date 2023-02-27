using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using StayCShop.Categories;
using StayCShop.Categories.Dto;
using StayCShop.Controllers;
using StayCShop.Web.Models.Users;
using System.Threading.Tasks;

namespace StayCShop.Web.Controllers
{
    public class CategoriesController : StayCShopControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoriesController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        public IActionResult Index()
        {

            return View(new GetForEditCategoryDto());
        }

        public async Task<ActionResult> CreateOrEditCategoryModal(int? Id)
        {
            var model = await _categoryAppService.GetForEdit(new NullableIdDto(Id));
            return PartialView("_CreateOrEditCategoryModal", model);
        }

    }
}
