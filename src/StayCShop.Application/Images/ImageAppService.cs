using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Http;
using StayCShop.Entities;
using StayCShop.Images.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq.Extensions;
using System.IO;
using Abp.IO.Extensions;

namespace StayCShop.Images
{
    public class ImageAppService : StayCShopAppServiceBase, IImageAppService
    {
        private readonly IRepository<Image> _imageRepository;

        public ImageAppService(IRepository<Image> imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<PagedResultDto<ImageListDto>> GetAll(GetAllImageInput input)
        {
            var query = _imageRepository.GetAll()
                .WhereIf(!string.IsNullOrEmpty(input.Filter), x => x.Title.Contains(input.Filter))
                .WhereIf(input.ProductId.HasValue, x => x.ProductId == input.ProductId);

            var count = await query.CountAsync();

            var data = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var mappedData = ObjectMapper.Map<List<ImageListDto>>(data);

            return new PagedResultDto<ImageListDto>(count, mappedData);

        }

        public async Task CreateOrUpdate(CreateOrEditImageDto input)
        {
            if (input.Id.HasValue)
            {
                var data = await _imageRepository.GetAsync(input.Id.Value);
                if (input.image == null)
                    input.image = data.image;
                ObjectMapper.Map(input, data);
            }

            else
                await _imageRepository.InsertAsync(ObjectMapper.Map<Image>(input));
        }

        public async Task Delete(EntityDto input)
        {
            await _imageRepository.DeleteAsync(x => x.Id == input.Id);
        }

        public async Task<GetForEditImageDto> GetForEdit(NullableIdDto input)
        {
            if (input.Id.HasValue)
            {
                var output = await _imageRepository.GetAsync(input.Id.Value);
                return ObjectMapper.Map<GetForEditImageDto>(output);
            }

            return new GetForEditImageDto();
        }

        public byte[] ConvertIamgeToByte(IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var res = ms.ToArray();
                return res;
            }

        }
    }
}
