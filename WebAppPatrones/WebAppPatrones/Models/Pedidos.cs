using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class Pedidos
    {
        public Pedidos()
        {
            DefectosPedido = new HashSet<DefectosPedido>();
            Patron = new HashSet<Patron>();
        }

        [Column("id")]
        public int Id { get; set; }
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
        [Required]
        public bool? NotificarAuditor { get; set; }
        public int? Traceability { get; set; }
        public bool? Acustica { get; set; }
        [StringLength(50)]
        public string Auditor { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaUltimaModif { get; set; }
        [StringLength(150)]
        public string Motivo { get; set; }
        [Column("OT")]
        [StringLength(10)]
        public string Ot { get; set; }
        [StringLength(150)]
        public string Obs { get; set; }

        [ForeignKey("IdDestino")]
        [InverseProperty("Pedidos")]
        public virtual DestinoPedido IdDestinoNavigation { get; set; }
        [ForeignKey("IdEstado")]
        [InverseProperty("Pedidos")]
        public virtual EstadosPatron IdEstadoNavigation { get; set; }
        [ForeignKey("IdRemitente")]
        [InverseProperty("Pedidos")]
        public virtual Remitentes IdRemitenteNavigation { get; set; }
        [ForeignKey("IdTipo")]
        [InverseProperty("Pedidos")]
        public virtual Tipos IdTipoNavigation { get; set; }
        [ForeignKey("Linea")]
        [InverseProperty("Pedidos")]
        public virtual Linea LineaNavigation { get; set; }
        [InverseProperty("IdPedidoNavigation")]
        public virtual ICollection<DefectosPedido> DefectosPedido { get; set; }
        [InverseProperty("IdPedidoNavigation")]
        public virtual ICollection<Patron> Patron { get; set; }
    }
}
