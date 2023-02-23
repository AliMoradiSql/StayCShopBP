using Abp.Domain.Entities.Auditing;


namespace StayCShop.Entities
{
    public partial class ProductCategory : FullAuditedEntity
    {
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
    }
}
