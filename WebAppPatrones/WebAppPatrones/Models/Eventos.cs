using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class Eventos
    {
        [Key]
        [Column("oid")]
        public int Oid { get; set; }
        [StringLength(10)]
        public string Operador { get; set; }
        [StringLength(50)]
        public string Evento { get; set; }
        [StringLength(50)]
        public string Tabla { get; set; }
        public int? Registro { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Fecha { get; set; }
    }
}
