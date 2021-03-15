using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class BindLine
    {
        [Key]
        public int IdBindLine { get; set; }
        public int? IdLine { get; set; }
        public int? IdLinea { get; set; }

        [ForeignKey("IdLine")]
        [InverseProperty("BindLine")]
        public virtual Line IdLineNavigation { get; set; }
        [ForeignKey("IdLinea")]
        [InverseProperty("BindLine")]
        public virtual Linea IdLineaNavigation { get; set; }
    }
}
