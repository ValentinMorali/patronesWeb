using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class Plantilla
    {
        public Plantilla()
        {
            DefectosPlantilla = new HashSet<DefectosPlantilla>();
        }

        [Key]
        [Column("idPlantilla")]
        public int IdPlantilla { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [InverseProperty("IdPlantillaNavigation")]
        public virtual ICollection<DefectosPlantilla> DefectosPlantilla { get; set; }
    }
}
