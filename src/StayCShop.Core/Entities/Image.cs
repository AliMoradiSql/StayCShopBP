using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.Entities
{
    public class Image : FullAuditedEntity
    {
        public string Title { get; set; }
        public byte[] image { get; set; }
        public byte[]? Thumbnail { get; set; }
        public string Description { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }


    }
}
