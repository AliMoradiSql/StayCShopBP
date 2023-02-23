using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;

#nullable disable

namespace StayCShop.Entities
{
    public partial class CartDetail : FullAuditedEntity
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Count { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}
