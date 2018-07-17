using ADDC_MVVM.Views;
using System;
using Xamarin.Forms;

namespace ADDC_MVVM.View
{
    public partial class AboutUs : ContentPage
    {
        public AboutUs()
        {
            InitializeComponent();
            if (Device.OS == TargetPlatform.iOS )
            {
                //TabEvent.VerticalOptions = LayoutOptions.EndAndExpand;//.End;// LayoutAlignment.End;
                    
             }
            else
                if (Device.OS == TargetPlatform.Android)
            {
               // TabEvent.VerticalOptions = LayoutOptions.StartAndExpand;//.End;// LayoutAlignment.End;

            }

            if(App.CultureCode == "")
            {
               TxtDetails.XAlign = TextAlignment.Start;
            }
            else
            {
                TxtDetails.XAlign = TextAlignment.End;
            }

        }

        private async void OnTapMenu(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
           // Navigation.PushModalAsync(new ADDCPage());
        }
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
        private void OnTapOverview(object sender, EventArgs args)
        {
			TxtDetails.IsVisible = true;
			ValueTxt.IsVisible = false;
            TxtDetails.Text = ADDC_MVVM.Resx.AppResource.TxtOverview;
            // Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
        private void OnTapMission(object sender, EventArgs args)
        {
			TxtDetails.IsVisible = true;
			ValueTxt.IsVisible = false;
            TxtDetails.Text = ADDC_MVVM.Resx.AppResource.TxtMission;
            // Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
        private void OnTapVision(object sender, EventArgs args)
        {
			TxtDetails.IsVisible = true;
			ValueTxt.IsVisible = false;
            TxtDetails.Text = Resx.AppResource.TxtVision;
            // Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
        private void OnTapValues(object sender, EventArgs args)
        {
			TxtDetails.IsVisible = false;
			ValueTxt.IsVisible = true;
            // Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }

        private void OnTapLocateUs(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new ADDCPage());
        }

        private void OnTapUnderstandingBill(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new ADDCPage());
        }

        private void OnTapEnquiries(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new ADDCPage());
        }

        private void OnTapTariffInformation(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new ADDCPage());
        }

        private void OnTapConservationTips(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new ADDCPage());
        }
    }
}
