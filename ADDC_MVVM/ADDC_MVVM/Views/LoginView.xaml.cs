using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            NavigationPage.SetTitleIcon(this, "icon.png");
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
