using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class TestPipeAttribute
    {
        [Key]
        [Column("idTestPipeAttribute")]
        public int IdTestPipeAttribute { get; set; }
        [Column("idTestPipeType")]
        public int? IdTestPipeType { get; set; }
        [StringLength(80)]
        public string Description { get; set; }
        [StringLength(32)]
        public string DataType { get; set; }
    }
}
