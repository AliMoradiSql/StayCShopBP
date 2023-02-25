using Abp.Application.Services.Dto;
using StayCShop.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.Categories
{
    public interface ICategoryAppService
    {
        Task<PagedResultDto<CategoryListDto>> GetAll(GetAllCategoryInput input);
        Task Delete(EntityDto input);
        Task<GetForEditCategoryDto> GetForEdit(NullableIdDto input);
        Task CreateOrUpdate(CreateOrEditCategoryDto input);
    }
}
