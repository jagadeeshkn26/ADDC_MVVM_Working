using System;
using System.Collections.Generic;
using ADDC_MVVM.Resx;
using Xamarin.Forms;

namespace ADDC_MVVM
{
	public partial class ConservationDetailsPage : ContentPage
	{
		string ConsPage;

		public ConservationDetailsPage()
		{
			
		}

		public ConservationDetailsPage(string ConsPage)
		{
			InitializeComponent();
			this.ConsPage = ConsPage;
			if (ConsPage == "InSide")
			{
				ConsHeader.Text = AppResource.str_insd_house;
				Inside.IsVisible = true;
				Outside.IsVisible = false;
				AtSchool.IsVisible = false;
				WaterSaver.IsVisible = false;
				AirCond.IsVisible = false;
				Lighting.IsVisible = false;
				Appliance.IsVisible = false;

			}

			else if (ConsPage == "Outside")
			{
				ConsHeader.Text = AppResource.str_osd_house;
				
				Inside.IsVisible = false;
				Outside.IsVisible = true;
				AtSchool.IsVisible = false;
				WaterSaver.IsVisible = false;
				AirCond.IsVisible = false;
				Lighting.IsVisible = false;
				Appliance.IsVisible = false;
			}
			else if (ConsPage == "AtSchool")
			{
				ConsHeader.Text = AppResource.str_at_school;
				Inside.IsVisible = false;
				Outside.IsVisible = false;
				AtSchool.IsVisible = true;
				WaterSaver.IsVisible = false;
				AirCond.IsVisible = false;
				Lighting.IsVisible = false;
				Appliance.IsVisible = false;
			}
			else if (ConsPage == "WaterSaver")
			{
				ConsHeader.Text = AppResource.str_water_saver;
				Inside.IsVisible = false;
				Outside.IsVisible = false;
				AtSchool.IsVisible = false;
				WaterSaver.IsVisible = true;
				AirCond.IsVisible = false;
				Lighting.IsVisible = false;
				Appliance.IsVisible = false;
			}
			else if (ConsPage == "AirCond")
			{
				ConsHeader.Text = AppResource.str_air_cond;
				Inside.IsVisible = false;
				Outside.IsVisible = false;
				AtSchool.IsVisible = false;
				WaterSaver.IsVisible = false;
				AirCond.IsVisible = true;
				Lighting.IsVisible = false;
				Appliance.IsVisible = false;
			}
			else if (ConsPage == "Lighting")
			{
				ConsHeader.Text = AppResource.str_save_light;
				Inside.IsVisible = false;
				Outside.IsVisible = false;
				AtSchool.IsVisible = false;
				WaterSaver.IsVisible = false;
				AirCond.IsVisible = false;
				Lighting.IsVisible = true;
				Appliance.IsVisible = false;
			}
			else if(ConsPage == "Appliance")
			{
				ConsHeader.Text = AppResource.str_appliances;
				Inside.IsVisible = false;
				Outside.IsVisible = false;
				AtSchool.IsVisible = false;
				WaterSaver.IsVisible = false;
				AirCond.IsVisible = false;
				Lighting.IsVisible = false;
				Appliance.IsVisible = true;
			}
		}

		async void OnTapMenu(object sender, System.EventArgs e)
		{
			await Navigation.PopModalAsync();

		}
	}
}
