using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using StayCShop.Configuration;

namespace StayCShop.Web.Host.Startup
{
    [DependsOn(
       typeof(StayCShopWebCoreModule))]
    public class StayCShopWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public StayCShopWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(StayCShopWebHostModule).GetAssembly());
        }
    }
}
