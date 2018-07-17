using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{

    public class CLRegisterPaymentRequest
    {
        public string PersonID { get; set; }
        public double TotalAmount { get; set; }
        public string ReturnPath { get; set; }
        public bool SaveCard { get; set; }
        public int PaymentMethod { get; set; }
        public BillInfoCollection BillInfoCollection { get; set; }
        public CardInfo CardInfo { get; set; }
    }

    public class AuthPaymentReq
    {
        public CLRegisterPaymentRequest CL_RegisterPaymentRequest { get; set; }
        public string token { get; set; }
    }
 
}
