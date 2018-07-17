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
    class AccountDetailsMainViewModel : ViewModelBase
    {
        public ICommand AccountDetailsCommand { get; set; }
        public ICommand LastBillCommand { get; set; }
        public ICommand LastPAyCommand { get; set; }
		public ICommand OneditClicked { get; set; }

        string tokenID = Application.Current.Properties["TokenID"].ToString();


            private string _responseTxt;
        private AccountDetailsRes item1;

        public string ResponseTxt
        {
            get { return _responseTxt; }
            set { SetProperty(ref _responseTxt, value); }
        }
        public AccountDetailsMainViewModel()
        {
            //IsVis = false;
            //  LoadSelectedLanguage();
            //Title = "Speakers";
           
        }

        public AccountDetailsMainViewModel(AccountDetailsRes item1)
        {
            this.item1 = item1;
            AccountDetailsCommand = new Command(
               async () => await GetAucountDetails(item1),
               () => !IsBusy);

            LastBillCommand = new Command(
				async () => await GetLatestBill(item1),
				() => !IsBusy);
			OneditClicked = new Command(
				async () => await GetLatestBill(item1),
				() => !IsBusy);
			
            LastPAyCommand = new Command(
                async () => await GetGetPaymentInfoList(item1),
                () => !IsBusy);
        }

        private async Task GetAucountDetails(AccountDetailsRes item1)
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
                    Personaccountrequest perReq = new Personaccountrequest() { AccountID = item1.AccountID };
                    // string 
                    AccountReq parameterAccDet = new AccountReq() { personaccountrequest = perReq, token = tokenID };
                    string jsonParameterAccDet = JsonConvert.SerializeObject(parameterAccDet);
                    string requestUrlAccDet = Constants.BaseAddressUrl + "/AccountService.svc/GetAccount";

                    client.BaseAddress = new Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var responseAccDet = await client.PostAsync(requestUrlAccDet, new StringContent(jsonParameterAccDet, Encoding.UTF8, "application/json"));
                    var jsonAccDet = await responseAccDet.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Debug.WriteLine(jsonAccDet.ToString());
                    AuthRes1 authResAccDet = JsonConvert.DeserializeObject<AuthRes1>(jsonAccDet);
                    Application.Current.Properties["TokenID"] = authResAccDet.TokenID;
                    // ResponseTxt = json.ToString();

                    /////GetPersonMaintenanceDetails
                    Userreq userreq = new Userreq() { Item = Application.Current.Properties["PersonID"].ToString(), ItemElementName = 0 };
                    // string 
                    AccountReqAcc parameterAccDet1 = new AccountReqAcc() { token = tokenID, userreq = userreq };
                    string jsonParameterAccDet1 = JsonConvert.SerializeObject(parameterAccDet1);
                    string requestUrlAccDet1 = Constants.BaseAddressUrl + "/UserService.svc/GetPersonMaintenanceDetails";

                    client.BaseAddress = new Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var responseAccDet1 = await client.PostAsync(requestUrlAccDet1, new StringContent(jsonParameterAccDet1, Encoding.UTF8, "application/json"));
                    var jsonAccDet1 = await responseAccDet1.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Debug.WriteLine(jsonAccDet1.ToString());
                    AuthRes1 authResAccDet1 = JsonConvert.DeserializeObject<AuthRes1>(jsonAccDet1);
                    Application.Current.Properties["TokenID"] = authResAccDet1.TokenID;
                    ResponseTxt = jsonAccDet.ToString();

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
        private async Task GetLatestBill(AccountDetailsRes item1)
        {

            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;

                using (var client = new HttpClient(new NativeMessageHandler()))
                {
                    AccountRequest accountRequest = new AccountRequest() { AccountID = item1.AccountID };
                    PageSettings pageSettings = new PageSettings() { PageNumber = "1", PageSize = "5", TotalCount = "10" };
                    BillFetchConfiguration billFetchConfiguration = new BillFetchConfiguration() { FetchBillInfo = "true" };
                    //Authentication step1
                    Billfilter billfilter = new Billfilter() {AccountRequest = accountRequest , PayByDateDesc ="true" , PageSettings = pageSettings, BillFetchConfiguration = billFetchConfiguration };
                    // string 
                    LastBillReq parameter = new LastBillReq() {billfilter = billfilter , token = tokenID };
                    string jsonParameter = JsonConvert.SerializeObject(parameter);
                    string requestUrl = Constants.BaseAddressUrl + "/AccountService.svc/GetLatestBill";

                    client.BaseAddress = new Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Debug.WriteLine(json.ToString());
                    LastBillRes lastBillRes = JsonConvert.DeserializeObject<LastBillRes>(json);
                    Application.Current.Properties["TokenID"] = lastBillRes.AuthResponce.TokenID;

                    //final bill generate 
                    CLBillRequest CL_BillRequest = new CLBillRequest() { AccountID = item1.AccountID, BillID = lastBillRes.BillID, BillFetchConfiguration = billFetchConfiguration };
                    GetBillReq parameterLB = new GetBillReq() { token = tokenID, CL_BillRequest = CL_BillRequest };
                    string jsonParameterLB = JsonConvert.SerializeObject(parameterLB);
                    string requestUrlLB = Constants.BaseAddressUrl + "/BillService.svc/GetBill";

                    client.BaseAddress = new Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var responseLB = await client.PostAsync(requestUrlLB, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
                    var jsonLB = await responseLB.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Debug.WriteLine(jsonLB.ToString());
                    LastBillRes authRes1 = JsonConvert.DeserializeObject<LastBillRes>(json);
                    Application.Current.Properties["TokenID"] = authRes1.AuthResponce.TokenID;


                    ResponseTxt = json.ToString();
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
                    AccountRequestPay accountRequest = new AccountRequestPay() {AccountID = item1.AccountID , PersonID = Application.Current.Properties["PersonID"].ToString() };
                    PageSettings pageSettings = new PageSettings() { PageNumber = "1", PageSize = "12", TotalCount= "10" };
                    CLPaymentFilter CL_PaymentFilter = new CLPaymentFilter() { AccountRequest = accountRequest, PageSettings = pageSettings };
                    PaymentInfoReq parameterPayInfo = new PaymentInfoReq() {token = tokenID, CL_PaymentFilter = CL_PaymentFilter };
                    // string 
                    //AccountReq parameterPayInfo = new AccountReq() { personaccountrequest = perReq, token = tokenID };
                    string jsonParameterPayInfo = JsonConvert.SerializeObject(parameterPayInfo);
                    string requestUrlPayInfo = Constants.BaseAddressUrl + "/BillService.svc/GetPaymentInfoListForAccount";

                    client.BaseAddress = new Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var responsePayInfo = await client.PostAsync(requestUrlPayInfo, new StringContent(jsonParameterPayInfo, Encoding.UTF8, "application/json"));
                    var jsonPayInfo = await responsePayInfo.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Debug.WriteLine(jsonPayInfo.ToString());
                    AuthRes1 authRes1 = JsonConvert.DeserializeObject<AuthRes1>(jsonPayInfo);
                    Application.Current.Properties["TokenID"] = authRes1.TokenID;
                    ResponseTxt = jsonPayInfo.ToString();
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
    }

}

