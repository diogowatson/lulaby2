using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api_version01.Models
{
    public class Application
    {
        public int ID { get; set; }
        public string Company { get; set; }
        public DateTime DateAplied { get; set; }
        public DateTime DateProcessed { get; set; }
        public int CreditApplied { get; set; }
        public int CreditAproved { get; set; }
        public string Recomendation { get; set; }
        public short Aproved { set; get; }
        public int Score { get; set; }
        public Boolean ProcessStatus { get; set; } //if an aplication is already processed True - added in 2018-07-18

    }
}