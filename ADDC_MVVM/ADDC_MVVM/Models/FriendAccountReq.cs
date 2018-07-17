using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
    //class AccountFetchConfiguration
    //{
    //    public string FetchPaymentDate { get; set; }
    //    public string FetchOutstandingBalance { get; set; }
    //    public string FetchAddress { get; set; }
    //    public string FetchInActiveAccounts { get; set; }
    //    public string FetchPayByDate { get; set; }
    //    public string FetchAccountDetails { get; set; }
    //    public string FetchAccNumbers { get; set; }
    //    public string FetchAutoPaymentConfiguration { get; set; }
    //}

    //class AccountRequest
    //{
    //    public string AccountID { get; set; }
    //    public AccountFetchConfiguration AccountFetchConfiguration { get; set; }
    //}

    public class FriendAccountReq
    {
        public AccountRequestFrd accountRequest { get; set; }
        public string token { get; set; }

        
    }

    public class AccountRequestFrd
    {
        public string AccountID { get; set; }
        public AccountFetchConfiguration AccountFetchConfiguration { get; set; }
    }

}
