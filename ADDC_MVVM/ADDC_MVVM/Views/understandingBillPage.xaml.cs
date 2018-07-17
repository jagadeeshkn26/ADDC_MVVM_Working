using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADDC_MVVM.Resx;

using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
    public partial class understandingBillPage : ContentPage
    {
        public understandingBillPage()
        {
            InitializeComponent();
			if (Device.Idiom == TargetIdiom.Phone)
			{
				menuBg.HeightRequest = 60;
			}
			else {

				menuBg.HeightRequest = 80;
			}

		}

 async void OnTapMenu(object sender, System.EventArgs e)
		{
			await App.Current.MainPage.Navigation.PopModalAsync();
		}

        void OnTapGestureRecognizerElectricityBill(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new ElectricityBill());
        }

        void OnTapGestureRecognizerWaterBill(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new WaterBill());
        }
    }
}
