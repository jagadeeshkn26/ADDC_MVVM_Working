using ADDC_MVVM.Models;
using ADDC_MVVM.ViewModels;
using ADDC_MVVM.Views;
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
    class OAAccountDetailsViewModel : ViewModelBase
    {
        private GetGuestUserDetailsRes getGuestUserDetailsRes_;

        public ICommand NextCMD { get; set; }


        public string userName_; //entered

        public string password_; //entered

        public string answer_; //entered

        public string passwordQs_;

        public OAAccountDetailsViewModel()
        {

        }

        public OAAccountDetailsViewModel(GetGuestUserDetailsRes getGuestUserDetailsRes)
        {
            getGuestUserDetailsRes_ = getGuestUserDetailsRes;
            userName_ = getGuestUserDetailsRes.UserID.ToString();
            NextCMD = new Command(
               async () => await nextScreen(),
               () => !IsBusy);
        }
        async Task nextScreen()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new OAAccountDetailsOptions() { BindingContext = new OAAccountDetailsOptionsViewModel(getGuestUserDetailsRes_) });
            IsBusy = false;

        }
        public void CollectPageData(string userName_,
            string password_, string answer_, string passwordQs_)
        {
            userName_ = userName;
            password_ = password;
            answer_ = answer;
            passwordQs_ = passwordQs;
        }

        public string userName
        {
            get { return userName_; }
            set { SetProperty(ref userName_, value); }
        }
        public string password
        {
            get { return password_; }
            set { SetProperty(ref password_, value); }
        }
        public string answer
        {
            get { return answer_; }
            set { SetProperty(ref answer_, value); }
        }
        public string passwordQs
        {
            get { return passwordQs_; }
            set { SetProperty(ref passwordQs_, value); }
        }

    }
}

