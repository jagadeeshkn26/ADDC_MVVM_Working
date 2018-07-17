using ADDC_MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
    public partial class CustomerEnquiry : ContentPage
    {
        public CustomerEnquiry()
        {
            InitializeComponent();
        }

        
void YesButtonClicked(object sender, System.EventArgs e)
		{
			YesImg.Source = "circle_1.png";
			NoImg.Source = "circle_2.png";
			DonoImg.Source = "circle_2.png";
			SelAcc.IsVisible = true;
		}

void NoButtonClicked(object sender, System.EventArgs e)
		{
			YesImg.Source = "circle_2.png";
			NoImg.Source = "circle_1.png";
			DonoImg.Source = "circle_2.png";
			SelAcc.IsVisible = false;
		}
void DonoButtonClicked(object sender, System.EventArgs e)
		{
			YesImg.Source = "circle_2.png";
			NoImg.Source = "circle_2.png";
			DonoImg.Source = "circle_1.png";
			SelAcc.IsVisible = false;
		}
	}
}
