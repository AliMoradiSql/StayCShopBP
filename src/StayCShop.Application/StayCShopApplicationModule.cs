using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using StayCShop.Authorization;

namespace StayCShop
{
    [DependsOn(
        typeof(StayCShopCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class StayCShopApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<StayCShopAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(StayCShopApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
