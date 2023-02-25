using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.CartDetails.Dto
{
    public class CartDetailListDto : EntityDto
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Count { get; set; }

        //public ProductListDto Product { get; set; }
    }
}
