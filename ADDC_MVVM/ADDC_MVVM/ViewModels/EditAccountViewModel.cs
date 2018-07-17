using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADDC_MVVM.Models;
using System.Windows.Input;
using Xamarin.Forms;
using System.Diagnostics;
using System.Net.Http;
using ModernHttpClient;
using Newtonsoft.Json;
using ADDC_MVVM.Views;

namespace ADDC_MVVM.ViewModels
{
    public class EditAccountViewModel : ViewModelBase
    {
        private AccountDetailsRes item1;
        private AccountDetailsRes authResAccDet;
        public ICommand SaveCommand { get; set; }
       // public ICommand OnPrefPickerChanged { get; set; }
        public ICommand OnTapMenu { get; set; }
        public ICommand OnPrefPickerChanged { get; set; }
        public ICommand OnAddrPickerChanged { get; set; }
        
        
        private string _accNum;
        public string AccNum
        {
            get { return _accNum; }
            set { SetProperty(ref _accNum, value); }
        }
        private string _billCycle;
        public string BillCycle
        {
            get { return _billCycle; }
            set { SetProperty(ref _billCycle, value); }
        }
        private string _permise_id;
        public string Permise_id
        {
            get { return _permise_id; }
            set { SetProperty(ref _permise_id, value); }
        }
        private string _permise_type;
        public string Permise_type
        {
            get { return _permise_type; }
            set { SetProperty(ref _permise_type, value); }
        }
        private string _tariffType;
        public string TariffType
        {
            get { return _tariffType; }
            set { SetProperty(ref _tariffType, value); }
        }
        private string _poBox;
        public string PoBox
        {
            get { return _poBox; }
            set { SetProperty(ref _poBox, value); }
        }
        /// <summary>
        /// ///picker
        /// </summary>
        private List<string> _subElementList;
        public List<string> SubElementList
        {
            get { return _subElementList; }
            set { SetProperty(ref _subElementList, value); }
        }

        /// <summary>
        /// selectpicker
        /// </summary>
        private string _subElementName;
        public string SubElementName
        {
            get { return _subElementName; }
            set { SetProperty(ref _subElementName, value); }
        }

        public EditAccountViewModel()
        {
        }
        public EditAccountViewModel(AccountDetailsRes item1)
        {
            this.item1 = item1;

            authResAccDet = Application.Current.Properties["AccDet"] as AccountDetailsRes;
            if (authResAccDet !=null)
            {
                LoadView();
            }
			OnTapMenu = new Command(
			   async () =>
				await App.Current.MainPage.Navigation.PopModalAsync(),
			() => !IsBusy);

			SaveCommand = new Command(
               async () => await SaveAucountDetails(item1),
               () => !IsBusy);
          

           

        }


        private void LoadView()
        {
            AccNum = authResAccDet.AccountID;
            BillCycle = authResAccDet.BillCycle.MasterData.Value;
             Permise_id = authResAccDet.Premises[0].ID;
             Permise_type = authResAccDet.Premises[0].Type;
             TariffType = authResAccDet.ElectricityMeterCollection.ElectricityMeter[0].ServiceAgreement.TariffType.ToString();
            PoBox = authResAccDet.Premises[0].Address.POBox;
        }

