using Abp.Domain.Entities.Auditing;
using Castle.MicroKernel.SubSystems.Conversion;
using StayCShop.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace StayCShop.Entities
{
    public class Cart : FullAuditedEntity
    {
        public DateTime OrderDate { get; set; }
        public long UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; } = new HashSet<CartDetail>();
    }
}
