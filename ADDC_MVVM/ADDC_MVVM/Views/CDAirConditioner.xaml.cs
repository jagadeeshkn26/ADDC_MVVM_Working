using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ADDC_MVVM
{
	public partial class CDAirConditioner : ContentPage
	{
		public CDAirConditioner()
		{
			InitializeComponent();
		}

		async void OnTapMenu(object sender, System.EventArgs e)
		{
			await Navigation.PopModalAsync();

		}
	}
}
