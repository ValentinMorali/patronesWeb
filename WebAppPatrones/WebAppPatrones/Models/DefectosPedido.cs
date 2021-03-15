using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class DefectosPedido
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("idPedido")]
        public int IdPedido { get; set; }
        [Column("idTipoDefecto")]
        public int IdTipoDefecto { get; set; }
        [StringLength(2)]
        public string Letra { get; set; }

        [ForeignKey("IdPedido")]
        [InverseProperty("DefectosPedido")]
        public virtual Pedidos IdPedidoNavigation { get; set; }
        [ForeignKey("IdTipoDefecto")]
        [InverseProperty("DefectosPedido")]
        public virtual TipoDefecto IdTipoDefectoNavigation { get; set; }
    }
}
