using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class Zone
    {
        public Zone()
        {
            Line = new HashSet<Line>();
        }

        [Key]
        public int IdZone { get; set; }
        [StringLength(32)]
        public string Name { get; set; }
        [StringLength(80)]
        public string Description { get; set; }

        [InverseProperty("IdZoneNavigation")]
        public virtual ICollection<Line> Line { get; set; }
    }
}
