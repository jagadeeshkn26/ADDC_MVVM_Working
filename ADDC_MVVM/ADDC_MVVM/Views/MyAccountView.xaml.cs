using ADDC_MVVM.Models;
using ADDC_MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
    public partial class MyAccountView : ContentPage
    {
        public ObservableCollection<AccountDetailsRes> myList { get; set; }
        
        public MyAccountViewModel ViewModel { get { return (BindingContext as MyAccountViewModel);} }

        public MyAccountView()
        {
            InitializeComponent();
            var test = SessionsListView.ItemTemplate;
			if (Device.Idiom == TargetIdiom.Phone)
			{
				menuBg.HeightRequest = 60;
			}
			else
			{

				menuBg.HeightRequest = 80;
			}
        }



		async void OnItemSelected(object sender, Xamarin.Forms.ItemTappedEventArgs args)
        {
            var temp = args.Item ;
            var item1 = args.Item as AccountDetailsRes;
			if (item1 == null)
			{

			}
			else
			{
				//SessionsListView = -1;

			}

            await Navigation.PushModalAsync(new accountDetailsTabPage(item1) );
		}

		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);

			//this.Width = width;
			//this.height = height;
			//if (Device.Idiom.ToString() != "Phone")
			//{
			//	if (width > height)
			//	{
			//		menu.HeightRequest = 165;
			//		//outerStack.Orientation = StackOrientation.Horizontal;
			//	}
			//	else {
			//		menu.HeightRequest = 150;

			//		//outerStack.Orientation = StackOrientation.Vertical;
			//	}
			//}
			//else
			//{
			//	if (width > height)
			//	{
			//		menu.HeightRequest = 165;
			//		//outerStack.Orientation = StackOrientation.Horizontal;
			//	}
			//	else {
			//		menu.HeightRequest = 80;

			//		//outerStack.Orientation = StackOrientation.Vertical;
			//	}
			//}
		}


		async void btnSelClicked(object sender, EventArgs arg)
        {
			
            myList = ViewModel.myAccount;
            // var temp = ((Button)sender).Id;
            int index = myList.IndexOf((AccountDetailsRes)((Image)sender).BindingContext);
            if (ViewModel.myFlterList != null)
            {
                if (!ViewModel.myFlterList.Contains(myList[index]))
                {
                    ViewModel.myFlterList.Add(myList[index]);
                    ((Image)sender).Source = "tick";
                }
                else
                {
                    ViewModel.myFlterList.Remove(myList[index]);
                    ((Image)sender).Source = "confirm_pay_deselect";
                }
            }
            else
            {
                ViewModel.myFlterList.Add(myList[index]);
            }
           
           
            // var item1 = arg as AccountDetailsRes;
            // phonelst[index].RowAction = "Delete";
            //  card.Remove((PhoneRq)((Button)sender).CommandParameter);
        }
    }
}
