using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class CUSTOMER
    {
        [Key]
        public int ID { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        public string NAME { get; set; }


        [Column(TypeName = "nvarchar(13)")]

        public string GLN { get; set; }


        [Column(TypeName = "nvarchar(13)")]

        public string? TO_GLN { get; set; }

        [Column(TypeName = "nvarchar(100)")]

        public string? ADRESS { get; set; }

    }
}