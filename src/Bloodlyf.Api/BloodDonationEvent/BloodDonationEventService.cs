using Bloodlyf.DataAccess.BloodDonationEvent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloodlyf.Api.BloodDonationEvent
{
    public class BloodDonationEventService : BaseService<Domain.BloodDonationEvent>, IBloodDonationEventService
    {
        private IBloodDonationEventRepository _bloodDonationEventRepository;
        public BloodDonationEventService(IBloodDonationEventRepository bloodDonationEventRepository)
            :base(bloodDonationEventRepository)
        {
            _bloodDonationEventRepository = bloodDonationEventRepository;
        }
    }
}
