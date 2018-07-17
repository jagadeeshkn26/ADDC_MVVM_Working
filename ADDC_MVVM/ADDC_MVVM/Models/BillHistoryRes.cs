using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
    public class BillInfo
	{
		[JsonProperty("PropertyName")]
		public string PropertyName { get; set; }

		[JsonProperty("AccountNumber")]
		public string AccountNumber { get; set; }

		[JsonProperty("BillNumber")]
		public string BillNumber { get; set; }

		[JsonProperty("BillDate")]
		public DateTime BillDate { get; set; }

		[JsonProperty("PayByDate")]
		public DateTime PayByDate { get; set; }

		[JsonProperty("Amount")]
		public double Amount { get; set; }

		[JsonProperty("FriendPayment")]
		public bool FriendPayment { get; set; }



	}
	public class BillInfolst
	{
		[JsonProperty("PropertyName")]
		public string PropertyName { get; set; }

		[JsonProperty("AccountNumber")]
		public string AccountNumber { get; set; }

		[JsonProperty("BillNumber")]
		public string BillNumber { get; set; }

		[JsonProperty("BillDate")]
		public string BillDate { get; set; }

		[JsonProperty("PayByDate")]
		public string PayByDate { get; set; }

		[JsonProperty("Amount")]
		public double Amount { get; set; }

		[JsonProperty("FriendPayment")]
		public bool FriendPayment { get; set; }

	}
	public class BillHistoryRes
    {
        public List<BillInfo> BillInfo { get; set; }
        public PageSettings PageSettings { get; set; }
        public AuthResponce AuthResponce { get; set; }
    }

}
