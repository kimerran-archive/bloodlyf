using Bloodlyf.DataAccess.BloodRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloodlyf.Api.BloodRequest
{
    public class BloodRequestService : BaseService<Domain.BloodRequest>, IBloodRequestService
    {
        private IBloodRequestRepository _bloodRequestRepository;
        public BloodRequestService(IBloodRequestRepository bloodRequestRepository)
            :base(bloodRequestRepository)
        {
            _bloodRequestRepository = bloodRequestRepository;
        }
    }
}
