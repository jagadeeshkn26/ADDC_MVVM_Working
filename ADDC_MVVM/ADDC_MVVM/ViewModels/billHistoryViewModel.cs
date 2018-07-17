using ADDC_MVVM.Models;
using ADDC_MVVM.ViewModels;
using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ADDC_MVVM.ViewModel
{
    public class billHistoryDataTemplate
    {

        public string accNumber { get; set; }
        public string billNumber { get; set; }
        public string billDate { get; set; }
        public string payByDate { get; set; }


    }

    
    public class billHistoryViewModel : ViewModelBase
    {
		string billHisImg = "";
		string billPayImg = "";

		bool isBusy = false;
		bool billHis = true;
		bool paymentHis = false;
		//public bool BillHis  { get; set; }
		//public bool PaymentHis { get; set; }

		public ICommand OnTapBill { get; set; }
		public ICommand OnTapPayment { get; set; }
		public ICommand OnTapMenu { get; set; }

        public string BillHisImg
		{
			get { return billHisImg; }
			set { SetProperty(ref billHisImg, value); }
		}
	public string BillPayImg
		{
			get { return billPayImg; }
			set { SetProperty(ref billPayImg, value); }
		}
	
		public bool PaymentHis
		{
			get { return paymentHis; }
			set { SetProperty(ref paymentHis, value); }
		}

		public bool BillHis
		{
			get { return billHis; }
			set { SetProperty(ref billHis, value); }
		}

		 public bool IsBusy
		{
			get { return isBusy; }
			set { SetProperty(ref isBusy, value); }
		}

		public LastPaymentRes authResPayment { get; set; }
        public BillHistoryRes authResAccDet { get; set; }
        public ObservableCollection<BillInfolst> billHistoryItems { get; set; }
		public ObservableCollection<PaymentInfolst> paymentHistoryItems { get; set; }

		// public ObservableCollection<billHistoryDataTemplate> billHistoryItems { get; set; }
		public billHistoryDataTemplate item1 { get; set; }
        public ICommand GetSessionsCommand { get; set; }
        public billHistoryViewModel()
        {
            billHistoryItems = new ObservableCollection<BillInfolst>();
			paymentHistoryItems = new ObservableCollection<PaymentInfolst>();
			BillHisImg = "ic_action_bill_history";
			BillPayImg = "ic_action_payment_history_deselect";
			GetSessionsCommand  = RefreshCommand = new Command(
               async () => await GetBillHistoryDetails(),
               () => !IsBusy);

			OnTapMenu = new Command(
				async () => await App.Current.MainPage.Navigation.PopModalAsync(),
				() => 
				!IsBusy);

			GetBillHistoryDetailsAsy();
			 OnTapBill = new Command(
				async () => await OnTapBillCmd(),
			   () => !IsBusy);
			
			OnTapPayment = new Command(
				async () => await OnTapPaymentCmd(),
			   () => !IsBusy);

			/* billHistoryItems = new ObservableCollection<billHistoryDataTemplate>();
			 item1 = new billHistoryDataTemplate();
			 item1.accNumber = "98744464646";
			 item1.billNumber = "0000000";
			 item1.billDate = "14-10-2016";
			 item1.payByDate = "21-10-2016";
			 billHistoryItems.Add(item1);*/

		}

		private async Task OnTapBillCmd()
		{
			BillHis = true;
			PaymentHis = false;
			BillHisImg = "ic_action_bill_history";
			BillPayImg = "ic_action_payment_history_deselect";

			if (billHistoryItems.Count < 1)
			{
				await GetBillHistoryDetails();
			}
			else
			{
			}

		}

		private async Task OnTapPaymentCmd()
		{
			BillHis = false;
			PaymentHis = true;
			BillHisImg = "ic_action_bill_history_deselect";
			BillPayImg = "ic_action_payment_history";

			if (paymentHistoryItems.Count < 1)
			{
				await GetpaymentHistoryDetails();
			}
			else
			{
			}


		}

		private async void GetBillHistoryDetailsAsy()
        {
           
           await GetBillHistoryDetails();
			//await GetpaymentHistoryDetails();
          
        }

        private async Task GetBillHistoryDetails()
        {

            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;
                string tokenID = Application.Current.Properties["TokenID"].ToString();
                string frmdate = "1999-05-31";
                string frmdt = "/Date(1999-05-31)/";
                string todt = "/Date(2016-04-23)/";
                using (var client = new HttpClient(new NativeMessageHandler()))
                {
                    BillFetchConfiguration billFetchConfiguration = new BillFetchConfiguration() {FetchBillInfo = "false" };
                    PageSettings pageSettings = new PageSettings() { PageNumber = "1", PageSize = "12", TotalCount = "10" };
                    AccountRequested accountRequest = new AccountRequested() {AccountID = Application.Current.Properties["AccountID"].ToString(), PersonID = Application.Current.Properties["PersonID"].ToString() };
                    CLBillFilter CL_BillFilter = new CLBillFilter() {AccountRequest = accountRequest , FromDate = frmdt, ToDate = todt,
                                                PayByDateDesc = true, PageSettings = pageSettings , BillFetchConfiguration = billFetchConfiguration };
                   BillHistoryReq parameterAccDet = new BillHistoryReq() { token = tokenID, CL_BillFilter = CL_BillFilter };
                    string jsonParameterAccDet = JsonConvert.SerializeObject(parameterAccDet);
                    string requestUrlAccDet = Constants.BaseAddressUrl + "/BillService.svc/GetBillInfoListForAccount";

                    client.BaseAddress = new Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var responseAccDet = await client.PostAsync(requestUrlAccDet, new StringContent(jsonParameterAccDet, Encoding.UTF8, "application/json"));
                    var jsonAccDet = await responseAccDet.Content.ReadAsStringAsync().ConfigureAwait(false);

                    authResAccDet = JsonConvert.DeserializeObject<BillHistoryRes>(jsonAccDet);

					var lstItm = new BillInfolst();
					string billDate = "";
					foreach (var item in authResAccDet.BillInfo)
					{
						lstItm.AccountNumber = item.AccountNumber;
						lstItm.Amount = item.Amount;
						var dd = item.BillDate.Date.Day;
						var mm = item.BillDate.Date.Month;
						var yyyy = item.BillDate.Date.Year;
						billDate = dd + "-" + mm + "-" + yyyy;
						lstItm.BillDate = billDate;
						lstItm.BillNumber = item.BillNumber;
						lstItm.FriendPayment = item.FriendPayment;
						dd = item.PayByDate.Date.Day;
						mm = item.PayByDate.Date.Month;
						yyyy = item.PayByDate.Date.Year;
						billDate = dd + "-" + mm + "-" + yyyy;
						lstItm.PayByDate = billDate;
						lstItm.PropertyName = item.PropertyName;
						//billDate = lastBillRes.Date.ToString("dd-MM-yyyy");
						billHistoryItems.Add(lstItm);

						Debug.WriteLine(jsonAccDet.ToString());
					}
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex); //to show Network error...
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");

        }
    private async Task GetpaymentHistoryDetails()
		{


			if (IsBusy)
				return;

			Exception error = null;
			try
			{
				IsBusy = true;
				string tokenID = Application.Current.Properties["TokenID"].ToString();
				string frmdate = "1999-05-31";
				//DateTime frmdt = Convert.ToDateTime(frmdate).Date;

				string frmdt = "/Date(1999-05-31)/";
				string todt = "/Date(2016-04-23)/";
				// DateTime todt = Convert.ToDateTime(frmdate).Date;
				using (var client = new HttpClient(new NativeMessageHandler()))
				{


					//Authentication step1
					// string 
					BillFetchConfiguration billFetchConfiguration = new BillFetchConfiguration() { FetchBillInfo = "false" };
					PageSettings pageSettings = new PageSettings() { PageNumber = "1", PageSize = "12", TotalCount = "10" };
					AccountRequestPay accountRequest = new AccountRequestPay() { AccountID = Application.Current.Properties["AccountID"].ToString(), PersonID = Application.Current.Properties["PersonID"].ToString() };

					CLPaymentFilter CL_PaymentFilter = new CLPaymentFilter()
					{
						AccountRequest = accountRequest,

						PageSettings = pageSettings
					};
					PaymentInfoReq parameterAccDet = new PaymentInfoReq() { token = tokenID, CL_PaymentFilter = CL_PaymentFilter };
					string jsonParameterAccDet = JsonConvert.SerializeObject(parameterAccDet);
					//         { "token":"6pnk+21Kq\/4j44S1HGTJKkEwPQ10Z26pza90GvlZX58=","CL_BillFilter":{ "AccountRequest":{ "AccountID":"3483789952","PersonID":"0487370633"},"FromDate":"\/Date(1999-05-31)\/","ToDate":"\/Date(2016-04-23)\/","PayByDateDesc":true,"PageSettings":{ "PageNumber":"1","PageSize":"12","TotalCount":"10"},"BillFetchConfiguration":{ "FetchBillInfo":false} } }
					// string jsonParameterAccDet= "{\"token\":\"6pnk+21Kq/4j44S1HGTJKgaFrIK2YUoievJwzuLxQcI=\",\"CL_BillFilter\":{ \"AccountRequest\":{ \"AccountID\":\"3483789952\",\"PersonID\":\"0487370633\"},\"FromDate\":\"\\/Date(1999-05-31)\\/\",\"ToDate\":\"\\/Date(1999-05-31)\\/\",\"PayByDateDesc\":true,\"PageSettings\":{ \"TotalCount\":\"10\",\"PageNumber\":\"1\",\"PageSize\":\"12\"},\"BillFetchConfiguration\":{ \"FetchBillInfo\":\"false\"} } }";
					string requestUrlAccDet = Constants.BaseAddressUrl + "/BillService.svc/GetPaymentInfoListForAccount";

					client.BaseAddress = new Uri(Constants.BaseAddressUrl);
					client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
					var responseAccDet = await client.PostAsync(requestUrlAccDet, new StringContent(jsonParameterAccDet, Encoding.UTF8, "application/json"));
					var jsonAccDet = await responseAccDet.Content.ReadAsStringAsync().ConfigureAwait(false);

					authResPayment = JsonConvert.DeserializeObject<LastPaymentRes>(jsonAccDet);
					var billhisItm = new PaymentInfolst();
					string billhisDate = "";
					foreach (var item in authResPayment.PaymentInfo)
					{
						billhisItm.AccountNumber = item.AccountNumber;
						billhisItm.PaidAmount = item.PaidAmount;
						var dd = item.PaymentDate.Date.Day;
						var mm = item.PaymentDate.Date.Month;
						var yyyy = item.PaymentDate.Date.Year;
						billhisDate = dd + "-" + mm + "-" + yyyy;
						billhisItm.PaymentDate = billhisDate;
						billhisItm.PaymentChannel = item.PaymentChannel;
						billhisItm.PaymentType = item.PaymentType;
						billhisItm.PropertyName = item.PropertyName;

						billhisItm.TransactionID = item.TransactionID;
						paymentHistoryItems.Add(billhisItm);
					}


					Debug.WriteLine(jsonAccDet.ToString());
					//
					// Application.Current.Properties["TokenID"] = authResPayment.TokenID;
					// ResponseTxt = json.ToString();


				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Error: " + ex); //to show Network error...
				error = ex;
			}
			finally
			{
				IsBusy = false;
			}

			if (error != null)
				await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");


		}
	}
}
