using Abp.Application.Services.Dto;
using StayCShop.ProductDiscounts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.ProductDiscounts
{
    public interface IProductDiscountAppService 
    {
        Task<PagedResultDto<ProductDiscountListDto>> GetAll(GetAllProductDiscountInput input);
        Task CreateOrUpdate(CreateOrEditProductDiscountDto input);
        Task Delete(EntityDto input);
        Task<GetForEditProductDiscountDto> GetForEdit(NullableIdDto input);
    }
}
