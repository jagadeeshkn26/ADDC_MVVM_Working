using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADDC_MVVM.Models;
using System.Windows.Input;
using ADDC_MVVM.Views;
using Xamarin.Forms;
using ADDC_MVVM.View;

namespace ADDC_MVVM.ViewModels
{
   public class MenuPageViewModel : ViewModelBase
    {
        private MyAccountDetails authRes4;
        public ICommand OnMyAccount { get; set; }
		public ICommand OnMyProfile { get; set; }
		public ICommand OnHistory { get; set; }
		public ICommand OnNotification { get; set; }
		public ICommand OnTapAboutUs { get; set; }
		public ICommand OnTapLocateUs { get; set; }
		public ICommand OnTapUnderstandingBill { get; set; }
		public ICommand OnTapEnquiries { get; set; }
		public ICommand OnTapTariffInformation { get; set; }
		public ICommand OnTapConservationTips { get; set; }
       string _menuHeight;
		public string menuHeight
		{
			get { return _menuHeight; }
			set { SetProperty(ref _menuHeight, value); }
		}
        public MenuPageViewModel(MyAccountDetails authRes4)
        {
            this.authRes4 = authRes4;
            OnMyAccount = new Command(
                async () =>
                await App.Current.MainPage.Navigation.PushModalAsync(new MyAccountView() { BindingContext = new MyAccountViewModel() }),
				//await App.Current.MainPage.Navigation.PopModalAsync(),
            () => !IsBusy);
		 OnMyProfile = new Command(
                async () =>
                await App.Current.MainPage.Navigation.PushModalAsync(new myProfile() { BindingContext = new myProfileViewModel(authRes4) }),
            () => !IsBusy);
		 OnHistory = new Command(
                async () =>
				await App.Current.MainPage.Navigation.PushModalAsync(new billHistory()),

            () => !IsBusy);
		
			 OnNotification = new Command(
			   async () =>
			   await App.Current.MainPage.Navigation.PushModalAsync(new History()),

		   () => !IsBusy);

			if (Device.Idiom == TargetIdiom.Phone)
			{

				menuHeight = "60";

			}
			else
			{

				menuHeight = "80";

			}

			//OnTapMenu = new Command(
		 //  async () =>
			//	await App.Current.MainPage.Navigation.PopModalAsync(),

		 //  () => !IsBusy);

			OnTapAboutUs = new Command(
		   async () =>
				await App.Current.MainPage.Navigation.PushModalAsync(new AboutUs() { BindingContext = new AboutUsViewModel() }),

	   () => !IsBusy);

			OnTapLocateUs = new Command(
				 async () =>
				   await LocateUs(),

			 () => !IsBusy);



			OnTapUnderstandingBill = new Command(
			   async () =>
				await App.Current.MainPage.Navigation.PushModalAsync(new understandingBillPage()),

		   () => !IsBusy);

			OnTapEnquiries = new Command(
			   async () =>
			   await App.Current.MainPage.Navigation.PushModalAsync(new Enquiries() { BindingContext = new EnquiriesViewModel() }),

		   () => !IsBusy);

			OnTapTariffInformation = new Command(
			   async () =>
			   await App.Current.MainPage.Navigation.PushModalAsync(new TariffInformation() { BindingContext = new TariffInformationViewModel() }),

		   () => !IsBusy);

			OnTapConservationTips = new Command(
			   async () =>
				await App.Current.MainPage.Navigation.PushModalAsync(new ConservationTipsPage() { BindingContext = new ConservationTipsViewModel() }),
		   () => !IsBusy);
		}
		async Task LocateUs()
		{
			if (IsBusy)
				return;
			IsBusy = true;
			await App.Current.MainPage.Navigation.PushModalAsync(new MapPage() { BindingContext = new MapViewModel() });
			IsBusy = false;
		}
    }
}
