using ADDC_MVVM.View;
using ADDC_MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ADDC_MVVM.ViewModels
{
    class GuestMenuViewModel : ViewModelBase
    {
        public ICommand OnTapAboutUs { get; set; }
        public ICommand OnTapLocateUs { get; set; }
        public ICommand OnTapUnderstandingBill { get; set; }
        public ICommand OnTapEnquiries { get; set; }
        public ICommand OnTapTariffInformation { get; set; }
        public ICommand OnTapConservationTips { get; set; }
        public ICommand OnTapMenu { get; set; }
		string _menuHeight;
		public string menuHeight
		{
			get { return _menuHeight; }
			set { SetProperty(ref _menuHeight, value); }
		}
        public GuestMenuViewModel()
        {
			if (Device.Idiom == TargetIdiom.Phone)
			{
				
				menuHeight = "60";
			
			}
			else
			{
				
				menuHeight = "80";

			}

			OnTapMenu = new Command(
           async () =>
				await App.Current.MainPage.Navigation.PopModalAsync(),
				 
           () => !IsBusy);

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
