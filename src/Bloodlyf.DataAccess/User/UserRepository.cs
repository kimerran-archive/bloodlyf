using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Bloodlyf.Domain;

namespace Bloodlyf.DataAccess.User
{
    public class UserRepository : BaseRepository<Domain.User>, IUserRepository
    {
        private IUnitOfWork _uow;
        public UserRepository(IUnitOfWork uow)
            :base(uow)
        {
            _uow = uow;
        }
    }
}
