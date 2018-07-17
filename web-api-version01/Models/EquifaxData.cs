using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api_version01.Models
{
    public class EquifaxData
    {
        public int ID { get; set; }
        public String Company { get; set; }

        public DateTime Date { get; set; }
        public int CreditIndex { get; set; }
        public int PaymentIndex { get; set; }
        public int Cds { get; set; }
        public int Bfrs {get;set;}
    }
}