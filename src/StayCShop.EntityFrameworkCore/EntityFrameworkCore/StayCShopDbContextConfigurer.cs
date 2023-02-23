using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace StayCShop.EntityFrameworkCore
{
    public static class StayCShopDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<StayCShopDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<StayCShopDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
