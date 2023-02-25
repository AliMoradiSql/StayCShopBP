using Abp.Application.Services.Dto;

namespace StayCShop.Brands.Dto
{
    public class CreateOrEditBrandDto : NullableIdDto
    {
        public string BrandName { get; set; }
    }
}
