using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    [Table("TRK_Patron")]
    public partial class TrkPatron
    {
        public int Id { get; set; }
        public int IdPatron { get; set; }
        public int NroPasadas { get; set; }
        public int? NroMaxPasadas { get; set; }
        public double Longitud { get; set; }
        public double Diametro { get; set; }
        public double Espesor { get; set; }
        [Required]
        [StringLength(50)]
        public string Acero { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaAlta { get; set; }
        public int Tipo { get; set; }
        [Required]
        [StringLength(64)]
        public string TratamientoTermico { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UltimaPasada { get; set; }
        [Column("idUbicacion")]
        public int? IdUbicacion { get; set; }
        [Column("idPadre")]
        public int? IdPadre { get; set; }
        [Required]
        [StringLength(8)]
        public string Codigo { get; set; }
        public int Ciclo { get; set; }
        public int Colada { get; set; }
        [Column("expediente")]
        [StringLength(10)]
        public string Expediente { get; set; }
        [StringLength(36)]
        public string UltimoUso { get; set; }
        [Required]
        [StringLength(50)]
        public string Grado { get; set; }
        [Column("idPedido")]
        public int? IdPedido { get; set; }
        [Column("idEstado")]
        public int IdEstado { get; set; }
        [StringLength(150)]
        public string Cliente { get; set; }
        [StringLength(128)]
        public string Descripcion { get; set; }
        public int? Esdefinicion { get; set; }
        public int? Status { get; set; }
        [Column("idBrazoEstiba")]
        public int? IdBrazoEstiba { get; set; }
        public int? Traceability { get; set; }
        [StringLength(50)]
        public string Ubicacion { get; set; }
        [StringLength(3)]
        public string Pasillo { get; set; }
        [StringLength(3)]
        public string Cuerpo { get; set; }
        [StringLength(3)]
        public string Nivel { get; set; }
        [StringLength(3)]
        public string Casilla { get; set; }
        [Column("idMotivo")]
        public int? IdMotivo { get; set; }
        [Column("idLinea")]
        public int? IdLinea { get; set; }
        public bool? Replica { get; set; }
        public bool? Acustica { get; set; }
        [StringLength(20)]
        public string Registro { get; set; }
        public int? PosicionTag { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaModif { get; set; }
    }
}
