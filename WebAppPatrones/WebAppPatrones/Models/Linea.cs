using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class Linea
    {
        public Linea()
        {
            BindLine = new HashSet<BindLine>();
            Pedidos = new HashSet<Pedidos>();
            Ubicacion = new HashSet<Ubicacion>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Column("idPlanta")]
        public int IdPlanta { get; set; }
        [Required]
        [StringLength(150)]
        public string Descripcion { get; set; }
        [StringLength(10)]
        public string Centro { get; set; }

        [ForeignKey("IdPlanta")]
        [InverseProperty("Linea")]
        public virtual Planta IdPlantaNavigation { get; set; }
        [InverseProperty("IdLineaNavigation")]
        public virtual ICollection<BindLine> BindLine { get; set; }
        [InverseProperty("LineaNavigation")]
        public virtual ICollection<Pedidos> Pedidos { get; set; }
        [InverseProperty("IdlineaNavigation")]
        public virtual ICollection<Ubicacion> Ubicacion { get; set; }
    }
}
