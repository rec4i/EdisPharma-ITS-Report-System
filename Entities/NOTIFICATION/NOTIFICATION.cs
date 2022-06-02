using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class NOTIFICATION
    {
        [Key]
        public int ID { get; set; }


        [Column(TypeName = "nvarchar(20)")]
        public string BILDIRIMID { get; set; }


        public int NOTIFICATION_ORDER_ID { get; set; }


        [Column(TypeName = "nchar(1)")]
        public string NOTIFICATION_TYPE { get; set; }


        [Column(TypeName = "datetime")]

        public DateTime? DOCUMENT_DATE { get; set; }



        //nvarchar(20)
        [Column(TypeName = "nvarchar(20)")]

        public string? DOCUMENT_NO { get; set; }

        //nvarchar(14)
        [Column(TypeName = "nvarchar(14)")]

        public string? TO_GLN { get; set; }


        //nvarchar(100)
        [Column(TypeName = "nvarchar(100)")]

        public string? DESCRIPTION { get; set; }


    }

    public class NOTIFICATION_Return_Value
    {
        [Key]
        public int NOTIFICATION_ORDER_ID { get; set; }

        public string NOTIFICATION_TYPE_NAME { get; set; }

        public string DOCUMENT_NO { get; set; }

        public int? QUANTITY { get; set; }

        public string CUSTOMER_NAME { get; set; }

        public string BASE_PRODUCT_NAME { get; set; }

        public string BN { get; set; }

        public string NOTIFICATION_ORDER_DOCUMENT_DATE { get; set; }

        public string MD { get; set; }

        public string XD { get; set; }
        public string QR_CODE { get; set; }


        //QR_CODE
        public string BOX_SSCC { get; set; }

        public string PALET_SSCC { get; set; }

        public string? TO_GLN { get; set; }

        public string? DESCRIPTION { get; set; }


        public NOTIFICATION_ORDER NOTIFICATION_ORDER { get; set; }

    }
}