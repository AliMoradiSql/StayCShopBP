using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using StayCShop.Discounts.Dto;
using StayCShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq.Extensions;

namespace StayCShop.Discounts
{
    public class DiscountAppService : StayCShopAppServiceBase , IDiscountAppService
    {
        private readonly IRepository<Discount> _discountRepository;

        public DiscountAppService(IRepository<Discount> discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<PagedResultDto<DiscountListDto>> GetAll(GetAllDiscountInput input)
        {

            var query = _discountRepository.GetAll()
                .WhereIf(!string.IsNullOrEmpty(input.Filter), x => x.DiscountName.Contains(input.Filter));


            var count = await query.CountAsync();
            var data = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var mappedData = ObjectMapper.Map<List<DiscountListDto>>(data);

            return new PagedResultDto<DiscountListDto>(count, mappedData);
        }

        public async Task CreateOrUpdate(CreateOrEditDiscountDto input)
        {
            if (input.Id.HasValue)
                await _discountRepository.UpdateAsync(ObjectMapper.Map<Discount>(input));
            else
                await _discountRepository.InsertAsync(ObjectMapper.Map<Discount>(input));
        }

        public async Task Delete(EntityDto input)
        {
            await _discountRepository.DeleteAsync(x => x.Id == input.Id);
        }

        public async Task<GetForEditDiscountDto> GetForEdit(NullableIdDto input)
        {
            if (!input.Id.HasValue)
                return new GetForEditDiscountDto();

            var output = await _discountRepository.GetAsync(input.Id.Value);

            return ObjectMapper.Map<GetForEditDiscountDto>(output);

        }
    }
}
