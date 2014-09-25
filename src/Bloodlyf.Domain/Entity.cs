using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloodlyf.Domain
{
    public class Entity
    {

        [Column("id"), Key]
        public int Id { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by"), MaxLength(50)]
        public string CreatedBy { get; set; }

        [Column("modified_at")]
        public DateTime ModifiedAt { get; set; }

        [Column("modified_by"),MaxLength(50)]
        public string ModifiedBy { get; set; }
    }
}
