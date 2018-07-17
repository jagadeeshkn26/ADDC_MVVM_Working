using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ADDC_MVVM
{
	public partial class CDInsideHouse : ContentPage
	{
		public CDInsideHouse()
		{
			InitializeComponent();
		}

		async void OnTapMenu(object sender, System.EventArgs e)
		{
			await Navigation.PopModalAsync();

		}
	}
}
