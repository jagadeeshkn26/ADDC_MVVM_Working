using ADDC_MVVM.ViewModels;
using System;
using Xamarin.Forms;
using ADDC_MVVM.Models;

namespace ADDC_MVVM.Views
{
    public partial class OAGeneratePin : ContentPage
    {
        public GetGuestUserDetailsRes getGuestUserDetailsRes { get; set; }

        public OAGeneratePin()
        {
            InitializeComponent();
           
        }
        public OAGeneratePin(GetGuestUserDetailsRes getGuestUserDetailsRes)
        {

            this.getGuestUserDetailsRes = getGuestUserDetailsRes;
            InitializeComponent();      
            
        }
       
        public OAGeneratePinViewModel ViewModel
        {
            get
            {
                return (BindingContext as OAGeneratePinViewModel);
            }
        }

        private void OnTextChanged(object sender,TextChangedEventArgs e)
        { 
            

           
        }

        private void OnSubmitClicked(object sender, EventArgs e)
        {
            //Navigation.PushModalAsync(new NavigationPage(new accountDetails()));
        }
    }
}
