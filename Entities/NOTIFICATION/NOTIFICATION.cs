using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace WebApi.Entities
{
    public class NOTFICATION
    {
        [Key]
        public int ID { get; set; }


        [Column(TypeName = "nvarchar(20)")]
        public string BILDIRIMID { get; set; }


        public int NOTIFICATION_ORDER_ID { get; set; }


        [Column(TypeName = "nchar(1)")]
        public string NOTIFICATION_TYPE { get; set; }


        [Column(TypeName = "datetime")]

        public DateTime DOCUMENT_DATE { get; set; }



        //nvarchar(20)
        [Column(TypeName = "nvarchar(20)")]

        public string DOCUMENT_NO { get; set; }




        //nvarchar(14)
        [Column(TypeName = "nvarchar(14)")]

        public string TO_GLN { get; set; }


        //nvarchar(100)
        [Column(TypeName = "nvarchar(100)")]

        public string DESCRIPTION { get; set; }





    }
}