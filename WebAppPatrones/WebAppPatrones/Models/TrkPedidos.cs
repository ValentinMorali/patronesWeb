using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    [Table("Trk_Pedidos")]
    public partial class TrkPedidos
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("idPedido")]
        public int IdPedido { get; set; }
        [Required]
        [StringLength(8)]
        public string Codigo { get; set; }
        public int? Linea { get; set; }
        public int? IdTipo { get; set; }
        public double Longitud { get; set; }
        public double Diametro { get; set; }
        public double Espesor { get; set; }
        [Required]
        [StringLength(120)]
        public string Acero { get; set; }
        [Required]
        [StringLength(50)]
        public string Grado { get; set; }
        [Required]
        [StringLength(64)]
        public string TratamientoTermico { get; set; }
        [StringLength(10)]
        public string Expediente { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaPedido { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime FechaEsperado { get; set; }
        public int? IdPadre { get; set; }
        public int IdEstado { get; set; }
        public short Prioridad { get; set; }
        public short? Secuencia { get; set; }
        public int? IdRemitente { get; set; }
        [StringLength(200)]
        public string Cliente { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Entregado { get; set; }
        public int? IdBancal { get; set; }
        public int Ciclo { get; set; }
        public int Colada { get; set; }
        [StringLength(200)]
        public string Producto { get; set; }
        public int? Numero { get; set; }
        [StringLength(150)]
        public string Ubicacion { get; set; }
        public int? IdDestino { get; set; }
        public bool NotificarAuditor { get; set; }
        public int? Traceability { get; set; }
        public bool? Acustica { get; set; }
        [StringLength(50)]
        public string Auditor { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaUltimaModif { get; set; }
    }
}
