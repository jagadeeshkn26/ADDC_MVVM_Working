using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
    public class AuthorizePaymentReq
    {
        public CL_RegisterPaymentRequest registerPaymentRequest { get; set; }
        public string token { get; set; }
    }

    public class CL_RegisterPaymentRequest
    {

        public string PersonID { get; set; }
        public string TotalAmount { get; set; }
        public string ReturnPath { get; set; }
        public string SaveCard { get; set; }
        public string PaymentMethod { get; set; }
        public BillInfoCollection billInfoCollection { get; set; }
        public CardInfo cardInfo { get; set; }

    }

    public class BillInfoAuthorise
    {
        public string AccountNumber { get; set; }
        public string Amount { get; set; }
        public bool FriendPayment { get; set; }
    }

    public class BillInfoCollection
    {
        public List<BillInfoAuthorise> BillInfo { get; set; }
     }
  
    public class CardInfo
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Brand { get; set; }
    }
}


