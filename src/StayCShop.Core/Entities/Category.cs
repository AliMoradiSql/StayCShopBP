using Abp.Domain.Entities.Auditing;
using System.Collections.Generic;

#nullable disable

namespace StayCShop.Entities
{
    public class Category : FullAuditedEntity
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new HashSet<ProductCategory>();
    }
}
