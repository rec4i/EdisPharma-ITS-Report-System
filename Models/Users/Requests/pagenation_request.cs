using System;

namespace KaynakKod.Models.pagenation_request
{
    public class pagenation_request
    {
        public string offset { get; set; }
        public string search { get; set; }
        public string sort { get; set; }
        public string order { get; set; }
        public string limit { get; set; }

        public DateTime Start_Date { get; set; }

        public DateTime End_date { get; set; }

    }
}