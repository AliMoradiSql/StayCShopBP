using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using StayCShop.Entities;
using StayCShop.ProductCategories.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq.Extensions;

namespace StayCShop.ProductCategories
{
    public class ProductCategoryAppService : StayCShopAppServiceBase, IProductCategoryAppService
    {
        private readonly IRepository<ProductCategory> _productCategoryRepository;

        public ProductCategoryAppService(IRepository<ProductCategory> productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<PagedResultDto<ProductCategoryListDto>> GetAll(GetAllProductCategoryInput input)
        {

            var query = _productCategoryRepository.GetAll()
                .WhereIf(!string.IsNullOrEmpty(input.Filter), x => x.Product.Name.Contains(input.Filter) 
                || x.Category.CategoryName.Contains(input.Filter));


            var count = await query.CountAsync();
            var data = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var mappedData = ObjectMapper.Map<List<ProductCategoryListDto>>(data);

            return new PagedResultDto<ProductCategoryListDto>(count, mappedData);
        }

        public async Task CreateOrUpdate(CreateOrEditProductCategoryDto input)
        {
            if (input.Id.HasValue)
                await _productCategoryRepository.UpdateAsync(ObjectMapper.Map<ProductCategory>(input));
            else
                await _productCategoryRepository.InsertAsync(ObjectMapper.Map<ProductCategory>(input));
        }

        public async Task Delete(EntityDto input)
        {
            await _productCategoryRepository.DeleteAsync(x => x.Id == input.Id);
        }

        public async Task<GetForEditProductCategoryDto> GetForEdit(NullableIdDto input)
        {
            if (!input.Id.HasValue)
                return new GetForEditProductCategoryDto();

            var output = await _productCategoryRepository.GetAsync(input.Id.Value);

            return ObjectMapper.Map<GetForEditProductCategoryDto>(output);

        }
    }
}
