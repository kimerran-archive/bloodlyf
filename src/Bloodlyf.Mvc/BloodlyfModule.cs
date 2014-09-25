using Autofac;
using Bloodlyf.Api.User;
using Bloodlyf.Api.DonorProfile;
using Bloodlyf.DataAccess.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bloodlyf.DataAccess.DonorProfile;
using Bloodlyf.Api.SeekerProfile;
using Bloodlyf.DataAccess.SeekerProfile;
using Bloodlyf.Api.BloodRequest;
using Bloodlyf.DataAccess.BloodRequest;
using Bloodlyf.Api.BloodDonationEvent;
using Bloodlyf.DataAccess.BloodDonationEvent;

namespace Bloodlyf.Mvc
{
    public class BloodlyfModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<DonorProfileService>().As<IDonorProfileService>();
            builder.RegisterType<SeekerProfileService>().As<ISeekerProfileService>();
            builder.RegisterType<BloodRequestService>().As<IBloodRequestService>();
            builder.RegisterType<BloodDonationEventService>().As<IBloodDonationEventService>();

            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<DonorProfileRepository>().As<IDonorProfileRepository>();
            builder.RegisterType<SeekerProfileRepository>().As<ISeekerProfileRepository>();
            builder.RegisterType<BloodRequestRepository>().As<IBloodRequestRepository>();
            builder.RegisterType<BloodDonationEventRepository>().As<IBloodDonationEventRepository>();

        }
    }
    
}