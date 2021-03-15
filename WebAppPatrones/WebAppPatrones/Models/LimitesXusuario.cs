using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    [Table("LimitesXUsuario")]
    public partial class LimitesXusuario
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("idUsuario")]
        public int? IdUsuario { get; set; }
        [Column("idTipoTubo")]
        public int? IdTipoTubo { get; set; }
        [Column("idLinea")]
        public int? IdLinea { get; set; }
        public bool? Modifica { get; set; }
    }
}
