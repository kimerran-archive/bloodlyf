using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloodlyf.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bloodlyf.Domain
{
    public class DonorProfile : Entity
    {        
        [Column("blood_type")]
        public BloodType BloodType { get; set; }
        
        [Column("gender")]
        public GenderType Gender { get; set; }

        [Column("age")]
        public int Age { get; set; }
        
        [Column("location"), MaxLength(50)]
        public string Location { get; set; }

    }
}
