using ADDC_MVVM.Models;
using ADDC_MVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ADDC_MVVM.Resx;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net.Http;
using Plugin.Connectivity;
using ModernHttpClient;

namespace ADDC_MVVM.ViewModels
{
   public class MyAccountViewModel : ViewModelBase
    {
        private MyAccountDetails authRes4;

        public ObservableCollection<AccountDetailsRes> myAccount { get; set; }
        public ICommand OnTapMenu { get; set; }
        //public AccountDetail myAccountDetail { get; set; }
        //public string OutstandingBalance { get; set; }// { return myAccountDetail?.OutstandingBalance.ToString(); } }
        public ICommand GetSessionsCommand { get; set; }
        public ICommand HistoryCommand { get; set; }
        public ICommand MyProfileCommand { get; set; }
        public ICommand EnquireCommand { get; set; }
        public ICommand SuggestionCommand { get; set; }
        public ICommand PayNowCommand { get; set; }
		private string _outstandingBalance;
		public string OutstandingBalance
		{
			get { return _outstandingBalance; }
			set { SetProperty(ref _outstandingBalance, value); }
		}

		private Exception error;
        public ObservableCollection<AccountDetailsRes> myFlterList { get; set; }
        //public MyAccountViewModel()
        //{
           
        //}
       

        public MyAccountViewModel()
        {
            //this.authRes4 = authRes41;
            //if(authRes4 == null)
            //{
            //    authRes4 = Application.Current.Properties["authRes4"] as MyAccountDetails;
            //}
			//OutstandingBalance =authRes4.AccountDetails[0].OutstandingBalance.ToString();
            myAccount = new ObservableCollection<AccountDetailsRes>();
            myFlterList = new ObservableCollection<AccountDetailsRes>();
			//         foreach (var item in authRes4.AccountDetails)
			//             myAccount.Add(item);
			//         error = null;
			//  bGColor = 
			// myAccount = authRes4.AccountDetails;
			asyAccDetails();
            Title = "Sessions";
            HistoryCommand = new Command(
                async () => await GetMyHistory(),
                () => !IsBusy);
            OnTapMenu = new Command(
               async () => await OnTapMenuCmd(),
               () => !IsBusy);

            MyProfileCommand = new Command(
                  async () => await GetMyProfile(),
                  () => !IsBusy);
            GetSessionsCommand = new Command(
                async () => await GetMyAccount(),
                () => !IsBusy);

            EnquireCommand = new Command(
                           async () => await GetEnquire(),
                           () => !IsBusy);

            SuggestionCommand = new Command(
                           async () => await GetSuggestion(),
                           () => !IsBusy);
            PayNowCommand = new Command(
                async () => await PaymentPage(),
                () => !IsBusy);
        }

		async void asyAccDetails()
		{
			await AccountDetails();
		}

		/// <summary>
		///  menu button is clicked to navigate to menu options   
		/// </summary>
		/// <returns></returns>
		private async Task OnTapMenuCmd()
		{

			await App.Current.MainPage.Navigation.PushModalAsync(new MenuPage() { BindingContext = new MenuPageViewModel(authRes4) });

		}

