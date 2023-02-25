using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using StayCShop.ProductDiscounts.Dto;
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

namespace StayCShop.ProductDiscounts
{
    public class ProductDiscountAppService : StayCShopAppServiceBase, IProductDiscountAppService
    {
        private readonly IRepository<ProductDiscount> _productDiscountRepository;

        public ProductDiscountAppService(IRepository<ProductDiscount> productDiscountRepository)
        {
            _productDiscountRepository = productDiscountRepository;
        }

        public async Task<PagedResultDto<ProductDiscountListDto>> GetAll(GetAllProductDiscountInput input)
        {

            var query = _productDiscountRepository.GetAll()
                .WhereIf(!string.IsNullOrEmpty(input.Filter), x => x.Product.Name.Contains(input.Filter));


            var count = await query.CountAsync();
            var data = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var mappedData = ObjectMapper.Map<List<ProductDiscountListDto>>(data);

            return new PagedResultDto<ProductDiscountListDto>(count, mappedData);
        }

        public async Task CreateOrUpdate(CreateOrEditProductDiscountDto input)
        {
            if (input.Id.HasValue)
                await _productDiscountRepository.UpdateAsync(ObjectMapper.Map<ProductDiscount>(input));
            else
                await _productDiscountRepository.InsertAsync(ObjectMapper.Map<ProductDiscount>(input));
        }

        public async Task Delete(EntityDto input)
        {
            await _productDiscountRepository.DeleteAsync(x => x.Id == input.Id);
        }

        public async Task<GetForEditProductDiscountDto> GetForEdit(NullableIdDto input)
        {
            if (!input.Id.HasValue)
                return new GetForEditProductDiscountDto();

            var output = await _productDiscountRepository.GetAsync(input.Id.Value);

            return ObjectMapper.Map<GetForEditProductDiscountDto>(output);

        }
    }
}
