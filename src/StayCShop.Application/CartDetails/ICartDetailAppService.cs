using Abp.Application.Services.Dto;
using StayCShop.CartDetails.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.CartDetails
{
    public interface ICartDetailAppService
    {
        Task<PagedResultDto<CartDetailListDto>> GetAll(GetAllCartDetailInput input);
        Task Delete(EntityDto input);
        Task<GetForEditCartDetailDto> GetForEdit(NullableIdDto input);
        Task CreateOrUpdate(CreateOrUpdateCartDetailDto input);
    }
}
