using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class STOCK
    {
        [Key]
        public int ID { get; set; }


        [Column(TypeName = "nvarchar(14)")]
        public string GTIN { get; set; }

        public Int64 SN { get; set; }


        [Column(TypeName = "nvarchar(10)")]

        public string BN { get; set; }


        [Column(TypeName = "datetime")]

        public DateTime? XD { get; set; }

        [Column(TypeName = "datetime")]

        public DateTime? MD { get; set; }


        [Column(TypeName = "nvarchar(60)")]

        public string QR_CODE { get; set; }


        [Column(TypeName = "nvarchar(50)")]

        public string? PACK_SSCC { get; set; }

        [Column(TypeName = "nvarchar(50)")]

        public string? BOX_SSCC { get; set; }


        [Column(TypeName = "nvarchar(50)")]

        public string? PALET_SSCC { get; set; }

        [Column(TypeName = "datetime")]

        public DateTime? CREATED_DATE { get; set; }

        public int? CREATED_BY { get; set; }

        public int IN_STOCK { get; set; }

        public int NOTIFICATION_ST { get; set; }


    }


}