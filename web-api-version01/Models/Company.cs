using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api_version01.Models
{
    
    public class Company
    {
        //simple version with no bussines rules applied
        
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ParentCompany { get; set; }//must be optional
        public int CreditIssued { get; set; }
        public string Industry { get; set; }
        public virtual ICollection<EquifaxData> EquifaxDatas { get; set; }//added 2018-07-17
        public virtual ICollection<DnbData> DnbDatas { get; set; }//added 2018-07-17
        public float EquifaxScore { get; set; }//added 2018-07-17
        public float DbnScore { get; set; }//added 2018-07-17
        public string Terms { get; set; }


    }
}