using ADDC_MVVM.Models;
using ADDC_MVVM.Views;
using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ADDC_MVVM.Resx;
using System.Text.RegularExpressions;
using Plugin.Connectivity;

namespace ADDC_MVVM.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; set; }
        public ICommand OnTapMenu { get; set; }
        
        public ICommand NewUserCommand { get; set; }
        public ICommand ForgotPwdCommand { get; set;}
        private string _userNameEntryPlaceholder;
		const string passwordRegex = "^(?=.*?[a-zA-Z])(?=.*?[0-9])(?=.*?[_@.-]).{8,30}$";
        public string UserNameEntryPlaceholder
        {
            get { return _userNameEntryPlaceholder; }
            set { SetProperty(ref _userNameEntryPlaceholder, value); }
        }

        private string _passwordEntryPlaceholder;
        public string PasswordEntryPlaceholder
        {
            get { return _passwordEntryPlaceholder; }
            set { SetProperty(ref _passwordEntryPlaceholder, value); }
        }
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        public LoginViewModel()
        {
            LoadSelectedLanguage();
            //Title = "Speakers";
            LoginCommand = new Command(
                async () => await AuthUserNamePwd(),
                () => !IsBusy);

            OnTapMenu = new Command(
                async () => await App.Current.MainPage.Navigation.PopModalAsync(),
                () => !IsBusy);

            NewUserCommand = new Command(
                async () =>
                await App.Current.MainPage.Navigation.PushAsync(new OAEmiratesEntry(), false),

            () => !IsBusy);
            ForgotPwdCommand = new Command(
                async () =>
				await App.Current.MainPage.Navigation.PushModalAsync(new ForgotPasswordView() { BindingContext = new ForgotPasswordViewModel() }),

            () => !IsBusy);
        }


    private async Task AuthUserNamePwd()
        {
        
                if (IsBusy)
                    return;

                Exception error = null;
			try
			{
				bool IsValid = false;
				IsValid = (Regex.IsMatch(Password, passwordRegex));

				IsBusy = true;
				if (string.IsNullOrEmpty(UserName) && string.IsNullOrEmpty(Password))
				{
					await Application.Current.MainPage.DisplayAlert("Error!", AppResource.str_all_mandatory, "OK");
				}
				else if (string.IsNullOrEmpty(UserName))
				{
					await Application.Current.MainPage.DisplayAlert("Error!", AppResource.str_enter_user, "OK");
				}
				else if (string.IsNullOrEmpty(Password))
				{
					await Application.Current.MainPage.DisplayAlert("Error!", AppResource.str_enter_pass, "OK");
				}
				else if (!IsValid)
				{
					await Application.Current.MainPage.DisplayAlert("Error!", AppResource.str_enter_pass, "OK");
				}
				else
				{
					if (CrossConnectivity.Current.IsConnected == true)
					{


					using (var client = new HttpClient(new NativeMessageHandler()))
					{
						//Authentication step1
						// Password = "qwe-1234";
						//UserName = "msk555";
						//Password = "wee-1234";
						//UserName = "anvari";
						Authentication parameter = new Authentication() { Pwd = Password, UserID = UserName };
						string jsonParameter = JsonConvert.SerializeObject(parameter);
						string requestUrl = Constants.BaseAddressUrl + "/LoginService.svc/ValidateUserCredentials";

						client.BaseAddress = new Uri(Constants.BaseAddressUrl);
						client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
						var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
						var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
						Debug.WriteLine(json.ToString());
						if (json.Contains("Continue"))
						{
							AuthRes1 authRes1 = JsonConvert.DeserializeObject<AuthRes1>(json);
							Application.Current.Properties["TokenID"] = authRes1.TokenID;


							//Authentication Step2
							AuthItemParam2 authItemParam2 = new AuthItemParam2()
							{
								Item = UserName,
								ItemElementName = "1"
							};
							AuthParam2 parameter2 = new AuthParam2() { userreq = authItemParam2, token = authRes1.TokenID };

							jsonParameter = JsonConvert.SerializeObject(parameter2);
							requestUrl = Constants.BaseAddressUrl + "/UserService.svc/GetUserDetails";

							client.BaseAddress = new Uri(Constants.BaseAddressUrl);
							client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
							response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
							json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
							Debug.WriteLine(json.ToString());
							//if (json.Contains("Called Successfully"))
							//{
							GetGuestUserDetailsRes authRes2 = JsonConvert.DeserializeObject<GetGuestUserDetailsRes>(json);
								if (authRes2 != null)
								{
									if (authRes2.PersonID != null)
									{
										Application.Current.Properties["PersonID"] = authRes2.PersonID;
										Application.Current.Properties["UserID"] = authRes2.UserID;
										if (authRes2.AuthResponce != null)
										{
											Application.Current.Properties["TokenID"] = authRes2.AuthResponce.TokenID;

										}
										else
										{
											await Application.Current.MainPage.DisplayAlert(AppResource.str_gps_title, AppResource.str_try_again, AppResource.btn_ok);

										}

										if (authRes2.Resident != null)
										{
											if (authRes2.Resident.Person != null)
												Application.Current.Properties["EmailID"] = authRes2.Resident.Person.EmailID;
										}
										else
										{
											await Application.Current.MainPage.DisplayAlert(AppResource.str_gps_title, AppResource.str_try_again, AppResource.btn_ok);

										}


										//Authentication Final Step for FetchInActiveAccounts = "true"
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

										PersonRequest personRequest = new PersonRequest() { PersonID = authRes2.PersonID };

										PageSettings pageSettings = new PageSettings() { TotalCount = "10", PageNumber = "1", PageSize = "5" };

										Accountfilter accountfilter = new Accountfilter() { PageSettings = pageSettings, PersonRequest = personRequest, AccountFetchConfiguration = accountFetchConfiguration };

										AuthFinalReq parameter3 = new AuthFinalReq() { token = authRes2.AuthResponce.TokenID, accountfilter = accountfilter };

										jsonParameter = JsonConvert.SerializeObject(parameter3);
										requestUrl = Constants.BaseAddressUrl + "/AccountService.svc/GetAccountsForUser";

										client.BaseAddress = new Uri(Constants.BaseAddressUrl);
										client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
										response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
										json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
										Debug.WriteLine(json.ToString());
										MyAccountDetails authRes4 = JsonConvert.DeserializeObject<MyAccountDetails>(json);
										Application.Current.Properties["TokenID"] = authRes4.AuthResponce.TokenID;
										Application.Current.Properties["AccountID"] = authRes4.AccountDetails[0].AccountID; ;
										Application.Current.Properties["AccountIDs"] = authRes4.AccountDetails; ;

										//Authentication Final Step for FetchInActiveAccounts = "false"

										//accountFetchConfiguration = new AccountFetchConfiguration()
										//{
										//	FetchAccNumbers = "true",
										//	FetchAddress = "true",
										//	FetchAccountDetails = "true",
										//	FetchPayByDate = "true",
										//	FetchOutstandingBalance = "true",
										//	FetchInActiveAccounts = "false",
										//	FetchPaymentDate = "true",
										//	FetchAutoPaymentConfiguration = "true"
										//};

										//jsonParameter = JsonConvert.SerializeObject(parameter3);
										//requestUrl = Constants.BaseAddressUrl + "/AccountService.svc/GetAccountsForUser";

										//client.BaseAddress = new Uri(Constants.BaseAddressUrl);
										//client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
										//response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
										//json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
										//Debug.WriteLine(json.ToString());
										//MyAccountDetails authRes3 = JsonConvert.DeserializeObject<MyAccountDetails>(json);
										//Application.Current.Properties["authRes4"] = authRes4;
										//Application.Current.Properties["TokenID"] = authRes3.AuthResponce.TokenID;
										//Application.Current.Properties["PersonID"] = authRes2.PersonID;
										////var auth = Application.Current.Properties["token"];

										await App.Current.MainPage.Navigation.PushModalAsync(new MyAccountView() { BindingContext = new MyAccountViewModel() });
										// await App.Current.MainPage.Navigation.PushAsync(new MenuPage() { BindingContext = new MenuPageViewModel(authRes4) });
									}
								
								else
								{
									//Debug.WriteLine("Error: " + ex); //to show Network error...
									await Application.Current.MainPage.DisplayAlert(AppResource.str_gps_title, AppResource.str_try_again, AppResource.btn_ok);
								}
								}

								else
								{
									await Application.Current.MainPage.DisplayAlert(AppResource.str_gps_title, AppResource.str_try_again, AppResource.btn_ok);
								}

						}
						else if (json.Contains("WrongPassword"))
						{
							await Application.Current.MainPage.DisplayAlert(AppResource.str_gps_title, AppResource.str_pass_not_match, AppResource.btn_ok);

						}
						else
						{
							//Debug.WriteLine("Error: " + ex); //to show Network error...
							await Application.Current.MainPage.DisplayAlert(AppResource.str_gps_title, AppResource.str_try_again, AppResource.btn_ok);
						}
					}
						}
					else
					{
						await Application.Current.MainPage.DisplayAlert("Error!", AppResource.str_network, "OK");
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


        /// <summary>
        /// 
        /// </summary>
        public void LoadSelectedLanguage()
        {
            UserNameEntryPlaceholder = "UserName";
            PasswordEntryPlaceholder = "Password";
           
        }

    }
}
