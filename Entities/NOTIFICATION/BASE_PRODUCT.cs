using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class BASE_PRODUCT
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? NAME { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string? UNIT { get; set; }

        [Column(TypeName = "nvarchar(14)")]
        public string? GTIN { get; set; }

        public int? ORIGIN { get; set; }
        public int RAF_CYCLE_TIME { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string RAF_CYCLE_UNIT { get; set; }

        [Column(TypeName = "nchar(2)")]
        public string PRODUCT_TYPE { get; set; }


        public int? BOXES_IN_PALET { get; set; }
        public int? PRODUCT_IN_BOX { get; set; }
        public int? PACKS_IN_BOX { get; set; }
        public int? PRODUCTS_IN_PACK { get; set; }
        public bool? HAS_PACK { get; set; }

    }
}