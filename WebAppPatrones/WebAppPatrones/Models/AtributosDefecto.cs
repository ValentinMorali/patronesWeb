using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class AtributosDefecto
    {
        [Column("idAtributo")]
        public int IdAtributo { get; set; }
        [Column("idTipoDefecto")]
        public int IdTipoDefecto { get; set; }

        [ForeignKey("IdAtributo")]
        [InverseProperty("AtributosDefecto")]
        public virtual TipoAtributo IdAtributoNavigation { get; set; }
        [ForeignKey("IdTipoDefecto")]
        [InverseProperty("AtributosDefecto")]
        public virtual TipoDefecto IdTipoDefectoNavigation { get; set; }
    }
}
