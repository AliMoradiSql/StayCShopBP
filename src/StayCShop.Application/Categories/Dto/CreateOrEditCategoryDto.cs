using Abp.Application.Services.Dto;

namespace StayCShop.Categories.Dto
{
    public class CreateOrEditCategoryDto : NullableIdDto
    {
        public string CategoryName { get; set; }
    }
}
