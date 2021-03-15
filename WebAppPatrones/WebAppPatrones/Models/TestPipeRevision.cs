using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPatrones.Models
{
    public partial class TestPipeRevision
    {
        [Key]
        [Column("idTestPipeRevision")]
        public int IdTestPipeRevision { get; set; }
        [Column("idTestPipe")]
        public int? IdTestPipe { get; set; }
        public int? Revision { get; set; }
        [Column(TypeName = "image")]
        public byte[] CertificateFile { get; set; }
        public int? Status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? InsDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdDateTime { get; set; }
    }
}
