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
    public class paymentHistoryDataTemplate
    {

        public string accNumber { get; set; }
        public string paymentDate { get; set; }
        public string paidAmount { get; set; }
        public string transactionID { get; set; }

    }

    public class paymentHistoryViewModel : ViewModelBase
    {
       // public ObservableCollection<paymentHistoryDataTemplate> paymentHistoryItems { get; set; }
       // public paymentHistoryDataTemplate item11 { get; set; }
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        public LastPaymentRes authResAccDet { get; set; }
        public ObservableCollection<PaymentInfo> paymentHistoryItems { get; set; }

        // public ObservableCollection<paymentHistoryDataTemplate> paymentHistoryItems { get; set; }
        public paymentHistoryDataTemplate item1 { get; set; }
        public ICommand GetSessionsCommand { get; set; }
        public paymentHistoryViewModel()
        {
            paymentHistoryItems = new ObservableCollection<PaymentInfo>();
            GetSessionsCommand = RefreshCommand = new Command(
               async () => await GetpaymentHistoryDetails(),
               () => !IsBusy);
            GetpaymentHistoryDetailsAsy();


            //paymentHistoryItems = new ObservableCollection<paymentHistoryDataTemplate>();
            //item11 = new paymentHistoryDataTemplate();
            //item11.accNumber = "11111";
            //paymentHistoryItems.Add(item11);

        
        }

        private async void GetpaymentHistoryDetailsAsy()
        {
            await GetpaymentHistoryDetails();
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

                    authResAccDet = JsonConvert.DeserializeObject<LastPaymentRes>(jsonAccDet);

                    foreach (var item in authResAccDet.PaymentInfo)
                        paymentHistoryItems.Add(item);

                    Debug.WriteLine(jsonAccDet.ToString());
                    //
                    // Application.Current.Properties["TokenID"] = authResAccDet.TokenID;
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
