using ADDC_MVVM.Models;
using ADDC_MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using System.Windows.Input;

namespace ADDC_MVVM.Views
{
    public partial class SavedCardsView : ContentPage
    {
        public ObservableCollection<GetSavedCardRes> myList { get; set; }
        public SavedCardsViewModel ViewModel { get { return (BindingContext as SavedCardsViewModel); } }
		public ICommand OnTapMenu { get; set; }
        public SavedCardsView()
        {
            InitializeComponent();
			 OnTapMenu = new Command(
			 async () => await App.Current.MainPage.Navigation.PopModalAsync(),
			 () => !IsBusy);

		}

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var temp = args.SelectedItem;
            var item1 = args.SelectedItem as GetSavedCardRes;
            if (item1 == null)
            {

            }
            //  await Navigation.PushAsync(new AccountDetailsMainView(item1));
        }

        private void btnDeleteRowClicked(Object sender, EventArgs EventArgs)
        {

            var temp = ((Button)sender).Id;

            int index = ViewModel.getSavedCardRes.IndexOf((GetSavedCardRes)((Button)sender).CommandParameter);
            // phonelst[index].RowAction = "Delete";
            ViewModel.getSavedCardRes.Remove((GetSavedCardRes)((Button)sender).CommandParameter);
            //  resident.Person.Phone[index].RowAction = "Delete";

        }
        async void btnSelClicked(object sender, EventArgs arg)
        {

            myList = ViewModel.getSavedCardRes;
            // var temp = ((Button)sender).Id;
            int index = myList.IndexOf((GetSavedCardRes)((Button)sender).CommandParameter);
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
