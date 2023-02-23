using System.Threading.Tasks;
using StayCShop.Models.TokenAuth;
using StayCShop.Web.Controllers;
using Shouldly;
using Xunit;

namespace StayCShop.Web.Tests.Controllers
{
    public class HomeController_Tests: StayCShopWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}