using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class Marcas
    {
        [Key]
        public int IdMarca { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
    }
}
