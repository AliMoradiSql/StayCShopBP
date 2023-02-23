using Abp.Application.Services;
using StayCShop.MultiTenancy.Dto;

namespace StayCShop.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

