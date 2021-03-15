using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class HistoricoPatronActivo
    {
        [Column("idPatron")]
        public int? IdPatron { get; set; }
        [Column("idDefecto")]
        public int? IdDefecto { get; set; }
        public bool? Activo { get; set; }
        public int? Posicion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Fecha { get; set; }
        public double? Referencia { get; set; }
        public double? Tolerancia { get; set; }
        public double? Profundidad { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
        public bool? Original { get; set; }
        [Key]
        [Column("OID")]
        public int Oid { get; set; }
    }
}
