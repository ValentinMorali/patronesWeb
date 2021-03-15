using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class Line
    {
        public Line()
        {
            BindLine = new HashSet<BindLine>();
            Station = new HashSet<Station>();
        }

        [Key]
        public int IdLine { get; set; }
        public int? IdZone { get; set; }
        [StringLength(32)]
        public string Name { get; set; }
        [StringLength(80)]
        public string Description { get; set; }

        [ForeignKey("IdZone")]
        [InverseProperty("Line")]
        public virtual Zone IdZoneNavigation { get; set; }
        [InverseProperty("IdLineNavigation")]
        public virtual ICollection<BindLine> BindLine { get; set; }
        [InverseProperty("IdLineNavigation")]
        public virtual ICollection<Station> Station { get; set; }
    }
}
