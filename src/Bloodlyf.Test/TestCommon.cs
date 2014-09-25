using Bloodlyf.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloodlyf.Test
{
    public class TestCommon
    {
        public static User CreateUser()
        {
            return new User()
            {
                Username = "username",
                Password = "password",
                Firstname = "userfirstname",
                Lastname = "userlastname",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };
        }

        public static DonorProfile CreateDonorProfile()
        {
            return new DonorProfile()
            {
                Age = 12,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Gender = Domain.Enums.GenderType.Female,
                BloodType = Domain.Enums.BloodType.AB,
                Location = "Manila",
            };
        }
    }
}