		////////////////
		private async Task AccountDetails()
		{

			if (IsBusy)
				return;

			Exception error = null;
			try
			{

				IsBusy = true;


				if (CrossConnectivity.Current.IsConnected == true)
				{


					using (var client = new HttpClient(new NativeMessageHandler()))
					{
						//Authentication step1
						// Password = "qwe-1234";
						//UserName = "msk555";
						//Password = "wee-1234";
						//UserName = "anvari";
						//Authentication parameter = new Authentication() { Pwd = Password, UserID = UserName };
						string jsonParameter = "";//JsonConvert.SerializeObject(parameter);
						string requestUrl = "";// Constants.BaseAddressUrl + "/LoginService.svc/ValidateUserCredentials";

						//client.BaseAddress = new Uri(Constants.BaseAddressUrl);
						//client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
						//var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
						//var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
						//Debug.WriteLine(json.ToString());
						//if (json.Contains("Continue"))
						//{
						//	AuthRes1 authRes1 = JsonConvert.DeserializeObject<AuthRes1>(json);
						//	Application.Current.Properties["TokenID"] = authRes1.TokenID;


						//	//Authentication Step2
						//	AuthItemParam2 authItemParam2 = new AuthItemParam2()
						//	{
						//		Item = UserName,
						//		ItemElementName = "1"
						//	};
						//	AuthParam2 parameter2 = new AuthParam2() { userreq = authItemParam2, token = authRes1.TokenID };

						//	jsonParameter = JsonConvert.SerializeObject(parameter2);
						//	requestUrl = Constants.BaseAddressUrl + "/UserService.svc/GetUserDetails";

						//	client.BaseAddress = new Uri(Constants.BaseAddressUrl);
						//	client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
						//	response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
						//	json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
						//	Debug.WriteLine(json.ToString());
						//	//if (json.Contains("Called Successfully"))
						//	//{
						//	GetGuestUserDetailsRes authRes2 = JsonConvert.DeserializeObject<GetGuestUserDetailsRes>(json);
						//	if (authRes2 != null)
						//	{
						//		if (authRes2.PersonID != null)
						//		{
						//			Application.Current.Properties["PersonID"] = authRes2.PersonID;
						//			Application.Current.Properties["UserID"] = authRes2.UserID;
						//			if (authRes2.AuthResponce != null)
						//			{
						//				Application.Current.Properties["TokenID"] = authRes2.AuthResponce.TokenID;

						//			}
						//			else
						//			{
						//				await Application.Current.MainPage.DisplayAlert(AppResource.str_gps_title, AppResource.str_try_again, AppResource.btn_ok);

						//			}

						//			if (authRes2.Resident != null)
						//			{
						//				if (authRes2.Resident.Person != null)
						//					Application.Current.Properties["EmailID"] = authRes2.Resident.Person.EmailID;
						//			}
						//			else
						//			{
						//				await Application.Current.MainPage.DisplayAlert(AppResource.str_gps_title, AppResource.str_try_again, AppResource.btn_ok);

						//			}


						//Authentication Final Step for FetchInActiveAccounts = "true
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

						PersonRequest personRequest = new PersonRequest() { PersonID = Application.Current.Properties["PersonID"].ToString() };

						PageSettings pageSettings = new PageSettings() { TotalCount = "10", PageNumber = "1", PageSize = "5" };

						Accountfilter accountfilter = new Accountfilter() { PageSettings = pageSettings, PersonRequest = personRequest, AccountFetchConfiguration = accountFetchConfiguration };

						AuthFinalReq parameter3 = new AuthFinalReq() { token = Application.Current.Properties["TokenID"].ToString(), accountfilter = accountfilter };

						jsonParameter = JsonConvert.SerializeObject(parameter3);
						requestUrl = Constants.BaseAddressUrl + "/AccountService.svc/GetAccountsForUser";

						client.BaseAddress = new Uri(Constants.BaseAddressUrl);
						client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
						var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
						var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
						Debug.WriteLine(json.ToString());
						MyAccountDetails authRes4 = JsonConvert.DeserializeObject<MyAccountDetails>(json);
						Application.Current.Properties["TokenID"] = authRes4.AuthResponce.TokenID;
						Application.Current.Properties["AccountID"] = authRes4.AccountDetails[0].AccountID; ;
						Application.Current.Properties["AccountIDs"] = authRes4.AccountDetails; 

							OutstandingBalance =authRes4.AccountDetails[0].OutstandingBalance.ToString();
           
            foreach (var item in authRes4.AccountDetails)
                myAccount.Add(item);
            error = null;
//										//Authentication Final Step for FetchInActiveAccounts = "false"
//
//										accountFetchConfiguration = new AccountFetchConfiguration()
//										{
//											FetchAccNumbers = "true",
//											FetchAddress = "true",
//											FetchAccountDetails = "true",
//											FetchPayByDate = "true",
//											FetchOutstandingBalance = "true",
//											FetchInActiveAccounts = "false",
//											FetchPaymentDate = "true",
//											FetchAutoPaymentConfiguration = "true"
//										};

						//										jsonParameter = JsonConvert.SerializeObject(parameter3);
						//										requestUrl = Constants.BaseAddressUrl + "/AccountService.svc/GetAccountsForUser";

						//										client.BaseAddress = new Uri(Constants.BaseAddressUrl);
						//										client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
						//										response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
						//										json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
						//										Debug.WriteLine(json.ToString());
						//										MyAccountDetails authRes3 = JsonConvert.DeserializeObject<MyAccountDetails>(json);
						//										Application.Current.Properties["authRes4"] = authRes4;
						//										Application.Current.Properties["TokenID"] = authRes3.AuthResponce.TokenID;
						//										Application.Current.Properties["PersonID"] = authRes2.PersonID;
						//										//var auth = Application.Current.Properties["token"];
						//
						//										await App.Current.MainPage.Navigation.PushModalAsync(new MyAccountView() { BindingContext = new MyAccountViewModel(authRes4) });
						//										// await App.Current.MainPage.Navigation.PushAsync(new MenuPage() { BindingContext = new MenuPageViewModel(authRes4) });
						//					}

						//									else
						//									{
						//						//Debug.WriteLine("Error: " + ex); //to show Network error...
						//						await Application.Current.MainPage.DisplayAlert(AppResource.str_gps_title, AppResource.str_try_again, AppResource.btn_ok);
						//					}
						//				}

						//				else
						//				{
						//					await Application.Current.MainPage.DisplayAlert(AppResource.str_gps_title, AppResource.str_try_again, AppResource.btn_ok);
						//				}

						//			}
						//							else if (json.Contains("WrongPassword"))
						//			{
						//				await Application.Current.MainPage.DisplayAlert(AppResource.str_gps_title, AppResource.str_pass_not_match, AppResource.btn_ok);

						//			}
						//			else
						//			{
						//				//Debug.WriteLine("Error: " + ex); //to show Network error...
						//				await Application.Current.MainPage.DisplayAlert(AppResource.str_gps_title, AppResource.str_try_again, AppResource.btn_ok);
						//			}
						//		}
						//	}
						//					else
						//					{
						//						await Application.Current.MainPage.DisplayAlert("Error!", AppResource.str_network, "OK");
						//}
					}
				}
			}

			catch (Exception ex)
			{
				Debug.WriteLine("Error: " + ex); //to show Network error..
				error = ex;
			}
			finally
			{
				IsBusy = false;
			}

			if (error != null)
				await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");
		}

		//////////////////

        /// <summary>
        /// navigating to payment page
        /// </summary>
        /// <returns></returns>
        private async Task PaymentPage()
        {
           // var test = myFlterList;
           if (myFlterList.Count >0)
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new PaymentHomeView() { BindingContext = new PaymentHomeViewModel(myFlterList) });
            }
           else
            {
                await Application.Current.MainPage.DisplayAlert("Error!", "Select atleast one account", "OK");
            }

        }

        private async Task GetMyHistory()
        {
            await App.Current.MainPage.Navigation.PushAsync(new History());

        }
        private async Task GetEnquire()
        {
            await App.Current.MainPage.Navigation.PushAsync(new CustomerEnquiry() { BindingContext = new CustomerEnqViewModel() });


        }
        private async Task GetSuggestion()
        {//View.myFlterList
            await App.Current.MainPage.Navigation.PushAsync(new CustomerSuggession() { BindingContext = new CustomerSuggessionViewModel() });


        }

        private async Task GetMyProfile()
        {
            
            await App.Current.MainPage.Navigation.PushAsync(new myProfile() { BindingContext = new myProfileViewModel(authRes4) });


        }

        private Task GetMyAccount()
        {
            throw new NotImplementedException();
        }
    }
}
