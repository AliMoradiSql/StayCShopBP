using System.Collections.Generic;
using StayCShop.Roles.Dto;

namespace StayCShop.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}