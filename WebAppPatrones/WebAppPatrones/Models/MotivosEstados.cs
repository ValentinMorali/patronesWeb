using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class MotivosEstados
    {
        public MotivosEstados()
        {
            Patron = new HashSet<Patron>();
        }

        [Key]
        [Column("idMotivo")]
        public int IdMotivo { get; set; }
        [Column("descripcion")]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [InverseProperty("IdMotivoNavigation")]
        public virtual ICollection<Patron> Patron { get; set; }
    }
}
