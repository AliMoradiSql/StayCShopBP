using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using StayCShop.EntityFrameworkCore;
using StayCShop.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace StayCShop.Web.Tests
{
    [DependsOn(
        typeof(StayCShopWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class StayCShopWebTestModule : AbpModule
    {
        public StayCShopWebTestModule(StayCShopEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(StayCShopWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(StayCShopWebMvcModule).Assembly);
        }
    }
}