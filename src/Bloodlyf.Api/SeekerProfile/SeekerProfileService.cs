using Bloodlyf.DataAccess.SeekerProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Bloodlyf.Domain;
namespace Bloodlyf.Api.SeekerProfile
{
    public class SeekerProfileService : BaseService<Domain.SeekerProfile>, ISeekerProfileService
    {
        private ISeekerProfileRepository _seekerProfileRepository;
        public SeekerProfileService(ISeekerProfileRepository seekerRepository)
            :base(seekerRepository)
        {
            _seekerProfileRepository = seekerRepository;
        }
    }
}
