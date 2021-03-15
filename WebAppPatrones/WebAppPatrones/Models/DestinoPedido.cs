using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class DestinoPedido
    {
        public DestinoPedido()
        {
            Pedidos = new HashSet<Pedidos>();
        }

        [Key]
        public int IdDestino { get; set; }
        [Required]
        [StringLength(150)]
        public string Descripcion { get; set; }

        [InverseProperty("IdDestinoNavigation")]
        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}
