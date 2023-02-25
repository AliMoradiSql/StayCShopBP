using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.CartDetails.Dto
{
    public class GetAllCartDetailInput : PagedAndSortedResultRequestDto, IShouldNormalize
    {
        public string Filter { get; set; }

        public int? CartId { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
                Sorting = "CreationTime DESC";
            Filter = Filter?.Trim();
        }
    }
}
