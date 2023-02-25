using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.Discounts.Dto
{
    public class DiscountListDto  : EntityDto
    {
        public byte Percent { get; set; }
        public string DiscountName { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
