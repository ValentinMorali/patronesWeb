using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class InspectionLine
    {
        [Key]
        public int IdInspectionLine { get; set; }
        public int? IdStation { get; set; }
        [StringLength(80)]
        public string Description { get; set; }

        [ForeignKey("IdStation")]
        [InverseProperty("InspectionLine")]
        public virtual Station IdStationNavigation { get; set; }
    }
}
