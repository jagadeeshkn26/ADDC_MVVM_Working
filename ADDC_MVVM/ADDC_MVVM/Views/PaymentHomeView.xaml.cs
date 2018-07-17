using ADDC_MVVM.Models;
using ADDC_MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
    public partial class PaymentHomeView : ContentPage
    {
        public PaymentHomeViewModel ViewModel { get { return (BindingContext as PaymentHomeViewModel); } }

        public PaymentHomeView()
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

		}
        
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var temp = args.SelectedItem;
            var item1 = args.SelectedItem as AccountDetailsRes;
            if (item1 == null)
            {

            }
          //  await Navigation.PushAsync(new AccountDetailsMainView(item1));
        }
        private void btnDeleteRowClicked(Object sender, EventArgs EventArgs)
        {

            var temp = ((Button)sender).Id;

            int index = ViewModel.myAccount.IndexOf((AccountDetailsRes)((Button)sender).CommandParameter);
            // phonelst[index].RowAction = "Delete";
            ViewModel.myAccount.Remove((AccountDetailsRes)((Button)sender).CommandParameter);
            //  resident.Person.Phone[index].RowAction = "Delete";

        }
        private async void txtChanged(Object sender, TextChangedEventArgs txtChangs)
        {
          await  ViewModel.checkeTotal();
           
           
        }
    }
}
