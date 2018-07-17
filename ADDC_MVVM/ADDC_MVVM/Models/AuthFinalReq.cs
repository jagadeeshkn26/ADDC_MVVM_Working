using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
   
    public class AuthFinalReq
    {
        public string token { get; set; }
        public Accountfilter accountfilter { get; set; }
    }
    public class PageSettings
    {
        public string TotalCount { get; set; }
        public string PageNumber { get; set; }
        public string PageSize { get; set; }
    }

    public class PersonRequest
    {
        public string PersonID { get; set; }
    }

    public class AccountFetchConfiguration
    {
        public string FetchAccNumbers { get; set; }
        public string FetchAddress { get; set; }
        public string FetchAccountDetails { get; set; }
        public string @FetchPayByDate { get; set; }
    public string FetchOutstandingBalance { get; set; }
    public string FetchInActiveAccounts { get; set; }
    public string FetchPaymentDate { get; set; }
    public string FetchAutoPaymentConfiguration { get; set; }
}

public class Accountfilter
{
    public PageSettings PageSettings { get; set; }
    public PersonRequest PersonRequest { get; set; }
    public AccountFetchConfiguration AccountFetchConfiguration { get; set; }
}


}
