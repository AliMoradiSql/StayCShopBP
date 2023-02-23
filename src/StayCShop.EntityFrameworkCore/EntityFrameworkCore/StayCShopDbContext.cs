using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using StayCShop.Authorization.Roles;
using StayCShop.Authorization.Users;
using StayCShop.MultiTenancy;

namespace StayCShop.EntityFrameworkCore
{
    public class StayCShopDbContext : AbpZeroDbContext<Tenant, Role, User, StayCShopDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public StayCShopDbContext(DbContextOptions<StayCShopDbContext> options)
            : base(options)
        {
        }
    }
}
