using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class DefectosPatrones
    {
        public DefectosPatrones()
        {
            ValoresAtributos = new HashSet<ValoresAtributos>();
        }

        [Column("idPatron")]
        public int IdPatron { get; set; }
        [Column("idDefecto")]
        public int IdDefecto { get; set; }
        [Column("idTipoDefecto")]
        public int? IdTipoDefecto { get; set; }
        [Column("idEnPedido")]
        public int IdEnPedido { get; set; }
        [Column("idResponsable")]
        public int IdResponsable { get; set; }
        [StringLength(2)]
        public string Letra { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Fecha { get; set; }

        [ForeignKey("IdPatron")]
        [InverseProperty("DefectosPatrones")]
        public virtual Patron IdPatronNavigation { get; set; }
        [ForeignKey("IdResponsable")]
        [InverseProperty("DefectosPatrones")]
        public virtual Usuarios IdResponsableNavigation { get; set; }
        [ForeignKey("IdTipoDefecto")]
        [InverseProperty("DefectosPatrones")]
        public virtual TipoDefecto IdTipoDefectoNavigation { get; set; }
        public virtual ICollection<ValoresAtributos> ValoresAtributos { get; set; }
    }
}
