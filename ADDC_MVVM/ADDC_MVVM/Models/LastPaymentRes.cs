using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
    public class PaymentInfo
    {
        public string PropertyName { get; set; }
        public string AccountNumber { get; set; }
        public string PaymentChannel { get; set; }
        public string PaymentType { get; set; }
        public DateTime PaymentDate { get; set; }
        public double PaidAmount { get; set; }
        public string TransactionID { get; set; }
    }

	public class PaymentInfolst
	{
		public string PropertyName { get; set; }
		public string AccountNumber { get; set; }
		public string PaymentChannel { get; set; }
		public string PaymentType { get; set; }
		public string PaymentDate { get; set; }
		public double PaidAmount { get; set; }
		public string TransactionID { get; set; }
	}


	public class LastPaymentRes
    {
        public List<PaymentInfo> PaymentInfo { get; set; }
        public PageSettings PageSettings { get; set; }
        public AuthResponce AuthResponce { get; set; }
    }

}
