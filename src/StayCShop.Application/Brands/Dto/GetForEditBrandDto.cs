using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.Brands.Dto
{
    public class GetForEditBrandDto : NullableIdDto
    {
        public string BrandName { get; set; }
    }
}
