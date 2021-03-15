using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class HistoricoPasadasPatron
    {
        [Column(TypeName = "datetime")]
        public DateTime? Fecha { get; set; }
        public int IdPatron { get; set; }
        [StringLength(16)]
        public string Centro { get; set; }
        [StringLength(16)]
        public string Puesto { get; set; }
        [Column("id")]
        public int Id { get; set; }
        public bool? Original { get; set; }

        [ForeignKey("IdPatron")]
        [InverseProperty("HistoricoPasadasPatron")]
        public virtual Patron IdPatronNavigation { get; set; }
    }
}
