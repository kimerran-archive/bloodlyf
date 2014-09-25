using Bloodlyf.DataAccess.DonorProfile;
using Bloodlyf.DataAccess.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Bloodlyf.Domain;
using Enums = Bloodlyf.Domain.Enums;

namespace Bloodlyf.Api.DonorProfile
{
    public class DonorProfileService : BaseService<Domain.DonorProfile>, IDonorProfileService
    {
        private IDonorProfileRepository _donorProfileRepository;
        private IUserRepository _userRepository;

        public DonorProfileService(IDonorProfileRepository donorProfileRepository,
                                   IUserRepository userRepository)
            : base(donorProfileRepository)
        {
            _donorProfileRepository = donorProfileRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<Domain.DonorProfile> Search(string searchTerm)
        {
            return _donorProfileRepository.FindAll();
        }

        public IEnumerable<Domain.DonorProfile> SearchByBloodType(Enums.BloodType bloodType, int limit = 15)
        {
            return _donorProfileRepository.FindAll()
                     .Where(o => o.BloodType == bloodType)
                     .Take(limit)
                     .ToList();
        }

        public IEnumerable<Domain.DonorProfile> SearchByGender(Enums.GenderType gender, int limit = 15)
        {
            return _donorProfileRepository.FindAll()
                     .Where(o => o.Gender == gender)
                     .Take(limit)
                     .ToList();
        }

        public Domain.DonorProfile Create(Domain.DonorProfile donorProfile, Domain.User user)
        {
            var getUser = _userRepository.Find(user.Id);
            getUser.DonorProfile = donorProfile;

            _userRepository.Update(getUser);
            var newDonorProfileId = getUser.DonorProfile.Id;

            return _donorProfileRepository.FindAll()
                    .Where(o => o.Id == newDonorProfileId)
                    .SingleOrDefault();

        }
    }
}
