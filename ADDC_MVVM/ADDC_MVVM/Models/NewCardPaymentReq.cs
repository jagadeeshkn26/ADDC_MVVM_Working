using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
    public class NewCardPaymentReq
    {
        public string ReturnPath { get; set; }
        public string TransactionID { get; set; }
        public string OrderID { get; set; }
        public StatusResponse StatusResponse { get; set; }
        public AuthResponce AuthResponce { get; set; }
    }
   
}
