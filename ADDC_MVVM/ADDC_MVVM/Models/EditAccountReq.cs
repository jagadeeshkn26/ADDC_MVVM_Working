using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
    public class AccountRequested
    {
        public string AccountID { get; set; }
        public string PersonID { get; set; }
    }


    public class CLAccountBillPreferenceRequest
    {
        public AccountRequested AccountRequest { get; set; }
        public BillRoute BillRoute { get; set; }
        public Address Address { get; set; }
    }

    public class EditAccountReq
    {
        public CLAccountBillPreferenceRequest CL_AccountBillPreferenceRequest { get; set; }
        public string token { get; set; }
    }
   
}
