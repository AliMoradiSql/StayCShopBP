using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using StayCShop.Brands.Dto;
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
using StayCShop.Categories.Dto;

namespace StayCShop.Categories
{
    public class CategoryAppService : StayCShopAppServiceBase, ICategoryAppService
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryAppService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<PagedResultDto<CategoryListDto>> GetAll(GetAllCategoryInput input)
        {

            var query = _categoryRepository.GetAll()
                .WhereIf(!string.IsNullOrEmpty(input.Filter), x => x.CategoryName.Contains(input.Filter));


            var count = await query.CountAsync();
            var data = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var mappedData = ObjectMapper.Map<List<CategoryListDto>>(data);

            return new PagedResultDto<CategoryListDto>(count, mappedData);
        }

        public async Task CreateOrUpdate(CreateOrUpdateCategoryDto input)
        {
            if (input.Id.HasValue)
                await _categoryRepository.UpdateAsync(ObjectMapper.Map<Category>(input));
            else
                await _categoryRepository.InsertAsync(ObjectMapper.Map<Category>(input));
        }

        public async Task Delete(EntityDto input)
        {
            await _categoryRepository.DeleteAsync(x => x.Id == input.Id);
        }

        public async Task<GetForEditCategoryDto> GetForEdit(NullableIdDto input)
        {
            if (!input.Id.HasValue)
                return new GetForEditCategoryDto();

            var output = await _categoryRepository.GetAsync(input.Id.Value);

            return ObjectMapper.Map<GetForEditCategoryDto>(output);

        }
    }
}
