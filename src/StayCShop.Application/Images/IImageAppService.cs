using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Http;
using StayCShop.Images.Dto;
using System.Threading.Tasks;

namespace StayCShop.Images
{
    public interface IImageAppService
    {
        Task<PagedResultDto<ImageListDto>> GetAll(GetAllImageInput input);
        Task CreateOrUpdate(CreateOrEditImageDto input);
        Task Delete(EntityDto input);
        Task<GetForEditImageDto> GetForEdit(NullableIdDto input);
        byte[] ConvertIamgeToByte(IFormFile file);
    }
}