using Bloodlyf.Api.DonorProfile;
using Bloodlyf.Api.User;
using Bloodlyf.DataAccess;
using Bloodlyf.DataAccess.DonorProfile;
using Bloodlyf.DataAccess.User;
using Bloodlyf.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloodlyf.Test.UnitTests
{
    [TestClass]
    public class DonorProfileServiceTests
    {
        private DonorProfileService _donorProfileService;
        private UserService _userService;
        private int _userId;
        private int _donorProfileId;

        [TestInitialize]
        public void Setup()
        {
            var ctx = new BloodlyfContext();
            var uow = new UnitOfWork(ctx);
            var donorRepository = new DonorProfileRepository(uow);
            var userRepository = new UserRepository(uow);

            _donorProfileService = new DonorProfileService(donorRepository, userRepository);

            _userService = new UserService(userRepository);

            // Cleanup first
            foreach (var item in userRepository.FindAll())
            {
                userRepository.Delete(item);
            }
            foreach (var item in donorRepository.FindAll())
            {
                donorRepository.Delete(item);
            }

            // Add one user
            var user = TestCommon.CreateUser();

            user.DonorProfile = TestCommon.CreateDonorProfile();

            userRepository.Create(user);
            _userId = user.Id;
            _donorProfileId = user.DonorProfile.Id;
        }

        [TestMethod]
        public void DonorProfileService_ShouldAddDonorProfileToExistingUser()
        {
            var donorProfile = new DonorProfile()
            {
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                BloodType = Domain.Enums.BloodType.O,
                Gender = Domain.Enums.GenderType.Male,
                Location = "Pasay City",
                Age = 18
            };
            
            var user = _userService.Find(_userId);

            var result = _donorProfileService.Create(donorProfile, user);

            Assert.IsNotNull(result);
            Assert.AreEqual("Pasay City", result.Location);
        }

        [TestMethod]
        public void DonorProfileService_ShouldUpdateExistingDonorProfile()
        {
            var donorProfile = _donorProfileService.Find(_donorProfileId);
            donorProfile.Location = "Cavite";

            _donorProfileService.Update(donorProfile);

            var modifiedDonorProfile = _donorProfileService.Find(_donorProfileId);
            
            Assert.IsNotNull(modifiedDonorProfile);
            Assert.AreEqual("Cavite", modifiedDonorProfile.Location);
        }

        [TestMethod]
        public void DonorProfileService_ShouldUpdateDonorProfileNavigatedFromUser()
        {
            var user = _userService.Find(_userId);

            var donorProfile = user.DonorProfile;
            donorProfile.Location = "New Location";

            _donorProfileService.Update(donorProfile);

            var getUser = _userService.Find(_userId);
            var modifiedDonorProfile = getUser.DonorProfile;

            Assert.IsNotNull(modifiedDonorProfile);
            Assert.AreEqual("New Location", modifiedDonorProfile.Location);
        }

        [TestMethod]
        public void DonorProfileService_SearchByGenderHaveResults()
        {
            var results = _donorProfileService.SearchByGender(Domain.Enums.GenderType.Female);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count() > 0);
        }

        [TestMethod]
        public void DonorProfileService_SearchByGenderHaveNoResult()
        {
            var results = _donorProfileService.SearchByGender(Domain.Enums.GenderType.Male);

            Assert.IsNotNull(results);
            Assert.AreEqual(0, results.Count());
        }

        [TestMethod]
        public void DonorProfileService_SearchByBloodTypeHaveResults()
        {
            var results = _donorProfileService.SearchByBloodType(Domain.Enums.BloodType.AB);

            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count() > 0);
        }

        [TestMethod]
        public void DonorProfileService_SearchByBloodTypeHaveNoResult()
        {
            var results = _donorProfileService.SearchByBloodType(Domain.Enums.BloodType.O);

            Assert.IsNotNull(results);
            Assert.AreEqual(0, results.Count());
        }



    }
}
