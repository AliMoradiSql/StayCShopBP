using System.Collections.Generic;
using StayCShop.Roles.Dto;

namespace StayCShop.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
