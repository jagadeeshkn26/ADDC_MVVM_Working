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
using Xamarin.Forms;
using System.Windows.Input;
using ADDC_MVVM.Views;
using ADDC_MVVM.Resx;

namespace ADDC_MVVM.ViewModels
{
    public class OASubmitPINViewModel : ViewModelBase
    {
        private StatusResponse statusResponse { get; set; }

        private string pinValue;

        private GetGuestUserDetailsRes getGuestUserDetailsResponse;

        public string personIDFromEid { get; set; }

        public string emailIDFromEid { get; set; }

        public string heading { get; set; }

        public string phoneNumberFromEid { get; set; }

        public ICommand resendPIN { get; set; }

        public ICommand validatesPIN { get; set; }

        public ResendPINRes getResendPinResonse { get; set; }

        public OASubmitPINViewModel()
        {

        }

        public OASubmitPINViewModel(GetGuestUserDetailsRes getGuestUserDetailsRes)
        {
            getGuestUserDetailsResponse = getGuestUserDetailsRes;
            getResendPinResonse = new ResendPINRes();
            personIDFromEid = getGuestUserDetailsResponse.Resident.Person.PersonID;
            emailIDFromEid = getGuestUserDetailsResponse.Resident.Person.EmailID;
            phoneNumberFromEid = getGuestUserDetailsResponse.Resident.Person.Phone[0].Number.ToString();
            statusResponse = new StatusResponse();
            //Text = "{i18n:Translate str_validate_pin_text1}"

            heading = AppResource.str_validate_pin_text1 + " " + phoneNumberFromEid + " " + AppResource.str_validate_pin_text2 + " " + emailIDFromEid;

            resendPIN = new Command(
               async () => await ResendPIN1(""),
               () => !IsBusy);

            validatesPIN = new Command(
                async () => await ValidatePIN("", ""),
                () => !IsBusy);
        }



        async Task ResendPIN1(String personID)
        {
            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;

                using (var client = new HttpClient(new NativeMessageHandler()))
                {
                    personID = personIDFromEid;
                    ResendPINReq parameter = new ResendPINReq() { PersonID = personID };
                    string jsonParameter = JsonConvert.SerializeObject(parameter);
                    string requestUrl = Constants.BaseAddressUrl + "/UserService.svc/RegeneratePinForUser";
                    client.BaseAddress = new System.Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

                    var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));

                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    getResendPinResonse = JsonConvert.DeserializeObject<ResendPINRes>(json);

                    Debug.WriteLine(json.ToString());

                    if (json != null)
                    {
                        statusResponse.ResponseCode = getResendPinResonse.code;

                        Debug.WriteLine(statusResponse.ResponseCode);

                        if (statusResponse.ResponseCode == "100")
                        {
                            IsBusy = false;
                            await Application.Current.MainPage.DisplayAlert("Thank You", getResendPinResonse.description, "OK");

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

        async Task ValidatePIN(String personID, String pin)
        {
            if (pinValue != null || pinValue.Equals("") || pinValue.Length < 4)
            {

                if (IsBusy)
                    return;

                Exception error = null;
                try
                {
                    IsBusy = true;

                    using (var client = new HttpClient(new NativeMessageHandler()))
                    {
                        personID = personIDFromEid;
                        pin = pinValue;
                        ValidatePINReq parameter = new ValidatePINReq() { PersonID = personID, PIN1 = pin };
                        string jsonParameter = JsonConvert.SerializeObject(parameter);
                        string requestUrl = Constants.BaseAddressUrl + "/UserService.svc/ValidatePinAndActiveuser";
                        client.BaseAddress = new System.Uri(Constants.BaseAddressUrl);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                        var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
                        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        var getValidatePinResonse = JsonConvert.DeserializeObject<ValidatePINRes>(json);

                        Debug.WriteLine(json.ToString());

                        if (json != null)
                        {
                            statusResponse.ResponseCode = getValidatePinResonse.code;
                            statusResponse.ResponseStatus = getValidatePinResonse.description;
                            //var resCode = validatePinStatusResponse.ResponseCode;
                            if (statusResponse.ResponseCode == "100")
                            {
                                //await Application.Current.MainPage.DisplayAlert("Thank u", statusResponse.ResponseStatus, "OK");
                                await App.Current.MainPage.Navigation.PushModalAsync(new OAAccountDetails() { BindingContext = new OAAccountDetailsViewModel(getGuestUserDetailsResponse) });
                                IsBusy = false;
                            }
                            else
                            {
                                IsBusy = false; //TODO Move to top
                                                //await Application.Current.MainPage.DisplayAlert("Thank u", statusResponse.ResponseStatus, "OK");
                                                //  await App.Current.MainPage.Navigation.PushAsync(new OASubmitPIN() { BindingContext = new OASubmitPINViewModel(getGuestUserDetailsRes) });
                                                //  await App.Current.MainPage.Navigation.PushAsync(new OAAccountDetails() { BindingContext = new OAAccountDetailsViewModel(getGuestUserDetailsResponse) });

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
                    await Application.Current.MainPage.DisplayAlert(AppResource.str_gps_title, error.Message, AppResource.btn_ok);


            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(AppResource.str_gps_title, AppResource.str_enter_pin, AppResource.btn_ok);
            }

        }
        public string pinEntered
        {
            get { return pinValue; }
            set { SetProperty(ref pinValue, value); }
        }
    }

}
