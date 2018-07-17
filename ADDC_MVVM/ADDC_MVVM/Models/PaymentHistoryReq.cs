using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
   
    public class PaymentHistoryReq
    {
        public string token { get; set; }
        public CLPaymentFilter CL_PaymentFilter { get; set; }
    }
    
}
