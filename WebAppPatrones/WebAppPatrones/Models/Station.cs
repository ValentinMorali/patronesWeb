using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class Station
    {
        public Station()
        {
            InspectionLine = new HashSet<InspectionLine>();
        }

        [Key]
        public int IdStation { get; set; }
        public int? IdLine { get; set; }
        public int? Number { get; set; }
        [StringLength(32)]
        public string Name { get; set; }
        [StringLength(80)]
        public string Description { get; set; }

        [ForeignKey("IdLine")]
        [InverseProperty("Station")]
        public virtual Line IdLineNavigation { get; set; }
        [InverseProperty("IdStationNavigation")]
        public virtual ICollection<InspectionLine> InspectionLine { get; set; }
    }
}
