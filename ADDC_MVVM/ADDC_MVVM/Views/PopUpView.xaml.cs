using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ADDC_MVVM
{
	public partial class PopUpView : ContentPage
	{
		public PopUpView()
		{
			InitializeComponent();
			//pageContent.
		}

		private async void OnTapMenu(object sender, EventArgs args)
		{
			await Navigation.PopModalAsync();
			// Navigation.PushModalAsync(new ADDCPage());
		}
	}
}
