using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.Images.Dto
{
    public class ImageListDto : EntityDto
    {
        public string Title { get; set; }
        public byte[] image { get; set; }
        public byte[]? Thumbnail { get; set; }
        public string Description { get; set; }
    }
}
