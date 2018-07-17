using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ADDC_MVVM.Models;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using ModernHttpClient;
using System.Diagnostics;
using ADDC_MVVM.ViewModels;
using System.Collections.ObjectModel;
using ADDC_MVVM.Views;

namespace ADDC_MVVM.ViewModels
{
    
    public class myProfileViewModel : ViewModelBase
    {
        private MyAccountDetails authRes4;
        private GetGuestUserDetailsRes userDetails;
		private Exception error;
		int i = 0;
		bool L2, L3, L4, L5 = false;
		bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }
        public ICommand OneditClicked { get; set; }
		public ICommand OnTapMenu { get; set; }
		public ICommand OnChangePassword { get; set; }
		public ICommand OnTapFooter { get; set; }

        private string _customerID;
        public string customerID
        {
            get { return _customerID; }
            set { SetProperty(ref _customerID, value); }
        }

        private string _customerName;
        public string customerName
        {
            get { return _customerName; }
            set { SetProperty(ref _customerName, value); }
        }

        private string _userName;
        public string userName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        private string _emailID;
        public string emailID
        {
            get { return _emailID; }
            set { SetProperty(ref _emailID, value); }
        }

        private string _phNumber;
        public string phNumber
        {
            get { return _phNumber; }
            set { SetProperty(ref _phNumber, value); }
        }

        private string _phType;
        public string phType
        {
            get { return _phType; }
            set { SetProperty(ref _phType, value); }
        }

        private string _language;
        public string language
        {
            get { return _language; }
            set { SetProperty(ref _language, value); }
        }

        public myProfileViewModel()
        {
                 
        }
		public ObservableCollection<Phone> MyPhone { get; set; }

		public myProfileViewModel(MyAccountDetails authRes4)
        {

			MyPhone = new ObservableCollection<Phone>();
            this.authRes4 = authRes4;
			OnTapMenu = new Command(
			   async () =>
				await App.Current.MainPage.Navigation.PopModalAsync(),
			() => !IsBusy);
			OnChangePassword = new Command(
			   async () =>
				await App.Current.MainPage.Navigation.PushModalAsync(new ChangePassword() { BindingContext = new ChangePasswordViewModel() }),
			() => IsBusy);
			OnTapFooter = new Command(
				async () => await OnTapFooterCmd(),
			   () => !IsBusy);
			OneditClicked = new Command(startnewPage);
            GetmyProfileDetailsAsy();
        }

		 private async Task OnTapFooterCmd()
		{
			if (i == 0)
			{
				foreach (var item in userDetails.Resident.Person.Phone)
					if (i == 0)
					{
					
					}
					else
	
				{
					MyPhone.Add(item);
				}

				error = null;
				i = 1;
			}
			else
			{
				
				MyPhone.Clear();
				error = null;
				i = 0;
			}
		}

		private async void GetmyProfileDetailsAsy()
        {

            await GetmyProfileDetails();
            if (userDetails != null)
            {
                customerID = userDetails.PersonID;
                customerName = userDetails.Resident.Person.Name[0].Name1;
                userName = userDetails.UserID;
                emailID = userDetails.Resident.Person.EmailID;
                phNumber = userDetails.Resident.Person.Phone[0].Number;



				if (userDetails.Resident.Person.Phone[0].Type == 1)
				{
					phType = "mobile";
				}
				else if (userDetails.Resident.Person.Phone[0].Type == 2)
				{
					phType = "Work";
				}
				else if (userDetails.Resident.Person.Phone[0].Type == 3)
				{
					phType = "Home";
				}
				else
				{
					phType = userDetails.Resident.Person.Phone[0].Type.ToString();
				}
				if (userDetails.Resident.Person.LanguagePreference == 0)
				{
					language = "English";
				}
				else if (userDetails.Resident.Person.LanguagePreference == 1)
				{
					language = "Arabic";
				}
				else {
					language = userDetails.Resident.Person.LanguagePreference.ToString();
				}
            }

        }
        private async Task GetmyProfileDetails()
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
                    AuthItemParam2 authItemParam2 = new AuthItemParam2()
                    {
                        Item = Application.Current.Properties["PersonID"].ToString(),
                        ItemElementName = "0"
                    };
                    AuthParam2 parameter2 = new AuthParam2() { userreq = authItemParam2, token = Application.Current.Properties["TokenID"].ToString() };

                   var jsonParameter = JsonConvert.SerializeObject(parameter2);
                   var requestUrl = Constants.BaseAddressUrl + "/UserService.svc/GetUserDetails";

                    client.BaseAddress = new Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                   var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
                   var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Debug.WriteLine(json.ToString());
                    userDetails = JsonConvert.DeserializeObject<GetGuestUserDetailsRes>(json);
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
        private void startnewPage()
        {
           Application.Current.MainPage.Navigation.PushModalAsync(new editProfile(userDetails));
        }
    }
}
