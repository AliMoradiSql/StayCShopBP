using Abp.Application.Services.Dto;
using StayCShop.Categories.Dto;
using StayCShop.Entities;
using StayCShop.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.ProductCategories.Dto
{
    public class ProductCategoryListDto : EntityDto
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        public  CategoryListDto Category { get; set; }
        public  ProductListDto Product { get; set; }
    }
}
