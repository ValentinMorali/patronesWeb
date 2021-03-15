using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class Tipos
    {
        public Tipos()
        {
            Patron = new HashSet<Patron>();
            Pedidos = new HashSet<Pedidos>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Nombre { get; set; }
        [StringLength(3)]
        public string Label { get; set; }
        [Column("idPlantilla")]
        public int? IdPlantilla { get; set; }
        public bool? AplicaNorma { get; set; }

        [InverseProperty("TipoNavigation")]
        public virtual ICollection<Patron> Patron { get; set; }
        [InverseProperty("IdTipoNavigation")]
        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}
