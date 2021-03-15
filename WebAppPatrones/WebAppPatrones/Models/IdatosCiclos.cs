using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    [Table("IDatosCiclos")]
    public partial class IdatosCiclos
    {
        [Column("id")]
        public int Id { get; set; }
        public int? Ciclo { get; set; }
        [StringLength(50)]
        public string Grado { get; set; }
        [StringLength(50)]
        public string GradoDes { get; set; }
        [StringLength(50)]
        public string Diametro { get; set; }
        [StringLength(50)]
        public string Espesor { get; set; }
        [StringLength(50)]
        public string Acero { get; set; }
    }
}
