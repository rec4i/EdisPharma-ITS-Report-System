using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class USER_
    {
        [Key]
        public int USER_ID { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string? USER_NAME { get; set; }



        [Column(TypeName = "nvarchar(50)")]

        public string? PASSWORD { get; set; }

        public int? ROL { get; set; }

        [Column(TypeName = "nvarchar(50)")]

        public string? EMAIL { get; set; }

        public bool? ISDELETED { get; set; }





    }


}