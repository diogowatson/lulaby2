using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api_version01.Models
{
    public class CreditTransaction
    {
        public int CreditTransactionID { get; set; }
        public String Company { get; set; }
        public DateTime CreditIssued { get; set; }
        public int Amount { get; set; }
        public DateTime DueDate { get; set; }
        public Boolean Paid { get; set; }
    }
}