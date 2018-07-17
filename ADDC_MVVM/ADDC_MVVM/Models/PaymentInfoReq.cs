using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{

    public class AccountRequestPay
    {
        public string AccountID { get; set; }
        public string PersonID { get; set; }
    }

  

    public class CLPaymentFilter
    {
        public AccountRequestPay AccountRequest { get; set; }
        public PageSettings PageSettings { get; set; }
    }

    public class PaymentInfoReq
    {
        public string token { get; set; }
        public CLPaymentFilter CL_PaymentFilter { get; set; }
    }
    
}
