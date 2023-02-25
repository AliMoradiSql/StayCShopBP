using Abp.Application.Services.Dto;
using StayCShop.Brands.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.Brands
{
    public interface IBrandAppService
    {
        Task<PagedResultDto<BrandListDto>> GetAll(GetAllBrandInput input);
        Task Delete(EntityDto input);
        Task<GetForEditBrandDto> GetForEdit(NullableIdDto input);
        Task CreateOrUpdate(CreateOrEditBrandDto input);
    }
}
