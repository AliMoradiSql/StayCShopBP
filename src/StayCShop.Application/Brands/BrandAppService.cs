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


namespace StayCShop.Brands
{
    public class BrandAppService : StayCShopAppServiceBase, IBrandAppService
    {
        private readonly IRepository<Brand> _brandRepository;

        public BrandAppService(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<PagedResultDto<BrandListDto>> GetAll(GetAllBrandInput input)
        {

            var query = _brandRepository.GetAll()
                .WhereIf(!string.IsNullOrEmpty(input.Filter), x => x.BrandName.Contains(input.Filter));


            var count = await query.CountAsync();
            var data = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var mappedData = ObjectMapper.Map<List<BrandListDto>>(data);

            return new PagedResultDto<BrandListDto>(count, mappedData);
        }

        public async Task CreateOrUpdate(CreateOrUpdateBrandDto input)
        {
            if (input.Id.HasValue)
                 await _brandRepository.UpdateAsync(ObjectMapper.Map<Brand>(input));
           else
                await _brandRepository.InsertAsync(ObjectMapper.Map<Brand>(input));
        }

        public async Task Delete(EntityDto input)
        {
            await _brandRepository.DeleteAsync(x => x.Id == input.Id);
        }

        public async Task<GetForEditBrandDto> GetForEdit(NullableIdDto input)
        {
            if (!input.Id.HasValue)
                return new GetForEditBrandDto();

            var output = await _brandRepository.GetAsync(input.Id.Value);

            return ObjectMapper.Map<GetForEditBrandDto>(output);

        }
    }
}