        private async Task SaveAucountDetails(AccountDetailsRes item1)
        {

            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;
                string tokenID = Application.Current.Properties["TokenID"].ToString();
                using (var client = new HttpClient(new NativeMessageHandler()))
                {
                    //Authentication step1
                    Personaccountrequest perReq = new Personaccountrequest() { AccountID = item1.AccountID };
                    // string 
					Address address = new Address() {Country = authResAccDet.Premises[0].Address.Country , 
						AreaCode = authResAccDet.Premises[0].Address.AreaCode, Address1 = authResAccDet.Premises[0].Address.Address1,
						Address2 = authResAccDet.Premises[0].Address.Address2, Address3 = authResAccDet.Premises[0].Address.Address3, 
						POBox = PoBox, Area = authResAccDet.Premises[0].Address.Area,
						City = Application.Current.Properties["AddVal"].ToString(), Emirate = Convert.ToInt32(Application.Current.Properties["IndexVal"]) };
                    BillRoute billRoute = new BillRoute() {BillPreference = Int32.Parse(Application.Current.Properties["BillPreference"].ToString()) };
					AccountRequested accountReq = new AccountRequested() { AccountID = item1.AccountID, PersonID = Application.Current.Properties["PersonID"].ToString() };
                    CLAccountBillPreferenceRequest clAccbill = new CLAccountBillPreferenceRequest() { AccountRequest = accountReq, BillRoute = billRoute, Address = address };
                    EditAccountReq parameterEdtAcc = new EditAccountReq() { CL_AccountBillPreferenceRequest = clAccbill, token = tokenID};
                    string jsonParameterEdtAcc = JsonConvert.SerializeObject(parameterEdtAcc);
                    string requestUrlEdtAcc = Constants.BaseAddressUrl + "/AccountService.svc/SetBillPreferenceForAccount";

                    client.BaseAddress = new Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var responseEdtAcc = await client.PostAsync(requestUrlEdtAcc, new StringContent(jsonParameterEdtAcc, Encoding.UTF8, "application/json"));
                    var jsonEdtAcc = await responseEdtAcc.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Debug.WriteLine(jsonEdtAcc.ToString());
					JsonRes authRes = JsonConvert.DeserializeObject<JsonRes>(jsonEdtAcc);

					Application.Current.Properties["TokenID"] = authRes.AuthResponce.TokenID;
                    /////////////////////
                    AccountFetchConfiguration accountFetchConfiguration = new AccountFetchConfiguration()
                    {
                        FetchAccNumbers = "true",
                        FetchAddress = "true",
                        FetchAccountDetails = "true",
                        FetchPayByDate = "true",
                        FetchOutstandingBalance = "true",
                        FetchInActiveAccounts = "false",
                        FetchPaymentDate = "true",
                        FetchAutoPaymentConfiguration = "true"
                    };
                    PersonRequest personRequest = new PersonRequest() { PersonID = Application.Current.Properties["PersonID"].ToString() };

                    PageSettings pageSettings = new PageSettings() { TotalCount = "10", PageNumber = "1", PageSize = "5" };

                    Accountfilter accountfilter = new Accountfilter() { PageSettings = pageSettings, PersonRequest = personRequest, AccountFetchConfiguration = accountFetchConfiguration };

                    AuthFinalReq parameter3 = new AuthFinalReq() { token = Application.Current.Properties["TokenID"].ToString() , accountfilter = accountfilter };

                   

                   var  jsonParameter = JsonConvert.SerializeObject(parameter3);
                   var  requestUrl = Constants.BaseAddressUrl + "/AccountService.svc/GetAccountsForUser";

                    client.BaseAddress = new Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                   var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
                   var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Debug.WriteLine(json.ToString());
                    MyAccountDetails authRes4 = JsonConvert.DeserializeObject<MyAccountDetails>(json);



                    authResAccDet = authRes4.AccountDetails[0];
                     Application.Current.Properties["TokenID"] = authRes4.AuthResponce.TokenID;
                    var ResponseTxt = json.ToString();

                   // await App.Current.MainPage.Navigation.PushModalAsync(new accountDetailsTabPage(authResAccDet));
					await App.Current.MainPage.Navigation.PopModalAsync();//(new accountDetailsTabPage(authResAccDet));

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

        private async Task GetAucountDetails(AccountDetailsRes item1)
        {

            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;
                string tokenID = Application.Current.Properties["TokenID"].ToString();
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
                    authResAccDet = JsonConvert.DeserializeObject<AccountDetailsRes>(jsonAccDet);
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
