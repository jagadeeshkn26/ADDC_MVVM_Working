using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADDC_MVVM.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Net.Http;
using ModernHttpClient;
using Newtonsoft.Json;
using System.Diagnostics;
using ADDC_MVVM.Views;

namespace ADDC_MVVM.ViewModels
{
    public class SavedCardsViewModel : ViewModelBase
    {
        public ObservableCollection<GetSavedCardRes> getSavedCrd;
        public ObservableCollection<GetSavedCardRes> getSavedCardRes { get; set; }
        public ObservableCollection<GetSavedCardRes> flterCardRes;//{ get; set; }
        private ObservableCollection<AccountDetailsRes> myFlterList;

        public ICommand btnPayBill { get; set; }
        
        public SavedCardsViewModel()
        {

        }

        public SavedCardsViewModel(ObservableCollection<GetSavedCardRes> getSavedCard , ObservableCollection<AccountDetailsRes> myFlterList)
        {
            this.myFlterList = myFlterList;
            getSavedCrd = new ObservableCollection<GetSavedCardRes>();
            flterCardRes = new ObservableCollection<GetSavedCardRes>();
            if (getSavedCard.Count > 5)
            {
                int i = 0;
                foreach(var savedCard in getSavedCard)
                {
                    if(i <5)
                    {
                        getSavedCrd.Add(savedCard);
                        i++;
                    }                   
                }
            }
            else
            {
                this.getSavedCrd = getSavedCard;
            }
            getSavedCardRes = getSavedCard;
            btnPayBill = new Command(
                async () => await SubmitPayment(),
                () => !IsBusy);
        }



        private async Task SubmitPayment()
        {

            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;
                string tokenID = Application.Current.Properties["TokenID"].ToString();
                string personID = Application.Current.Properties["PersonID"].ToString();
                string Total = Application.Current.Properties["Total"].ToString();
                int total = Int32.Parse(Total);
                using (var client = new HttpClient(new NativeMessageHandler()))
                {
                    CardInfo cardInfo = new CardInfo()
                    {
                        Brand = flterCardRes[0].Brand,
                        Name = flterCardRes[0].Name ,
                        Number = "1111"
                    };
                    List<BillInfoAuthorise> billInfo = new List<BillInfoAuthorise>();
                    
                    BillInfoAuthorise billIn = new BillInfoAuthorise();
                    foreach (var billinf in myFlterList)
                    {
                        BillInfoAuthorise billInfoAuthorise = new BillInfoAuthorise();
                        billInfoAuthorise.AccountNumber = billinf.AccountID;
                        billInfoAuthorise.Amount = billinf.OutstandingBalance;
                        billInfoAuthorise.FriendPayment = false;
                       // billIn = billInfoAuthorise;
                        billInfo.Add(billInfoAuthorise);
                    }
                    BillInfoCollection billInfoCollection = new BillInfoCollection() { BillInfo = billInfo };
                    CLRegisterPaymentRequest CL_RegisterPaymentRequest = new CLRegisterPaymentRequest()
                    {
                        PersonID = personID,
                        TotalAmount = total,
                        ReturnPath = "https://localhost:52457/Finalize.aspx",
                        SaveCard = true,
                        PaymentMethod = 0,
                        BillInfoCollection = billInfoCollection,
                        CardInfo = cardInfo
                    };
                    AuthPaymentReq parameter2 = new AuthPaymentReq() {CL_RegisterPaymentRequest = CL_RegisterPaymentRequest, token = tokenID };

                    var jsonParameter = JsonConvert.SerializeObject(parameter2);
                    var requestUrl = Constants.BaseAddressUrl + "/PaymentService.svc/AuthorizePaymentForAccounts";

                    client.BaseAddress = new Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Debug.WriteLine(json.ToString());
					if (json != null)
					{
						var responsecls = JsonConvert.DeserializeObject<PayResponse>(json);
					//	var authRes4 = new MyAccountDetails();

						await App.Current.MainPage.Navigation.PushModalAsync(new ReciptPage(responsecls.TransactionID) );


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

    }
}
