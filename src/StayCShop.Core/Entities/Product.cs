using Abp.Domain.Entities.Auditing;
using Castle.MicroKernel.SubSystems.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace StayCShop.Entities
{
    public class Product : FullAuditedEntity
    {
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Material { get; set; }
        public short Quantity { get; set; }
        public byte[]? CoverImage { get; set; }
        public int? BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual ICollection<CartDetail> CartDetails { get; set; } = new HashSet<CartDetail>();
        public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new HashSet<ProductCategory>();
        public virtual ICollection<ProductDiscount> ProductDiscounts { get; set; } = new HashSet<ProductDiscount>();


    }
}
