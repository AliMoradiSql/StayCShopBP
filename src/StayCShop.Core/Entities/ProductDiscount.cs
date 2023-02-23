using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;


namespace StayCShop.Entities
{
    public partial class ProductDiscount : FullAuditedEntity
    {
        public int DiscountId { get; set; }
        public int ProductId { get; set; }

        public virtual Discount Discount { get; set; }
        public virtual Product Product { get; set; }
    }
}
