using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            DefectosPatrones = new HashSet<DefectosPatrones>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Nombre { get; set; }
        [StringLength(50)]
        public string Apellido { get; set; }
        [Column("EMail")]
        [StringLength(150)]
        public string Email { get; set; }
        [Required]
        [Column("NRegistro")]
        [StringLength(10)]
        public string Nregistro { get; set; }
        [StringLength(10)]
        public string Clave { get; set; }
        public int? Nivel { get; set; }
        public bool? CertificaDefectos { get; set; }
        public bool? CargaPatrones { get; set; }
        public bool? CargaPedidos { get; set; }
        [Column("idRemitente")]
        public int? IdRemitente { get; set; }

        [InverseProperty("IdResponsableNavigation")]
        public virtual ICollection<DefectosPatrones> DefectosPatrones { get; set; }
    }
}
