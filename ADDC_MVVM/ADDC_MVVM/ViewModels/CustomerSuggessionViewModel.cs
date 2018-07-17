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
    class CustomerSuggessionViewModel : ViewModelBase
    {
        private string email;
        private string msg;
        private string username;
		public ICommand OnTapMenu { get; set; }

		public string userNameForSuggs
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        public string emailForSuggs
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        public string msgForSuggs
        {
            get { return msg; }
            set { SetProperty(ref msg, value); }
        }
        public ICommand SubmitSuggession { get; set; }

        public CustomerSuggessionViewModel(string tokenID) {
           
        }
        public CustomerSuggessionViewModel() 
		{
			string tokenID = Application.Current.Properties["TokenID"].ToString();
			OnTapMenu = new Command(
			   async () => await App.Current.MainPage.Navigation.PopModalAsync(),
			   () => !IsBusy);

			emailForSuggs = Application.Current.Properties["EmailID"].ToString();
			SubmitSuggession = new Command(
            async () => await sendCustomerSuggessionReq(tokenID, userNameForSuggs, emailForSuggs, msgForSuggs),
            () => !IsBusy);
        }
        async Task sendCustomerSuggessionReq(string tokenID, string userNameForSuggs, string emailForSuggs, string msgForSuggs)
        {

            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;

                using (var client = new HttpClient(new NativeMessageHandler()))
                {
                    //reTypePasswordEntered,userName
                    CustomerSuggessionReq parameter = new CustomerSuggessionReq() {  Name= userNameForSuggs, EmailID= emailForSuggs, Description= msgForSuggs };

                    string jsonParameter = JsonConvert.SerializeObject(parameter);
                    string requestUrl = Constants.BaseAddressUrl + "/UserService.svc/SubmitSuggestion";
                    client.BaseAddress = new System.Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

                    var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));

                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                   // getChangePasswordResonse = JsonConvert.DeserializeObject<ChangePasswordRes>(json);

                    Debug.WriteLine(json.ToString());
                    await Application.Current.MainPage.DisplayAlert("Success!", json, "OK");


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
