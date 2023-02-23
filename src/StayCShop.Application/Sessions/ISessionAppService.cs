using System.Threading.Tasks;
using Abp.Application.Services;
using StayCShop.Sessions.Dto;

namespace StayCShop.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
