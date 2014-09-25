using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Bloodlyf.Domain;

namespace Bloodlyf.DataAccess.SeekerProfile
{
    public class SeekerProfileRepository : BaseRepository<Domain.SeekerProfile>, ISeekerProfileRepository
    {
        public SeekerProfileRepository(IUnitOfWork uow)
            :base(uow)
        {

        }
    }
}
