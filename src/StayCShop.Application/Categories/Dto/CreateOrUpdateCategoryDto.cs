using Abp.Application.Services.Dto;

namespace StayCShop.Categories.Dto
{
    public class CreateOrUpdateCategoryDto : NullableIdDto
    {
        public string CategoryName { get; set; }
    }
}
