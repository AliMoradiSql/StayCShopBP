using System.Threading.Tasks;
using StayCShop.Configuration.Dto;

namespace StayCShop.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
