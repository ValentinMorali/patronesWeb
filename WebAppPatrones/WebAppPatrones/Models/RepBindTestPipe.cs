using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class RepBindTestPipe
    {
        public int Id { get; set; }
        public int IdRegistro { get; set; }
        [StringLength(12)]
        public string TestPipeCode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PassDate { get; set; }
    }
}
