using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class Tolerancia
    {
        public Tolerancia()
        {
            TipoAtributo = new HashSet<TipoAtributo>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("descripcion")]
        [StringLength(50)]
        public string Descripcion { get; set; }

        [InverseProperty("ToleranciaNavigation")]
        public virtual ICollection<TipoAtributo> TipoAtributo { get; set; }
    }
}
