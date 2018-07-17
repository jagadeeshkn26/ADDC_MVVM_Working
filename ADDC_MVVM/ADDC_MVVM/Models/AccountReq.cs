using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
    public class Personaccountrequest
    {
        public string AccountID { get; set; }
    }

    public class AccountReq
    {
        public Personaccountrequest personaccountrequest { get; set; }
        public string token { get; set; }
    }   

}
