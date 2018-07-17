using ADDC_MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using ADDC_MVVM.Models;

namespace ADDC_MVVM.Views
{
    public partial class accountDetailsTabPage : ContentPage
    {
		AccountDetailsRes item1;

		public accountDetailsTabPage()
        {
            
        }

		public accountDetailsTabPage(AccountDetailsRes item1)
		{
			this.item1 = item1;
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
			Account_Details.IsVisible = true;
			Last_Bill.IsVisible = false;
			Last_Pay.IsVisible = false;
			if (Device.Idiom == TargetIdiom.Phone)
			{
				menuBg.HeightRequest = 60;
			}
			else
			{

				menuBg.HeightRequest = 80;
			}
		}

		//  public TBaccountDetailsViewModel ViewModel { get { return (BindingContext as TBaccountDetailsViewModel); } }

		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);

			//this.Width = width;
			//this.height = height;
		
		}

		protected override void OnAppearing()
		{
			BindingContext = new TBaccountDetailsViewModel(item1);
			//MyAccountViewModel(authRes41);
			InitializeComponent();
			base.OnAppearing();
			if (Device.Idiom == TargetIdiom.Phone)
			{
				menuBg.HeightRequest = 60;
			}
			else
			{

				menuBg.HeightRequest = 80;
			}
		}
	}

}
