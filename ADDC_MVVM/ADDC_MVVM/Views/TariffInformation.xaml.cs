using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
    public partial class TariffInformation : ContentPage
    {
        public TariffInformation()
        {
            InitializeComponent();
			if (Device.Idiom == TargetIdiom.Phone)
			{
				menuBg.HeightRequest = 60;
			}
			else
			{

				menuBg.HeightRequest = 80;
			}
			setFocus();

        }

		public void setFocus()
		{
			GreenUnitslbl.Focus();
		}

		protected override void OnPropertyChanged(string propertyName = null)
		{
			base.OnPropertyChanged(propertyName);
		}
		public bool IsUnmeterSelected { get; private set; }

		public string CUnits { get; private set; }

		string unmetered;

void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				CunitFld.IsVisible = false;
				CunitTxt.IsVisible = false;
				primisePic.IsEnabled = false;
				tarifPic.IsEnabled = false;
			}
			else
			{
				CunitFld.IsVisible = true;
				CunitTxt.IsVisible = true;
				primisePic.IsEnabled = true;
				tarifPic.IsEnabled = true;
			}
		}
	}
}
