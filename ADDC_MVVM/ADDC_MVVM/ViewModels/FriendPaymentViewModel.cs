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
    public class FriendPaymentViewModel : ViewModelBase
    {
        public ICommand GetFriendOutstanding { get; set; }

        string tokenID = "123";// Application.Current.Properties["TokenID"].ToString();
       
        private string _frdAccID;
        public string frdAccountNumber
        {
            get { return _frdAccID; }
            set { SetProperty(ref _frdAccID, value); }
        }

        public FriendPaymentViewModel() {
            //IsBusy = false;
            GetFriendOutstanding = new Command(
                async () => await GetFriendBalance(),
                () => IsBusy);
        }

        private async Task GetFriendBalance()
        {
            if (IsBusy)
                return;

            Exception error = null;
            try
            {


                using (var client = new HttpClient(new NativeMessageHandler()))
                {
                    AccountFetchConfiguration accountFetchConfiguration = new AccountFetchConfiguration()
                    {
                        FetchAccNumbers = "true",
                        FetchAddress = "true",
                        FetchAccountDetails = "true",
                        FetchPayByDate = "true",
                        FetchOutstandingBalance = "true",
                        FetchInActiveAccounts = "true",
                        FetchPaymentDate = "true",
                        FetchAutoPaymentConfiguration = "true"
                    };
                    AccountRequestFrd accountRequest = new AccountRequestFrd() { AccountID = frdAccountNumber, AccountFetchConfiguration = accountFetchConfiguration };
                    FriendAccountReq friendReq = new FriendAccountReq() { accountRequest = accountRequest, token = tokenID };

                    
                    string jsonParameterAccDet = JsonConvert.SerializeObject(friendReq);
                    string requestUrlAccDet = Constants.BaseAddressUrl + "/AccountService.svc/GetDashboardDetailsForAccount";

                    client.BaseAddress = new Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var responseAccDet = await client.PostAsync(requestUrlAccDet, new StringContent(jsonParameterAccDet, Encoding.UTF8, "application/json"));
                    var jsonAccDet = await responseAccDet.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Debug.WriteLine(jsonAccDet.ToString());
                    MyAccount frdAccRes = JsonConvert.DeserializeObject<MyAccount>(jsonAccDet);
                    string OutStandingBalance = frdAccRes.OutstandingBalance.ToString();
                    //Application.Current.Properties["TokenID"] = frdAccRes.AuthResponce.







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
