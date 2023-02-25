using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.ProductDiscounts.Dto
{
    public class CreateOrEditProductDiscountDto : NullableIdDto
    {
        public int DiscountId { get; set; }
        public int ProductId { get; set; }
    }
}
