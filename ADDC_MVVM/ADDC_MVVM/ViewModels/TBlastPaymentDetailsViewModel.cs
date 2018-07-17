using ADDC_MVVM.Models;
using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ADDC_MVVM.ViewModels
{
    public class TBlastPaymentDetailsViewModel : ViewModelBase
    {
		public ICommand OnTapMenu { get; set; }
        private string _date;
        public string date
        {
            get
            {
                return _date;
            }
            set
            {
                SetProperty(ref _date, value);
            }
        }
        private string _transactionID;
        public string transactionID
        {
            get
            {
                return _transactionID;
            }
            set
            {
                SetProperty(ref _transactionID, value);
            }
        }

        private string _paidAmount;
        public string paidAmount
        {
            get
            {
                return _paidAmount;
            }
            set
            {
                SetProperty(ref _paidAmount, value);
            }
        }

        string tokenID = Application.Current.Properties["TokenID"].ToString();
        private string _responseTxt;
        private AccountDetailsRes item1;

        public string ResponseTxt
        {
            get { return _responseTxt; }
            set { SetProperty(ref _responseTxt, value); }
        }

        public TBlastPaymentDetailsViewModel(AccountDetailsRes item1)
        {
            this.item1 = item1;
			OnTapMenu = new Command(
			   async () =>
				await App.Current.MainPage.Navigation.PopModalAsync(),
			() => !IsBusy);
             GetGetPaymentInfoList(item1);

            

        }

        private class AccountReqAcc
        {

            public string token { get; set; }
            public Userreq userreq { get; set; }
        }

        private class Userreq
        {

            public string Item { get; set; }
            public int ItemElementName { get; set; }
        }

        private async Task GetGetPaymentInfoList(AccountDetailsRes item1)
        {

            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;

                using (var client = new HttpClient(new NativeMessageHandler()))
                {
                    //Authentication step1
                    AccountRequestPay accountRequest = new AccountRequestPay() { AccountID = item1.AccountID, PersonID = Application.Current.Properties["PersonID"].ToString() };
                    PageSettings pageSettings = new PageSettings() { PageNumber = "1", PageSize = "12", TotalCount = "10" };
                    CLPaymentFilter CL_PaymentFilter = new CLPaymentFilter() { AccountRequest = accountRequest, PageSettings = pageSettings };
                    PaymentInfoReq parameterPayInfo = new PaymentInfoReq() { token = tokenID, CL_PaymentFilter = CL_PaymentFilter };
                    // string 
                    //AccountReq parameterPayInfo = new AccountReq() { personaccountrequest = perReq, token = tokenID };
                    string jsonParameterPayInfo = JsonConvert.SerializeObject(parameterPayInfo);
                    string requestUrlPayInfo = Constants.BaseAddressUrl + "/BillService.svc/GetPaymentInfoListForAccount";

                    client.BaseAddress = new Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var responsePayInfo = await client.PostAsync(requestUrlPayInfo, new StringContent(jsonParameterPayInfo, Encoding.UTF8, "application/json"));
                    var jsonPayInfo = await responsePayInfo.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Debug.WriteLine(jsonPayInfo.ToString());

                    LastPaymentRes authRes1 = JsonConvert.DeserializeObject<LastPaymentRes>(jsonPayInfo);
                    ResponseTxt = jsonPayInfo.ToString();
                    date = authRes1.PaymentInfo[0].PaymentDate.ToString();
                    transactionID = authRes1.PaymentInfo[0].TransactionID;
                    paidAmount = authRes1.PaymentInfo[0].PaidAmount.ToString();
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

   
