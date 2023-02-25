using Abp.Application.Services.Dto;
using StayCShop.ProductCategories.Dto;
using System.Threading.Tasks;

namespace StayCShop.ProductCategories
{
    public interface IProductCategoryAppService
    {
        Task<PagedResultDto<ProductCategoryListDto>> GetAll(GetAllProductCategoryInput input);
        Task Delete(EntityDto input);
        Task<GetForEditProductCategoryDto> GetForEdit(NullableIdDto input);
        Task CreateOrUpdate(CreateOrEditProductCategoryDto input);
    }
}