using Abp.Application.Services.Dto;
using Castle.MicroKernel.SubSystems.Conversion;
using StayCShop.Brands.Dto;
using StayCShop.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.Products.Dto
{
    public class ProductListDto : EntityDto
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
        public string BrandName { get; set; }
    }
}
