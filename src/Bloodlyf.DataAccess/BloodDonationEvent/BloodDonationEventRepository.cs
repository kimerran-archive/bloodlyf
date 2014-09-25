using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Bloodlyf.Domain;

namespace Bloodlyf.DataAccess.BloodDonationEvent
{
    public class BloodDonationEventRepository : BaseRepository<Domain.BloodDonationEvent>, IBloodDonationEventRepository
    {
        public BloodDonationEventRepository(IUnitOfWork uow)
            :base(uow)
        {

        }
    }
}
