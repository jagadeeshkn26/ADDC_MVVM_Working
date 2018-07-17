using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ADDC_MVVM
{
	public partial class ConservationTipsPage : ContentPage
	{
		public ConservationTipsPage()
		{
			InitializeComponent();
			if (Device.Idiom == TargetIdiom.Phone)
			{
				menuBg.HeightRequest = 60;
			}
			else {

				menuBg.HeightRequest = 80;
			}
			//EleTxt.TextColor = Color.Black;
			//WtrTxt.TextColor = Color.FromHex("#5e9622");
		}

		void Water_Tapped(object sender, System.EventArgs e)
		{
			//EleTxt.TextColor = Color.Black;
			//WtrTxt.TextColor = Color.FromHex("#5e9622");
		}
		void Elec_Tapped(object sender, System.EventArgs e)
		{
			//EleTxt.TextColor = Color.FromHex("#5e9622");
			//WtrTxt.TextColor = Color.Black;

		}

		async void InsideHouse_Tapped(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new CDInsideHouse() { BindingContext = new CDAirConditionerVM() } );
		}

		async void OutSideHouse_Tapped(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new CDOutsideHouse() { BindingContext = new CDAirConditionerVM() });
		}

		async void AtSchool_Tapped(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new CDAtSchool() { BindingContext = new CDAirConditionerVM() });
		}

		async void WaterSaver_Tapped(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new CDWaterSaver() { BindingContext = new CDAirConditionerVM() } );
		}

		async void AirCond_Tapped(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new CDAirConditioner(){ BindingContext = new CDAirConditionerVM() });
		}

		async void HowToSave_Tapped(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new CDLighting() { BindingContext = new CDAirConditionerVM() });
		}

		async void HomeApp_Tapped(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new CDHomeAppliance() { BindingContext = new CDAirConditionerVM() } );
		}

	}
}
