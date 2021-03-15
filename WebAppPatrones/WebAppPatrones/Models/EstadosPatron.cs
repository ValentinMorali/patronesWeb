using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class EstadosPatron
    {
        public EstadosPatron()
        {
            Patron = new HashSet<Patron>();
            Pedidos = new HashSet<Pedidos>();
        }

        [Key]
        public int Status { get; set; }
        [StringLength(32)]
        public string Descripcion { get; set; }
        public bool? Existe { get; set; }

        [InverseProperty("IdEstadoNavigation")]
        public virtual ICollection<Patron> Patron { get; set; }
        [InverseProperty("IdEstadoNavigation")]
        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}
