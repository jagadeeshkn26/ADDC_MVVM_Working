using System;
using ADDC_MVVM.Models;

namespace ADDC_MVVM
{


	public class AuthResponce
	{
		public string TokenID { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
	}

	public class PayResponse
	{
		public string TransactionID { get; set; }
		public StatusResponse StatusResponse { get; set; }
		public AuthResponce AuthResponce { get; set; }
	}
}
