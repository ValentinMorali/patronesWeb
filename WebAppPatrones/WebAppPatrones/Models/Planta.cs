using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class Planta
    {
        public Planta()
        {
            Linea = new HashSet<Linea>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Descripcion { get; set; }

        [InverseProperty("IdPlantaNavigation")]
        public virtual ICollection<Linea> Linea { get; set; }
    }
}
