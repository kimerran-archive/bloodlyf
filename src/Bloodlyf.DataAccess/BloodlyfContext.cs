using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain = Bloodlyf.Domain;
namespace Bloodlyf.DataAccess
{
    public class BloodlyfContext : DbContext
    {
        public BloodlyfContext()
            : base("BloodlyfDb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.User>()
                .HasOptional(b => b.DonorProfile)
                .WithOptionalDependent()
                .Map(x => x.MapKey("donor_profile_id"));

            modelBuilder.Entity<Domain.User>()
                .HasOptional(b => b.SeekerProfile)
                .WithOptionalDependent()                
                .Map(x => x.MapKey("seeker_profile_id"));

            modelBuilder.Entity<Domain.User>()
                .HasMany(b => b.DonationEvents)
                .WithOptional()
                .Map(x => x.MapKey("user_id"));

            modelBuilder.Entity<Domain.User>()
                .HasMany(b => b.Requests)
                .WithOptional()
                .Map(x => x.MapKey("user_id"));

        }

        public DbSet<Domain.User> Users { get; set; }
        public DbSet<Domain.SeekerProfile> SeekerProfiles { get; set; }
        public DbSet<Domain.DonorProfile> DonorProfiles { get; set; }
        public DbSet<Domain.BloodRequest> BloodRequests { get; set; }
        public DbSet<Domain.BloodDonationEvent> BloodDonationEvents { get; set; }

    }
}
