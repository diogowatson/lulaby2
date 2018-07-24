using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api_version01.Models
{
    //Model class added in 2018-07-20
    public class TradeReference
    {
       public int ID { get; set; }
       public string Applicant { get; set; }
       public string Creditor { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string PhoneNumber { get; set; }
       public string Address { get; set; }
       public string City { get; set; }
       public string Province { get; set; }
       public string Country { get; set; }
       public string PostalCode { get; set; }
       public int YearsInBusiness { get; set; }
       public int DateOfLastSale { get; set; }
       public int TotalCredit { get; set; }
       public float CreditLimit { get; set; }
       public float CurrentOutstandingBalance { get; set; }
       public float BalancePastDue { get; set; }
       public float HighestBalance { get; set; }
       public string CreditTerms { get; set; }
       public string PaymentExperience { get; set; }
       public int rating { get; set; }
       public string Comment { get; set; }


    }
}