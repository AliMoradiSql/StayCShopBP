using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using StayCShop.Authorization.Roles;
using StayCShop.Authorization.Users;
using StayCShop.MultiTenancy;
using StayCShop.Entities;

namespace StayCShop.EntityFrameworkCore
{
    public class StayCShopDbContext : AbpZeroDbContext<Tenant, Role, User, StayCShopDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartDetail> CartDetails { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public virtual DbSet<Image> Images { get; set; }

        public StayCShopDbContext(DbContextOptions<StayCShopDbContext> options)
            : base(options)
        {
        }
    }
}
