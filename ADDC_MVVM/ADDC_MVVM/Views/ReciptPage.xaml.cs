using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ADDC_MVVM
{
	public partial class ReciptPage : ContentPage
	{
		string transactionID;

		public ReciptPage()
		{
			
		}

		public ReciptPage(string transactionID)
		{
			this.transactionID = transactionID;
			InitializeComponent();
			if (Device.Idiom == TargetIdiom.Phone)
			{
				menuBg.HeightRequest = 60;
			}
			else
			{

				menuBg.HeightRequest = 80;
			}

			AccountID.Text = Application.Current.Properties["AccountID"].ToString();
			Total.Text = Application.Current.Properties["Total"].ToString();
			TxnId.Text = transactionID;
			PaidDate.Text = DateTime.Now.ToString();

		}
	}
}
