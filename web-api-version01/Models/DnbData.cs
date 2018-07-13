using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api_version01.Models
{
    public class DnbData
    {
        public int ID { get; set; }
        public String Company { get; set; }
        public DateTime Date { get; set; }
        public int FailureScore {get;set;}
        public int DelinquencyScore { get; set; }
        public int Paydex { get; set; }
        public int ViabilityRating { get; set; }
    }
}