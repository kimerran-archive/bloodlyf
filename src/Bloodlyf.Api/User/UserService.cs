using Bloodlyf.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloodlyf.DataAccess.User;
using Domain = Bloodlyf.Domain;

namespace Bloodlyf.Api.User
{
    public class UserService : BaseService<Domain.User>, IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
            : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public Domain.User Login(string username, string password)
        {
            var matchCount = _userRepository.FindAll()
                .Where(o => o.Username == username 
                         && o.Password == password)
                .Count();

            if (matchCount > 1 || matchCount == 0) return null;

            return _userRepository.FindAll()
                 .Where(o => o.Username == username && o.Password == password)
                 .ToList()
                 .First();
        }

        public bool IsUsernameExists(string username)
        {
            return _userRepository.FindAll()
                 .Where(o => o.Username == username)
                 .Count() == 0 ? false : true;
        }
    }
}
