using System;
using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            if (Device.OS == TargetPlatform.iOS)
            {
                //TabEvent.VerticalOptions = LayoutOptions.EndAndExpand;//.End;// LayoutAlignment.End;

            }
            else
                if (Device.OS == TargetPlatform.Android)
            {
                // TabEvent.VerticalOptions = LayoutOptions.StartAndExpand;//.End;// LayoutAlignment.End;

            }

            //if (App.CultureCode == "")
            //{
            //    Header.HorizontalOptions = LayoutOptions.End;
            //}
            //else
            //{
            //    Header.HorizontalOptions = LayoutOptions.EndAndExpand;
            //}

        }
        protected override bool OnBackButtonPressed()
        {
			return true;
          //  return base.OnBackButtonPressed();
        }
        private async void OnTapMenu(object sender, EventArgs args)
        {
          //  await Navigation.PopModalAsync();
            // Navigation.PushModalAsync(new ADDCPage());
        }


    }
}
