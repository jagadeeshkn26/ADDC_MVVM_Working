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
    public class ChangePasswordViewModel : ViewModelBase
    {
        private string typePassword;

        private string reTypePassword;

        private string userName;

        public string typePasswordEntered
        {
            get { return typePassword; }
            set { SetProperty(ref typePassword, value); }
        }

        public string reTypePasswordEntered
        {
            get { return reTypePassword; }
            set { SetProperty(ref reTypePassword, value); }
        }

        public ICommand ChangePasswordCommand { get; set; }

        public ChangePasswordRes getChangePasswordResonse { get; set; }


        public ChangePasswordViewModel()
        {
            userName = Application.Current.Properties["UserID"].ToString();
            string token = Application.Current.Properties["TokenID"].ToString();
            ChangePasswordCommand = new Command(
               async () => await sendPasswordChangeReq(userName, token),
               () => !IsBusy);
        }

        async Task sendPasswordChangeReq(string userID, string tokenID)
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
                    Authentication authCredentials = new Authentication() { Pwd = reTypePasswordEntered, UserID = userID };
                    ChangePasswordReq parameter = new ChangePasswordReq() { token = tokenID, userreq = authCredentials };

                    string jsonParameter = JsonConvert.SerializeObject(parameter);
                    string requestUrl = Constants.BaseAddressUrl + "/LoginService.svc/ChangePassword";
                    client.BaseAddress = new System.Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

                    var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));

                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    getChangePasswordResonse = JsonConvert.DeserializeObject<ChangePasswordRes>(json);

                    Debug.WriteLine(json.ToString());

                    if (json != null)
                    {
                        //statusResponse.ResponseCode = getResendPinResonse.code;

                        Debug.WriteLine(getChangePasswordResonse.code);

                        if(getChangePasswordResonse.code == "100")
                        {
                            IsBusy = false;
                            await Application.Current.MainPage.DisplayAlert("Thank You", getChangePasswordResonse.description, "OK");

                        }
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
