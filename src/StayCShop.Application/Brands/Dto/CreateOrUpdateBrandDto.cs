using Abp.Application.Services.Dto;

namespace StayCShop.Brands.Dto
{
    public class CreateOrUpdateBrandDto : NullableIdDto
    {
        public string BrandName { get; set; }
    }
}
