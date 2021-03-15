using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class ValoresAtributos
    {
        [Column("idDefecto")]
        public int IdDefecto { get; set; }
        [Column("idAtributo")]
        public int IdAtributo { get; set; }
        public double Valor { get; set; }

        [ForeignKey("IdAtributo")]
        [InverseProperty("ValoresAtributos")]
        public virtual TipoAtributo IdAtributoNavigation { get; set; }
        public virtual DefectosPatrones IdDefectoNavigation { get; set; }
    }
}
