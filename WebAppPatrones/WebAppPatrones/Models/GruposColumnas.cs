using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class GruposColumnas
    {
        public GruposColumnas()
        {
            TipoAtributoGrupoMedicionNavigation = new HashSet<TipoAtributo>();
            TipoAtributoGrupoPedidoNavigation = new HashSet<TipoAtributo>();
        }

        [Key]
        public int IdGrupo { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion2 { get; set; }
        [Required]
        [StringLength(50)]
        public string Unidad { get; set; }
        public int IdColumna { get; set; }

        [InverseProperty("GrupoMedicionNavigation")]
        public virtual ICollection<TipoAtributo> TipoAtributoGrupoMedicionNavigation { get; set; }
        [InverseProperty("GrupoPedidoNavigation")]
        public virtual ICollection<TipoAtributo> TipoAtributoGrupoPedidoNavigation { get; set; }
    }
}
