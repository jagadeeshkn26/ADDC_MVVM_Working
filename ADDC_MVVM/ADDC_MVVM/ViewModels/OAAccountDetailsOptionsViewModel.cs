using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADDC_MVVM.Models;
using ModernHttpClient;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Windows.Input;
using Xamarin.Forms;


namespace ADDC_MVVM.ViewModels
{
    class OAAccountDetailsOptionsViewModel : ViewModelBase
    {
        private GetGuestUserDetailsRes getGuestUserDetailsRes_;

        // private Userdetails userdetails_;
        public ICommand SaveCMD { get; set; }
        public string email { get; set; } //entered

        public string userName_; //entered

        public string password_; //entered

        //public string password_question; // entered

        public string answer_; //entered

        // public string contact;//entered

        public string commPref_;

        public string personID_;



        //public string eID;//fetch from previous save

        public string phoneNumber { get; set; }

        public OASetUserDetailsRes createUserRes { get; set; }

          public OAAccountDetailsOptionsViewModel()
        {

        }

        public OAAccountDetailsOptionsViewModel(GetGuestUserDetailsRes getGuestUserDetailsRes)
        {
            getGuestUserDetailsRes_ = getGuestUserDetailsRes;
            SaveCMD = new Command(
              async () => await createUser(false),                  //Todo TRUE for Migrated Users.
              () => !IsBusy);
            phoneNumber = getGuestUserDetailsRes_.Resident.Person.Phone[0].Number.ToString();

            email = getGuestUserDetailsRes_.Resident.Person.EmailID;

            personID_ = getGuestUserDetailsRes_.Profile.PersonID;



        }

        async Task createUser(Boolean isMigrated)
        {
            string requestUrl = "";

            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;

                using (var client = new HttpClient(new NativeMessageHandler()))
                {

                    CreateUserReq parameter = new CreateUserReq() { Pwd = password_, UserID = userName_, EmailID = email };
                    string jsonParameter = JsonConvert.SerializeObject(parameter);

                    if (isMigrated)
                        requestUrl = Constants.BaseAddressUrl + "/LoginService.svc/CreateMigratedUser";
                    else
                        requestUrl = Constants.BaseAddressUrl + "/LoginService.svc/CreateUser";



                    client.BaseAddress = new System.Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

                    var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));

                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    createUserRes = JsonConvert.DeserializeObject<OASetUserDetailsRes>(json);

                    Debug.WriteLine(json.ToString());

                    if (json != null)
                    {
                        //string tokenID = createUserRes.tokenID;

                        if (createUserRes.code == "100")
                        {
                            IsBusy = false;
                            await Application.Current.MainPage.DisplayAlert("Thank You", createUserRes.description, "OK");
                            // await setUserDetails(tokenID);

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
        async Task setUserDetails(string tokenID)
        {
            string tokenID_createUser = tokenID;

            string requestUrl = "";

            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;

                using (var client = new HttpClient(new NativeMessageHandler()))
                {

                    // BillRoute billRoute = new BillRoute() { BillPreference = 0 };

                    //  Person person = new Person() { EmailID = email, LanguagePreference = 0, BillRoute = billRoute };

                    //  Resident resident = new Resident() { Person = person };

                    //   MasterDataProp masterData = new MasterDataProp() { ID = "609340005" };

                    //   SecretQuestion secretQuestion = new SecretQuestion() { QuestionArabic = "What is your favorite color", QuestionEnglish = "What is your favorite color", _MasterDataProp = masterData };

                    //    Profile profile = new Profile() { SecretQuestion = secretQuestion, SecretAnswer = answer, PersonID = personID_ };

                    // userdetails userdetails_ = new userdetails() { isMigrated = "false", PersonID = personID_, profile = profile, resident = resident, UserID = userName };

                    //setUserDetails parameter = new setUserDetails() { token = tokenID, userdetails_ = userdetails_, PersonID = personID_ };

                    // ===================================================================================================

                    //Profile profile = new Profile() { SecretQuestion = secretQuestion, SecretAnswer = answer, PersonID = personID_ };

                    MasterDataPropRq masterData = new MasterDataPropRq() { ID = "609340005" };

                    SecretQuestionRq secretQuestion = new SecretQuestionRq() { QuestionArabic = "What is your favorite color", QuestionEnglish = "What is your favorite color", _MasterDataProp = masterData };

                    ProfileRq profile = new ProfileRq() { SecretQuestion = secretQuestion, SecretAnswer = answer_, PersonID = personID_ };

                    Address addr = new Address() { Country = "", AreaCode = "", Address1 = "", Address2 = "", Address3 = "", Area = "", City = "", POBox = "", Emirate = 0 };

                    BillRoute billRoute = new BillRoute() { BillPreference = 0 };

                    PersonRq person = new PersonRq() { EmailID = email, LanguagePreference = 0, BillRoute = billRoute, Address = addr };

                    ResidentRq resident = new ResidentRq() { Person = person };

                    Userdetails userdetailsRq = new Userdetails() { PersonID = personID_, UserID = getGuestUserDetailsRes_.UserID, Profile = profile, Resident = resident, isMigrated = getGuestUserDetailsRes_.isMigrated };

                    EditProfileReq parameter2 = new EditProfileReq() { token = tokenID, userdetails = userdetailsRq };

                    string jsonParameter = JsonConvert.SerializeObject("parameter2");



                    requestUrl = Constants.BaseAddressUrl + "/UserService.svc/SetUserDetails";

                    client.BaseAddress = new System.Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var request = new HttpRequestMessage(HttpMethod.Post, requestUrl);

                    var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));

                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    createUserRes = JsonConvert.DeserializeObject<OASetUserDetailsRes>(json);

                    Debug.WriteLine(json.ToString());

                    if (json != null)
                    {
                        // string tokenID = createUserRes.tokenID;

                        if (createUserRes.code == "100")
                        {
                            IsBusy = false;
                            await Application.Current.MainPage.DisplayAlert("Thank You", createUserRes.description, "OK");

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
        async Task activatePortalUser(string personId, string tokenID)
        {// isMigrated)
            {
                string requestUrl = "";

                if (IsBusy)
                    return;

                /* Exception error = null;
                 try
                 {
                     IsBusy = true;

                     using (var client = new HttpClient(new NativeMessageHandler()))
                     {

                         CreateUserReq parameter = new CreateUserReq() { Pwd = password_, UserID = userName_, EmailID = email };
                         string jsonParameter = JsonConvert.SerializeObject(parameter);

                         if (isMigrated)
                             requestUrl = Constants.BaseAddressUrl + "/LoginService.svc/CreateMigratedUser";
                         else
                             requestUrl = Constants.BaseAddressUrl + "/LoginService.svc/CreateUser";



                         client.BaseAddress = new System.Uri(Constants.BaseAddressUrl);
                         client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                         var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

                         var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));

                         var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                         createUserRes = JsonConvert.DeserializeObject<OASetUserDetailsRes>(json);

                         Debug.WriteLine(json.ToString());

                         if (json != null)
                         {
                             //string tokenID = createUserRes.tokenID;

                             if (createUserRes.code == "100")
                             {
                                 IsBusy = false;
                                 await Application.Current.MainPage.DisplayAlert("Thank You", createUserRes.description, "OK");
                                 // await setUserDetails(tokenID);

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
                     await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK"); */

            }
        }
    }
}
