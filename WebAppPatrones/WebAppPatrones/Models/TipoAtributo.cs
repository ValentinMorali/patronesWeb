using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class TipoAtributo
    {
        public TipoAtributo()
        {
            AtributosDefecto = new HashSet<AtributosDefecto>();
            ValoresAtributos = new HashSet<ValoresAtributos>();
        }

        [Key]
        [Column("idAtributo")]
        public int IdAtributo { get; set; }
        [StringLength(80)]
        public string Descripcion { get; set; }
        [StringLength(32)]
        public string Unidad { get; set; }
        public short? AtMarca { get; set; }
        [StringLength(80)]
        public string Descripcion2 { get; set; }
        public int? Tolerancia { get; set; }
        public int? GrupoPedido { get; set; }
        public int? GrupoMedicion { get; set; }
        public int? Decimales { get; set; }

        [ForeignKey("GrupoMedicion")]
        [InverseProperty("TipoAtributoGrupoMedicionNavigation")]
        public virtual GruposColumnas GrupoMedicionNavigation { get; set; }
        [ForeignKey("GrupoPedido")]
        [InverseProperty("TipoAtributoGrupoPedidoNavigation")]
        public virtual GruposColumnas GrupoPedidoNavigation { get; set; }
        [ForeignKey("Tolerancia")]
        [InverseProperty("TipoAtributo")]
        public virtual Tolerancia ToleranciaNavigation { get; set; }
        [InverseProperty("IdAtributoNavigation")]
        public virtual ICollection<AtributosDefecto> AtributosDefecto { get; set; }
        [InverseProperty("IdAtributoNavigation")]
        public virtual ICollection<ValoresAtributos> ValoresAtributos { get; set; }
    }
}
