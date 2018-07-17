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

namespace ADDC_MVVM.ViewModels
{

    public class CustomerEnqViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; set; }
        public ICommand LoginCommandd { get; set; }


        private SystemElement EnquiryType;
        private List<SystemElement> SEList;

        public class SystemElement
        {
            public string SystemElementID { get; set; }
            public string SystemElementName { get; set; }
        }
        public ObservableCollection<SystemElement> SystemElementList { get; set; }
        public int SESelectedValue { get; set; }



        private string email;
        private string msg;

        public string emailForEnquiry
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }

        public string msgForEnquiry
        {
            get { return msg; }
            set { SetProperty(ref msg, value); }
        }
        // public ICommand SubmitEnquiry { get; set; }

        // public ICommand selectedIndexar { get; set; }
        // public BindablePicker selectedIndex { get; set; }
        // selectedIndex.SelectedIndexChanged selectedIndexer { get; set; }
        public CustomerEnqViewModel()
        {

            SEList = new List<SystemElement>();
            EnquiryType = new SystemElement();
            LoginCommand = new Command(
              async () => await sendEnquiry(),
              () => IsBusy);

            SystemElementList = new ObservableCollection<SystemElement>();

            GetEnquirytypesAwait();
            emailForEnquiry = Application.Current.Properties["EmailID"].ToString();



        }

        private async void GetEnquirytypesAwait()
        {
            await GetEnquirytypes();
        }

        private async Task GetEnquirytypes()
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
                    GetEnquiryTypesReq parameter = new GetEnquiryTypesReq() { AuthenticationToken = "AuthenticationToken_0" };

                    string jsonParameter = JsonConvert.SerializeObject(parameter);
                    string requestUrl = Constants.BaseAddressUrl + "/MasterService.svc/GetEnquiryTypes";
                    client.BaseAddress = new System.Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

                    var response = await client.GetAsync(requestUrl);// new StringContent(jsonParameter, Encoding.UTF8, "application/json"));

                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    var EnquiryTypesRes = JsonConvert.DeserializeObject<List<GetEnquiryTypesRes>>(json);

                    foreach (var enqTyp in EnquiryTypesRes)
                    {
                        EnquiryType = new SystemElement();
                        EnquiryType.SystemElementID = enqTyp.MasterDataEnqTpy.ID;
                        EnquiryType.SystemElementName = enqTyp.EnquiryTypeEnglish;

                        SEList.Add(EnquiryType);
                        SystemElementList.Add(EnquiryType);
                        SESelectedValue = 1;
                        EnquiryType = null;
                    }
                    Debug.WriteLine(json.ToString());

                    if (json != null)
                    {
                        //statusResponse.ResponseCode = getResendPinResonse.code;

                        Debug.WriteLine(json.ToString());


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

        async Task sendEnquiry()
        {
            if (IsBusy)
                return;

            Exception error = null;
            try
            {
              //  IsBusy = true;

                using (var client = new HttpClient(new NativeMessageHandler()))
                {
                    string token = Application.Current.Properties["TokenID"].ToString();
                    string perosnID = Application.Current.Properties["PersonID"].ToString();
                    string User = Application.Current.Properties["UserID"].ToString();
                    string AccountNum = Application.Current.Properties["AccountID"].ToString();
                    // string User = Application.Current.Properties["UserID"].ToString();
                    //reTypePasswordEntered,userName
                    EnquiryType enquiryType = new EnquiryType() { Code = "609340004" };
                    EnquirySubmitReq parameter = new EnquirySubmitReq()
                    {
                        Description = msgForEnquiry,
                        Name = User,
                        RelatedToPremise = "0",
                        EmailID = emailForEnquiry,
                        AccountNumber = AccountNum,
                        PersonID = perosnID,
                        EnquiryType = enquiryType,
                        AuthenticationToken = "AuthenticationToken_0"
                    };

                    string jsonParameter = JsonConvert.SerializeObject(parameter);
                    string requestUrl = Constants.BaseAddressUrl + "/UserService.svc/SubmitEnquiry";
                    client.BaseAddress = new System.Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

                    var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));

                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    var getChangePasswordResonse = JsonConvert.DeserializeObject<EnquirySubmitRes>(json);

                    Debug.WriteLine(json.ToString());

                    if (json != null)
                    {
                        //statusResponse.ResponseCode = getResendPinResonse.code;

                        Debug.WriteLine(getChangePasswordResonse);
                        await Application.Current.MainPage.DisplayAlert("Success!", json, "OK");

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
             //   IsBusy = false;
            }

            if (error != null)
                await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");
        }

        public string strSystemElement
        {
            get { return "System Element"; }
        }
    }
}
