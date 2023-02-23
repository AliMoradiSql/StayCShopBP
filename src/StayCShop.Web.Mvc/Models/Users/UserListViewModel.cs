using System.Collections.Generic;
using StayCShop.Roles.Dto;

namespace StayCShop.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
