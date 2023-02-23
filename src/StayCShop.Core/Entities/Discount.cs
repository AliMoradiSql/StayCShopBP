using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

#nullable disable

namespace StayCShop.Entities
{
    public partial class Discount : FullAuditedEntity
    {
        public byte Percent { get; set; }
        public string DiscountName { get; set; }
        public DateTime ExpireDate { get; set; }

        public virtual ICollection<ProductDiscount> ProductDiscounts { get; set; } = new HashSet<ProductDiscount>();
    }
}
