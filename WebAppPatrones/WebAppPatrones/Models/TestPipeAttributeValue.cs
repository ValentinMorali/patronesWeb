using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class TestPipeAttributeValue
    {
        [Key]
        [Column("idTestPipeAttributeValue")]
        public int IdTestPipeAttributeValue { get; set; }
        [Column("idTestPipeAttribute")]
        public int? IdTestPipeAttribute { get; set; }
        [StringLength(50)]
        public string Value { get; set; }
    }
}
