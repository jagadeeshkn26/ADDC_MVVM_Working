using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{

    public class CLFinalisePaymentRequest
    {
        public string TransactionID { get; set; }
        public bool SaveCard { get; set; }
        public string OrderID { get; set; }
    }

    public class FinalPaymentReq
    {
        public CLFinalisePaymentRequest CL_FinalisePaymentRequest { get; set; }
        public string token { get; set; }
    }
}
