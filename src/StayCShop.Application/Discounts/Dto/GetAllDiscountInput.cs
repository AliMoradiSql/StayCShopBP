using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.Discounts.Dto
{
    public class GetAllDiscountInput : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        public string Filter { get; set; }
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
                Sorting = "DiscountName Asc";
            Filter = Filter?.Trim();
        }
    }
}
