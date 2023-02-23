using Abp.Authorization;
using StayCShop.Authorization.Roles;
using StayCShop.Authorization.Users;

namespace StayCShop.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
