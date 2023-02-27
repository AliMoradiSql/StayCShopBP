using AutoMapper;
using StayCShop.Brands.Dto;
using StayCShop.CartDetails.Dto;
using StayCShop.Categories.Dto;
using StayCShop.Discounts.Dto;
using StayCShop.Entities;
using StayCShop.ProductCategories.Dto;
using StayCShop.ProductDiscounts.Dto;
using StayCShop.Products.Dto;
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
            //Product
            configuration.CreateMap<Product, ProductListDto>()
                .ForMember(x=>x.BrandName,option=>option.MapFrom(x=>x.Brand.BrandName));
            configuration.CreateMap<Product, GetForEditProductDto>();
            configuration.CreateMap<CreateOrEditProductDto, Product>();  
            
            //Brand
            configuration.CreateMap<Brand, BrandListDto>();
            configuration.CreateMap<Brand, GetForEditBrandDto>();
            configuration.CreateMap<CreateOrEditBrandDto, Brand>(); 
            
            //Category
            configuration.CreateMap<Category, CategoryListDto>();
            configuration.CreateMap<Category, GetForEditCategoryDto>();
            configuration.CreateMap<CreateOrEditCategoryDto, Category>();

            //CartDetail
            configuration.CreateMap<CartDetail, CartDetailListDto>();
            configuration.CreateMap<CartDetail, GetForEditCartDetailDto>();
            configuration.CreateMap<CreateOrEditCartDetailDto, CartDetail>();
            
            //ProductCategory
            configuration.CreateMap<ProductCategory, ProductCategoryListDto>();
            configuration.CreateMap<ProductCategory, GetForEditProductCategoryDto>();
            configuration.CreateMap<CreateOrEditProductCategoryDto, ProductCategory>();
            
            //ProductDiscount
            configuration.CreateMap<ProductDiscount, ProductDiscountListDto>();
            configuration.CreateMap<ProductDiscount, GetForEditProductDiscountDto>();
            configuration.CreateMap<CreateOrEditProductDiscountDto, ProductDiscount>();


            //Discount
            configuration.CreateMap<Discount, DiscountListDto>();
            configuration.CreateMap<Discount, GetForEditDiscountDto>();
            configuration.CreateMap<CreateOrEditDiscountDto, Discount>();
        }
    }
}
