using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class Remitentes
    {
        public Remitentes()
        {
            Pedidos = new HashSet<Pedidos>();
        }

        [Column("id")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }
        [Required]
        [Column("EMail")]
        [StringLength(250)]
        public string Email { get; set; }
        [Required]
        [Column("NRegistro")]
        [StringLength(10)]
        public string Nregistro { get; set; }

        [InverseProperty("IdRemitenteNavigation")]
        public virtual ICollection<Pedidos> Pedidos { get; set; }
    }
}
