using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class Maquinas
    {
        [Key]
        public int IdMaquina { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
}
