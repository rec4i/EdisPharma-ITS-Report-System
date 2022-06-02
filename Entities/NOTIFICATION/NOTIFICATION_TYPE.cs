using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class NOTIFICATION_TYPE
    {
        [Key]
        public int ID { get; set; }


        [Column(TypeName = "nvarchar(20)")]
        public string? NAME { get; set; }


        [Column(TypeName = "nchar(1)")]

        public string? CODE { get; set; }


    }
}