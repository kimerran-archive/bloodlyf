using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Bloodlyf.Domain;

namespace Bloodlyf.DataAccess.BloodRequest
{
    public class BloodRequestRepository : BaseRepository<Domain.BloodRequest>, IBloodRequestRepository
    {
        public BloodRequestRepository(IUnitOfWork uow)
            :base(uow)
        {

        }
    }
}
