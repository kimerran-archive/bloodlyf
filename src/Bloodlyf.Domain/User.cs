using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloodlyf.Domain
{
    public class User : Entity
    {
        [Column("username"), MaxLength(20)]
        public string Username { get; set; }

        [Column("password"), MaxLength(20)]
        public string Password { get; set; }

        [Column("email"), MaxLength(50)]
        public string Email { get; set; }

        [Column("first_name"),MaxLength(50)]
        public string Firstname { get; set; }
        
        [Column("last_name"),MaxLength(50)]
        public string Lastname { get; set; }


        public virtual DonorProfile DonorProfile { get; set; }

        public virtual SeekerProfile SeekerProfile { get; set; }

        public virtual List<BloodRequest> Requests { get; set; }
        public virtual List<BloodDonationEvent> DonationEvents { get; set; }

    }
}
