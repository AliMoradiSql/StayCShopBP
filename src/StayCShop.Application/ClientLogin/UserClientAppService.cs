using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using StayCShop.Authorization.Users;
using StayCShop.ClientLogin.Dto;
using StayCShop.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StayCShop.ClientLogin
{
    public class UserClientAppService : StayCShopAppServiceBase, IUserClientAppService
    {
        private readonly IRepository<User, long> _userRepository;

        public UserClientAppService(IRepository<User, long> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsExsitEmail(string emailAddress)
        {
            return _userRepository.GetAll().Any(u => u.EmailAddress == emailAddress);
        }

        public async Task<long> InsertAndGetIdAsync(User user)
        {
            var output = await _userRepository.InsertAndGetIdAsync(user);
            return output;
        }

        public User LoginUser(ClientLoginDto loginDto)
        {
            string email = FixText.FixEmail(loginDto.EmailAddress);
            string pass = PasswordHelper.EncodePasswordMd5(loginDto.Password);

            var query = _userRepository.GetAll();
            var res1 = query.SingleOrDefault(x => x.Password == pass && x.EmailAddress == email);
            var res = query.FirstOrDefault(x => x.Password == pass && x.EmailAddress == email);

            if (res != null)
                return res;
            return new User();
        }

        public async Task<User> Get(long id)
        {
            return await _userRepository.GetAsync(id);
        }

        public async Task<User> GetUserByEmail(string emali)
        {
            return await _userRepository.GetAll().FirstOrDefaultAsync(u => u.EmailAddress == emali);
        }

        public async Task<User> GetUserByActiveCode(string activeCode)
        {
            //return await _userRepository.GetAsync(u => u.ActiveCode == activeCode);
            throw new NotImplementedException();
        }

        public async Task UpdateUser(User user)
        {
            await _userRepository.UpdateAsync(user);
        }

    }
}
