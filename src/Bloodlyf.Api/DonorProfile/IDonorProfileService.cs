using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Bloodlyf.Domain;
using Enums = Bloodlyf.Domain.Enums;

namespace Bloodlyf.Api.DonorProfile
{
    public interface IDonorProfileService : IBaseService<Domain.DonorProfile>
    {
        IEnumerable<Domain.DonorProfile> SearchByBloodType(Enums.BloodType bloodType);

        IEnumerable<Domain.DonorProfile> SearchByGender(Enums.GenderType gender);

    }
}
