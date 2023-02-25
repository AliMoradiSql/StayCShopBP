using Abp.Application.Services.Dto;
using StayCShop.Discounts.Dto;
using StayCShop.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.ProductDiscounts.Dto
{
    public class ProductDiscountListDto : EntityDto
    {
        public int DiscountId { get; set; }
        public int ProductId { get; set; }

        public DiscountListDto Discount { get; set; }
        public ProductListDto Product { get; set; }
    }
}
