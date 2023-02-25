using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.ProductDiscounts.Dto
{
    public class GetAllProductDiscountInput : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        public string Filter { get; set; }
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
                Sorting = "CreationTime Desc";

            Filter = Filter?.Trim();
        }
    }
}
