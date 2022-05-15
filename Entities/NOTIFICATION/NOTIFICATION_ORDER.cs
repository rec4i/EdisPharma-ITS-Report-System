using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class NOTIFICATION_ORDER
    {
        [Key]
        public int ID { get; set; }


        public int? CREATED_BY { get; set; }


        public DateTime? CREATED_DATE { get; set; }


        public int PRODUCT_ID { get; set; }


        public int? NOTIFICATION_TYPE_ID { get; set; }


        public int? QUANTITY { get; set; }


        public int? CUSTOMER_ID { get; set; }


        public DateTime? DOCUMENT_DATE { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string? DOCUMENT_NO { get; set; }

        [Column(TypeName = "nvarchar(13)")]

        public string? SENDER { get; set; }

        [Column(TypeName = "nvarchar(13)")]

        public string? RECEIVER { get; set; }


        public int? DEAKTIVATION_CODE { get; set; }



        [Column(TypeName = "nvarchar(100)")]
        public string? RECEIVER_DETAIL { get; set; }


        public int? NATIFICATION_STATUS { get; set; }

        [Column(TypeName = "nvarchar(100)")]

        public string? DESCRIPTION { get; set; }


        public int IS_SEND_PTS { get; set; }


    }
}