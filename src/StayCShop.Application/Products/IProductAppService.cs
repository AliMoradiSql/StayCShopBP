using Abp.Application.Services.Dto;
using StayCShop.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.Products
{
    public interface IProductAppService 
    {
        Task<PagedResultDto<ProductListDto>> GetAll(GetAllProductInput input);
        Task Delete(EntityDto input);
        Task<GetForEditProductDto> GetForEdit(NullableIdDto input);
        Task CreateOrUpdate(CreateOrEditProductDto input);
    }
}
