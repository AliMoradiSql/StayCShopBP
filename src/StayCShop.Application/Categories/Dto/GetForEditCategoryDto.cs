﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.Categories.Dto
{
    public class GetForEditCategoryDto : NullableIdDto
    {
        public string CategoryName { get; set; }
    }
}
