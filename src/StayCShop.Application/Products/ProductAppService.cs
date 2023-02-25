using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using StayCShop.Entities;
using StayCShop.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Http;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using Abp.IO.Extensions;

namespace StayCShop.Products
{
    public class ProductAppService : StayCShopAppServiceBase, IProductAppService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductAppService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PagedResultDto<ProductListDto>> GetAll(GetAllProductInput input)
        {
            var query = _productRepository.GetAllIncluding(x => x.Images)
                .WhereIf(!string.IsNullOrEmpty(input.Filter), x => x.Name.Contains(input.Filter));

            var count = await query.CountAsync();

            var data = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var mappedData = ObjectMapper.Map<List<ProductListDto>>(data);

            return new PagedResultDto<ProductListDto>(count, mappedData);

        }

        public async Task CreateOrUpdate(CreateOrEditProductDto input)
        {
            if (input.Id.HasValue)
            {
                await _productRepository.UpdateAsync(ObjectMapper.Map<Product>(input));
            }

            else
                await _productRepository.InsertAsync(ObjectMapper.Map<Product>(input));
        }

        public async Task Delete(EntityDto input)
        {
            await _productRepository.DeleteAsync(x => x.Id == input.Id);
        }

        public async Task<GetForEditProductDto> GetForEdit(NullableIdDto input)
        {
            if (input.Id.HasValue)
            {
                var output = await _productRepository.GetAsync(input.Id.Value);
                //output.CoverImage = GetImage(Convert.ToBase64String(output.CoverImage));
                return ObjectMapper.Map<GetForEditProductDto>(output);
            }

            return new GetForEditProductDto();
        }

        public byte[] ConvertIamgeToByte(IFormFile file)
        {
            //byte[] fileBytes;
            //using (var stream = file.OpenReadStream())
            //{
            //    fileBytes = stream.GetAllBytes();
            //    return fileBytes;
            //}
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var res = ms.ToArray();
                return res;
            }


            //using (var stream = file.OpenReadStream())
            //{
            //    using (System.Drawing.Image img = System.Drawing.Image.FromStream(stream))
            //    {
            //        //var id = Guid.NewGuid();
            //        //fileName = id + extension;
            //        if (img.Width > 100)
            //        {
            //            using System.Drawing.Image thumbnail = img.GetThumbnailImage(100, 100, null, IntPtr.Zero);
            //            using MemoryStream ms = new();
            //            thumbnail.Save(ms, ImageFormat.Jpeg);
            //        }
            //    }
            //}
        }

        private byte[] GetImage(string base64)
        {
            byte[] imageBytes = null;

            if (!string.IsNullOrEmpty(base64))
            {
                imageBytes = Convert.FromBase64String(base64);
            }
            return imageBytes;
        }
    }
}
