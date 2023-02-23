using AutoMapper;
using StayCShop.Brands.Dto;
using StayCShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            //Brand
            configuration.CreateMap<Brand, BrandListDto>();
            configuration.CreateMap<Brand, GetForEditBrandDto>();
            configuration.CreateMap<CreateOrUpdateBrandDto, Brand>();
        }
    }
}
