using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using StayCShop.CartDetails.Dto;
using StayCShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq.Extensions;

namespace StayCShop.CartDetails
{
    public class CartDetailAppService : StayCShopAppServiceBase, ICartDetailAppService
    {
        private readonly IRepository<CartDetail> _cartDetailRepository;

        public CartDetailAppService(IRepository<CartDetail> cartDetailRepository)
        {
            _cartDetailRepository = cartDetailRepository;
        }


        public async Task<PagedResultDto<CartDetailListDto>> GetAll(GetAllCartDetailInput input)
        {

            var query = _cartDetailRepository.GetAllIncluding(x => x.Product)
                .WhereIf(input.CartId.HasValue, x => x.CartId == input.CartId);


            var count = await query.CountAsync();
            var data = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var mappedData = ObjectMapper.Map<List<CartDetailListDto>>(data);

            return new PagedResultDto<CartDetailListDto>(count, mappedData);
        }

        public async Task CreateOrUpdate(CreateOrEditCartDetailDto input)
        {
            if (input.Id.HasValue)
                await _cartDetailRepository.UpdateAsync(ObjectMapper.Map<CartDetail>(input));
            else
                await _cartDetailRepository.InsertAsync(ObjectMapper.Map<CartDetail>(input));
        }

        public async Task Delete(EntityDto input)
        {
            await _cartDetailRepository.DeleteAsync(x => x.Id == input.Id);
        }

        public async Task<GetForEditCartDetailDto> GetForEdit(NullableIdDto input)
        {
            if (!input.Id.HasValue)
                return new GetForEditCartDetailDto();

            var output = await _cartDetailRepository.GetAllIncluding(x=>x.Product).FirstOrDefaultAsync(x=>x.Id == input.Id.Value);

            return ObjectMapper.Map<GetForEditCartDetailDto>(output);

        }
    }
}
