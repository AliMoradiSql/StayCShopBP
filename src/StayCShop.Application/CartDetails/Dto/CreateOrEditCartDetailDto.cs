using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.CartDetails.Dto
{
    public class CreateOrEditCartDetailDto : NullableIdDto
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Count { get; set; }
    }
}
