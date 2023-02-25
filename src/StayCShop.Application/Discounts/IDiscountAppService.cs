using Abp.Application.Services.Dto;
using StayCShop.Discounts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.Discounts
{
    public interface IDiscountAppService
    {
        Task<PagedResultDto<DiscountListDto>> GetAll(GetAllDiscountInput input);
        Task Delete(EntityDto input);
        Task<GetForEditDiscountDto> GetForEdit(NullableIdDto input);
        Task CreateOrUpdate(CreateOrEditDiscountDto input);
    }
}
