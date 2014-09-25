using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bloodlyf.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bloodlyf.Domain
{
    public class BloodRequest : Entity
    {
        [Column("title"), MaxLength(50)]
        public string Title { get; set; }

        [Column("details"),MaxLength(500)]
        public string Details { get; set; }

        [Column("location"), MaxLength(50)]
        public string Location { get; set; }
        
        [Column("urgency")]
        public UrgencyType Urgency { get; set; }
    }
}
