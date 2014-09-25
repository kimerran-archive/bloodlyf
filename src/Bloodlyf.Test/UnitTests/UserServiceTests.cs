using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bloodlyf.Mvc.Controllers;
using Bloodlyf.Api.User;
using Bloodlyf.DataAccess.User;
using Bloodlyf.DataAccess;
using System.Web.Mvc;
using Bloodlyf.Domain;

namespace Bloodlyf.Test
{
    [TestClass]
    public class UserServiceTests
    {
        private UserService _userService;
        private int _userId;

        [TestInitialize]
        public void Setup()
        {
            var ctx = new BloodlyfContext();
            var uow = new UnitOfWork(ctx);
            var userRepository = new UserRepository(uow);
            _userService = new UserService(userRepository);

            // Cleanup first
            var users = userRepository.FindAll();
            foreach (var item in users)
            {
                userRepository.Delete(item);
            }

            // Add one user
            var user = TestCommon.CreateUser();

            userRepository.Create(user);
            _userId = user.Id;
        }

        [TestMethod]
        public void UserService_ShouldCreateNewUser()
        {
            var newUser = new User()
            {
                Username = "user2",
                Password = "nopassforuser2",
                Firstname = "AnotherUser",
                Lastname = "userlastname",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            var result = _userService.Create(newUser);
            var newId = newUser.Id;

            Assert.IsNotNull(newId);
            Assert.IsInstanceOfType(result, typeof(User));
        }

        [TestMethod]
        public void UserService_ShouldUpdateExistingUser()
        {
            var user = _userService.Find(_userId);
            user.Firstname = "modifiedfirstname";

            _userService.Update(user);

            var modifiedUser = _userService.Find(_userId);
            Assert.AreEqual("modifiedfirstname", modifiedUser.Firstname);
        }

        [TestMethod]
        public void UserService_ShouldDeleteExistingUser()
        {
            var user = _userService.Find(_userId);

            _userService.Delete(user);

            var deletedUser = _userService.Find(_userId);

            Assert.IsNotNull(user);
            Assert.IsNull(deletedUser);
        }


        [TestMethod]
        public void UserService_ShouldLoginExistingUser()
        {
            var result = _userService.Login("username", "password");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(User));
            Assert.AreEqual("userfirstname", result.Firstname);
        }

        [TestMethod]
        public void UserService_ShouldNotLoginNonExistingUser()
        {
            var result = _userService.Login("nonexisting", "user");
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UserService_ShouldVerifyExistingUsername()
        {
            var result = _userService.IsUsernameExists("username");
            Assert.IsTrue(result);
        }
    }
}
