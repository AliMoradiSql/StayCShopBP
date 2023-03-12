using StayCShop.Authorization.Users;
using StayCShop.ClientLogin.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.ClientLogin
{
    public interface IUserClientAppService
    {
        bool IsExsitEmail(string emailAddress);
        User LoginUser(ClientLoginDto loginDto);
        Task<long> InsertAndGetIdAsync(User user);
        Task<User> Get(long id);
        Task<User> GetUserByEmail(string emali);
        Task<User> GetUserByActiveCode(string activeCode);
        Task UpdateUser(User user);
    }
}
