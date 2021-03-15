using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class DefectosPlantilla
    {
        [Key]
        [Column("idDefecto")]
        public int IdDefecto { get; set; }
        [Column("idPlantilla")]
        public int IdPlantilla { get; set; }
        [Column("idTipoDefecto")]
        public int IdTipoDefecto { get; set; }

        [ForeignKey("IdPlantilla")]
        [InverseProperty("DefectosPlantilla")]
        public virtual Plantilla IdPlantillaNavigation { get; set; }
        [ForeignKey("IdTipoDefecto")]
        [InverseProperty("DefectosPlantilla")]
        public virtual TipoDefecto IdTipoDefectoNavigation { get; set; }
    }
}
