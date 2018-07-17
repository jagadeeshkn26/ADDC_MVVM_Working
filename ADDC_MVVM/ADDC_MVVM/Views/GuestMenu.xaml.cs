using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
    public partial class GuestMenu : ContentPage
    {
        public GuestMenu()
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

		protected override void OnPropertyChanged(string propertyName = null)
		{
			
			base.OnPropertyChanged(propertyName);
			if (MenuImg != null)
			{
				//MenuImg.Source = "";
				//MenuImg.Source = "menu_bg";
			}

		}
    }
}
