using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class Ubicacion
    {
        public Ubicacion()
        {
            Patron = new HashSet<Patron>();
        }

        [Key]
        [Column("idUbicacion")]
        public int IdUbicacion { get; set; }
        [Column("idlinea")]
        public int Idlinea { get; set; }
        [StringLength(20)]
        public string Grupo { get; set; }
        [StringLength(20)]
        public string Patronera { get; set; }
        [StringLength(20)]
        public string Brazo { get; set; }
        [StringLength(20)]
        public string Lado { get; set; }

        [ForeignKey("Idlinea")]
        [InverseProperty("Ubicacion")]
        public virtual Linea IdlineaNavigation { get; set; }
        [InverseProperty("IdUbicacionNavigation")]
        public virtual ICollection<Patron> Patron { get; set; }
    }
}
