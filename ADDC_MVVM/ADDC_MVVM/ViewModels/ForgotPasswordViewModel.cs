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
   public class ForgotPasswordViewModel : ViewModelBase
    {
        public ICommand SubmitCommand { get; set; }


        private bool _isVis;
        public bool IsVis
        {
            get { return _isVis; }
            set { SetProperty(ref _isVis, value); }
        }
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        
        private string _secretQsnTxt;
        public string SecretQsnTxt
        {
            get { return _secretQsnTxt; }
            set { SetProperty(ref _secretQsnTxt, value); }
        }
        private string _answerText;
        public string AnswerText
        {
            get { return _answerText; }
            set { SetProperty(ref _answerText, value); }
        }
        public ForgotPasswordViewModel()
        {
            IsVis = false;
            //  LoadSelectedLanguage();
            //Title = "Speakers";
            SubmitCommand = new Command(
                async () => await ResetPwd(),
                () => !IsBusy);         
        }

        private async Task ResetPwd()
        {

            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                

                using (var client = new HttpClient(new NativeMessageHandler()))
                {
                    //Authentication step1
                    if(IsVis == false)
                    {
                        ForgotPwd parameter = new ForgotPwd() { Item = UserName, ItemElementName = "1" };
                        string jsonParameter = JsonConvert.SerializeObject(parameter);
                        string requestUrl = Constants.BaseAddressUrl + "/UserService.svc/GetUserDetail";

                        client.BaseAddress = new Uri(Constants.BaseAddressUrl);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
                        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                        Debug.WriteLine(json.ToString());
                        GetGuestUserDetailsRes authRes1 = JsonConvert.DeserializeObject<GetGuestUserDetailsRes>(json);
                        IsVis = true;
                        SecretQsnTxt = authRes1.Profile.SecretQuestion.QuestionEnglish;
                    }
                    else
                    {
                        Dictionary dict = new Dictionary() { Key = "UserID", Value = UserName };
                        List <Dictionary> dicList = new List<Dictionary>();//
                        dicList.Add(dict);
                        ForgotPwdQA QAparameter = new ForgotPwdQA() { NotificationType = 0, Template = 0, Dictionary = dicList };

                        string QAjsonParameter = JsonConvert.SerializeObject(QAparameter);
                        string QArequestUrl = Constants.BaseAddressUrl + "/UserService.svc/SendNotification";

                        client.BaseAddress = new Uri(Constants.BaseAddressUrl);
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                        var QAresponse = await client.PostAsync(QArequestUrl, new StringContent(QAjsonParameter, Encoding.UTF8, "application/json"));
                        var QAjson = await QAresponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        Debug.WriteLine(QAjson.ToString());
                        GetGuestUserDetailsRes authRes1 = JsonConvert.DeserializeObject<GetGuestUserDetailsRes>(QAjson);
                        IsVis = true;
                        await Application.Current.MainPage.DisplayAlert("Thank You", authRes1.AuthResponce.Description, "OK");
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
