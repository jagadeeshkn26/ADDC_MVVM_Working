using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
    public class AccountRequest
    {
        public string AccountID { get; set; }
    }

    public class BillFetchConfiguration
    {
        public string FetchBillInfo { get; set; }
    }

    public class Billfilter
    {
        public AccountRequest AccountRequest { get; set; }
        public string PayByDateDesc { get; set; }
        public PageSettings PageSettings { get; set; }
        public BillFetchConfiguration BillFetchConfiguration { get; set; }
    }

    public class LastBillReq
    {
        public Billfilter billfilter { get; set; }
        public string token { get; set; }
    }

  

    public class CLBillRequest
    {
        public string AccountID { get; set; }
        public string BillID { get; set; }
        public BillFetchConfiguration BillFetchConfiguration { get; set; }
    }

    public class GetBillReq
    {
        public string token { get; set; }
        public CLBillRequest CL_BillRequest { get; set; }
    }
}
