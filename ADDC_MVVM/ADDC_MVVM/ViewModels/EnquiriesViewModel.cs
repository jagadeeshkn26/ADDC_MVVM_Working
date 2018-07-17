using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ADDC_MVVM.ViewModels;
using ADDC_MVVM.Views;
using Xamarin.Forms;

namespace ADDC_MVVM
{
    public class EnquiriesViewModel : ViewModelBase
    {
        public ICommand SendEnquiryCommand { get; set; }
        public ICommand SendSuggestionCommand { get; set; }
        public ICommand EmailUsCommand { get; set; }
        public ICommand CallusCommand { get; set; }
        public ICommand BranchLocatorCommand { get; set; }
        public ICommand FaqCommand { get; set; }


        public ICommand OnTapMenu { get; set; }

        public EnquiriesViewModel()
        {
            OnTapMenu = new Command(
               async () => await App.Current.MainPage.Navigation.PopModalAsync(),
               () => !IsBusy);

            CallusCommand = new Command(
                () =>  Device.OpenUri(new Uri("tel:" + 8002332)),

               () => !IsBusy);
            EmailUsCommand = new Command(
                () => Device.OpenUri(new Uri("mailto:")),
               () => !IsBusy);
            SendSuggestionCommand = new Command(
               async () => await App.Current.MainPage.Navigation.PushModalAsync(new CustomerEnquiry()
               { BindingContext = new CustomerEnquiryViewModel() }),

               () => !IsBusy);
            SendEnquiryCommand = new Command(
               async () => await App.Current.MainPage.Navigation.PushModalAsync(new CustomerSuggession()
               { BindingContext = new CustomerSuggessionViewModel() }),
               () => !IsBusy);

            BranchLocatorCommand = new Command(
                async () =>
                   await App.Current.MainPage.Navigation.PushModalAsync(new MapPage()),

               () => !IsBusy);

            FaqCommand = new Command(
                async () =>
				await OnTaponFaq(),

               () => !IsBusy);
        }
		private async Task OnTaponFaq()
		{
			String url = "";

				if (App.CultureCode.Equals("ar"))
				{
					 url = "https://www.addc.ae/ar-ae/residential/_layouts/15/addc/faq.aspx";

				}
				else
				{
					url = "https://www.addc.ae/en-us/residential/_layouts/15/addc/faq.aspx";

				}

			Device.OpenUri(new Uri(url));
		}
    }
}