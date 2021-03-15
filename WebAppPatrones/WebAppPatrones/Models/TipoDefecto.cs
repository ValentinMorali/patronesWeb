using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class TipoDefecto
    {
        public TipoDefecto()
        {
            AtributosDefecto = new HashSet<AtributosDefecto>();
            DefectosPatrones = new HashSet<DefectosPatrones>();
            DefectosPedido = new HashSet<DefectosPedido>();
            DefectosPlantilla = new HashSet<DefectosPlantilla>();
        }

        [Key]
        [Column("idTipoDefecto")]
        public int IdTipoDefecto { get; set; }
        [StringLength(80)]
        public string Descripcion { get; set; }
        [StringLength(3)]
        public string Codigo { get; set; }
        [StringLength(50)]
        public string ArchivoDibujo { get; set; }
        [StringLength(80)]
        public string Description { get; set; }

        [InverseProperty("IdTipoDefectoNavigation")]
        public virtual ICollection<AtributosDefecto> AtributosDefecto { get; set; }
        [InverseProperty("IdTipoDefectoNavigation")]
        public virtual ICollection<DefectosPatrones> DefectosPatrones { get; set; }
        [InverseProperty("IdTipoDefectoNavigation")]
        public virtual ICollection<DefectosPedido> DefectosPedido { get; set; }
        [InverseProperty("IdTipoDefectoNavigation")]
        public virtual ICollection<DefectosPlantilla> DefectosPlantilla { get; set; }
    }
}
