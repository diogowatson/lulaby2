using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web_api_version01.Models
{
    //Model class added in 2018-07-20
    public class ApplicationReceived
    {
        public int ID { get; set; }
        public string Company { get; set; }
        public int CreditRequested { get; set; }
        public string CreditTerms { get; set; }
        public string Name { get; set; }
        public string Industry { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string StyleOfBusiness { get; set; }
        public int YearsEstablished { get; set; }
        public string ProvinceEstablished { get; set; }
        public int NumOfEmployees { get; set; }
        public float AnnualSales { get; set; }
        public int DunsNumber { get; set; }
        public int TaxId { get; set; }
        public float TaxExempt { get; set; }
        public string ContactTitle { get; set; }
        public string ContactFirstname { get; set; }
        public string ContactLastName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }

    }
}