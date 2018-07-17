using ADDC_MVVM.Models;
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
using ADDC_MVVM.Views;
using System.Text.RegularExpressions;
using ADDC_MVVM.Resx;

namespace ADDC_MVVM.ViewModels
    
{
    public class EmiratesIdEntryViewModel : ViewModelBase
    {

        private string eidValue;
        public EmiratesIdEntry EmiratesIdEntryResList { get; set; }

        public ICommand SubmitEidCommand { get; set; }

        public ICommand CancelEidCommand { get; set; }

        // private string eID = "784196218594321";
        //private string eID = "784198107419289";
        const string eIDRegex = "^(784)?[0-9]{4}?[0-9]{7}?[0-9]{1}$";
        private string personID;
        public bool checkValidity { get; set; }

        private StatusResponse eIdStatusResponse { get; set; }
        public EmiratesIdEntryViewModel()
        {
            EmiratesIdEntryResList = new EmiratesIdEntry();
            eIdStatusResponse = new StatusResponse();

            CancelEidCommand = new Command(
                async () => await cancelPage(),
                () => !IsBusy);
            //Title = "Speakers";
            SubmitEidCommand = new Command(
                async () => await sendEmiratesId(),
                () => !IsBusy);
        }

        async Task cancelPage()
        {
             await App.Current.MainPage.Navigation.PushModalAsync(new ADDCPage());
           // Navigation.PopAsync();
        }


        private bool isValidEid(string eidValue)
        {
            if (eidValue.Length == 15)
            {
                return (Regex.IsMatch(eidValue, eIDRegex));
                //     Match match = Regex.Match(eidValue, @"^(784)?[0 - 9]{ 4}?[0-9]{7}?[0-9]{1}$",
                //RegexOptions.IgnoreCase);

                //     if (match.Success)
                //         return true;
                //     else
                //         return false;
            }
            else
            {
                return false;
            }

            //return Regex.IsMatch(value, @"^[a-zA-Z0-9]*$");
        }

