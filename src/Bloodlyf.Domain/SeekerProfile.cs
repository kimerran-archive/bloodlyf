using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloodlyf.Domain
{
    public class SeekerProfile : Entity
    {
        [Column("special_instruction")]
        public string SpecialInstruction { get; set; }

        [Column("relationship_to_needy")]
        public string RelationshipToNeedy { get; set; }

    }
}

