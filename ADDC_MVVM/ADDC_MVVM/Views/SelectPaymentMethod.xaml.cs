using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ADDC_MVVM.Models;
using ADDC_MVVM.ViewModels;
using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
    public partial class SelectPaymentMethod : ContentPage
    {
		public ObservableCollection<GetSavedCardRes> myList { get; set; }
		public SelectPaymentMethodViewModel ViewModel { get { return (BindingContext as SelectPaymentMethodViewModel); } }
		public ICommand OnTapMenu { get; set; }
        public SelectPaymentMethod()
        {
            InitializeComponent();
        }

  //      async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		//{
		//	var temp = args.SelectedItem;
		//	var item1 = args.SelectedItem as GetSavedCardRes;
		//	if (item1 == null)
		//	{

		//	}
		//	//  await Navigation.PushAsync(new AccountDetailsMainView(item1));
		//}

		private void btnDeleteRowClicked(Object sender, System.EventArgs EventArgs)
		{

		//	var temp = ((Button)sender).Id;

			int index = ViewModel.getSavedCardRes.IndexOf((GetSavedCardRes)((Image)sender).BindingContext);
			// phonelst[index].RowAction = "Delete";
			ViewModel.getSavedCardRes.Remove((GetSavedCardRes)((Image)sender).BindingContext);
			//  resident.Person.Phone[index].RowAction = "Delete";

		}



		async void btnSelClicked(object sender, System.EventArgs arg)
		{

			myList = ViewModel.getSavedCardRes;
			// var temp = ((Button)sender).Id;
			int index = myList.IndexOf((GetSavedCardRes)((Image)sender).BindingContext);
			if (ViewModel.flterCardRes != null)
			{
				ViewModel.flterCardRes.Clear();
				if (!ViewModel.flterCardRes.Contains(myList[index]))
				{
					ViewModel.flterCardRes.Add(myList[index]);
					((Button)sender).BackgroundColor = Color.Blue;
				}
				else
				{
					ViewModel.flterCardRes.Remove(myList[index]);
					((Button)sender).BackgroundColor = Color.Silver;
				}
			}
			else
			{
				ViewModel.flterCardRes.Add(myList[index]);
			}


			// var item1 = arg as AccountDetailsRes;
			// phonelst[index].RowAction = "Delete";
			//  card.Remove((PhoneRq)((Button)sender).CommandParameter);
		}
    }
}