        async Task sendEmiratesId()
        {
            if (eidValue != null)
            {

                if (isValidEid(eidValue))
                {     //Todo


                    if (IsBusy)
                        return;

                    Exception error = null;
                    try
                    {
                        IsBusy = true;

                        using (var client = new HttpClient(new NativeMessageHandler()))
                        {
                            ResUserPinReq parameter = new ResUserPinReq() { EmiratesID = eidValue, ActivationRequest = "" };
                            string jsonParameter = JsonConvert.SerializeObject(parameter);
                            string requestUrl = Constants.BaseAddressUrl + "/UserService.svc/CreateResidentialDraftUserWithPIN";

                            client.BaseAddress = new System.Uri(Constants.BaseAddressUrl);
                            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                            var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
                            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                            Debug.WriteLine(json.ToString());
                            //return json;

                            //grab json from server
                            // var json = await client.GetStringAsync("https://demo4404797.mockable.io/speakers");

                            // var json = "{\"ResidentialActivationResponse\":{\"PersonID\":4103014438,\"StatusResponse\":{\"Status\":false,\"Code\":\"100\",\"Description\":\"PIN already exists for Emirates ID or Account Number or TLN\",\"AuthResponce\":null}},\"CommercialActivationResponse\":null}";

                            //Deserialize json
                            EmiratesIdEntryResList = JsonConvert.DeserializeObject<EmiratesIdEntry>(json);
                            eIdStatusResponse.ResponseCode = EmiratesIdEntryResList.residentialActivationResponse.statusResp.ResponseCode;
                            eIdStatusResponse.ResponseStatus = EmiratesIdEntryResList.residentialActivationResponse.PersonID;
                            eIdStatusResponse.ResponseDescription = EmiratesIdEntryResList.residentialActivationResponse.statusResp.ResponseDescription;
                            personID = EmiratesIdEntryResList.residentialActivationResponse.PersonID;
                            if (eIdStatusResponse.ResponseCode == "100" || eIdStatusResponse.ResponseCode == "139")
                            {
                                IsBusy = false;
                                GetGuestUserDetails(personID, "0");

                            }
                            else if (eIdStatusResponse.ResponseCode == "121")
                            {
                                IsBusy = false;
                                GetPersonId(eidValue);

                            }

                            ////Load speakers into list
                            Debug.WriteLine(eIdStatusResponse);
                            Debug.WriteLine(eIdStatusResponse.ResponseCode);
                            Debug.WriteLine(eIdStatusResponse.ResponseStatus);
                            Debug.WriteLine(eIdStatusResponse.ResponseDescription);
                            Debug.WriteLine(EmiratesIdEntryResList.residentialActivationResponse.PersonID);
                            //EmiratesIdEntryResList.Clear();
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
                        await Application.Current.MainPage.DisplayAlert("Error!", error.Message, AppResource.btn_ok);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(AppResource.str_gps_title, AppResource.str_wrong_emirates_id, AppResource.btn_ok);
                }

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(AppResource.str_gps_title, AppResource.enter_eid, AppResource.btn_ok);
            }
        }

        async Task GetPersonId(string EmiritsID)
        {
            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;

                using (var client = new HttpClient(new NativeMessageHandler()))
                {
                    PersonFetchConfiguration personFetchConfiguration = new PersonFetchConfiguration()
                    {
                        IsAccountNumber = "false",
                        IsEmailID = "false",
                        IsEmiratesID = "true"
                                                                                                        ,
                        IsTradeLicenseNumber = "false",
                        IsUserID = "false"
                    };
                    GetPersonIdReq parameter = new GetPersonIdReq() { ID = EmiritsID, PersonFetchConfiguration = personFetchConfiguration };
                    string jsonParameter = JsonConvert.SerializeObject(parameter);
                    string requestUrl = Constants.BaseAddressUrl + "/UserService.svc/FetchPersonID";
                    client.BaseAddress = new System.Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                    var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    var getPersonRes = JsonConvert.DeserializeObject<GetPersonRes>(json);

                    Debug.WriteLine(json.ToString());

                    if (json != null)
                    {
                        personID = getPersonRes.PID;
                        IsBusy = false;
                        GetGuestUserDetails(personID, "0");
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


        async Task GetGuestUserDetails(string personID, string index)
        {
            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;

                using (var client = new HttpClient(new NativeMessageHandler()))
                {
                    PersonFetchConfiguration personFetchConfiguration = new PersonFetchConfiguration()
                    {
                        IsAccountNumber = "false",
                        IsEmailID = "false",
                        IsEmiratesID = "true"
                                                                                                        ,
                        IsTradeLicenseNumber = "false",
                        IsUserID = "false"
                    };
                    GetGuestUserDetailsReq parameter = new GetGuestUserDetailsReq() { Item = personID, ItemElementName = index };
                    string jsonParameter = JsonConvert.SerializeObject(parameter);
                    string requestUrl = Constants.BaseAddressUrl + "/UserService.svc/GetUserDetail";
                    client.BaseAddress = new System.Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                    var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var getGuestUserDetailsRes = JsonConvert.DeserializeObject<GetGuestUserDetailsRes>(json);
                    var personType = getGuestUserDetailsRes.Resident.Person.Phone[0].Type;
                    var personPhNum = getGuestUserDetailsRes.Resident.Person.Phone[0].Number;
                    var personPhName = getGuestUserDetailsRes.Resident.Person.Name[0].Name1;
                    var personPhEmailId = getGuestUserDetailsRes.Resident.Person.EmailID;
                    Debug.WriteLine(getGuestUserDetailsRes);

                    if (personType == 3)
                    {
                        if (personPhNum != null || personPhEmailId != null)
                        {
                            //App.Current.MainPage.Navigation.PushModalAsync(new OASubmitPIN(getGuestUserDetailsRes), false);
                            await App.Current.MainPage.Navigation.PushModalAsync(new OASubmitPIN() { BindingContext = new OASubmitPINViewModel(getGuestUserDetailsRes) });
                            // await Navigation.PushAsync<EmiratesIdEntryViewModel>();
                            // Navigation
                            // await Navigation.PushAsync(new SessionDetailPage() { BindingContext = new SessionDetailViewModel(item) });

                            //Gote to new screen

                            // await App.Current.MainPage.Navigation.PushModalAsync(new ForgotPasswordView() { BindingContext = new ForgotPasswordViewModel() }),

                            // () => !IsBusy);
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
        public string eid
        {
            get { return eidValue; }
            set { SetProperty(ref eidValue, value); }
        }
    }
}
