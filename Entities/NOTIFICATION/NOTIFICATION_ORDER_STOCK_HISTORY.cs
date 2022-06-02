using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class NOTIFICATION_ORDER_STOCK_HISTORY
    {
        [Key]
        public int ID { get; set; }
        public int CREATED_BY { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CREATED_DATE { get; set; }

        public int NOTIFICATION_ORDER_ID { get; set; }

        public int STOCK_ID { get; set; }
        public int IS_NOTIFY { get; set; }


    }


}