using ADDC_MVVM.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System;
using System.Threading.Tasks;
using ADDC_MVVM.Views;
using ADDC_MVVM.Resx;

namespace ADDC_MVVM.ViewModels
{
   public class PaymentHomeViewModel : ViewModelBase
    {
        private ObservableCollection<AccountDetailsRes> myFlterList;
        public ObservableCollection<AccountDetailsRes> myAccount { get; set; }
        public ICommand SubmitCommand { get; set; }
		public ICommand OnTapMenu { get; set; }
        private string _total;
        public string Total
        {
            get { return _total; }
            set { SetProperty(ref _total, value); }
        }
        

        public PaymentHomeViewModel()
        {

        }
        public PaymentHomeViewModel(ObservableCollection<AccountDetailsRes> myFlterList)
        {
            this.myFlterList = myFlterList;
            myAccount = new ObservableCollection<AccountDetailsRes>();
            myAccount = myFlterList;
            checkTotslAwait();
			OnTapMenu = new Command(
			   async () =>
				await App.Current.MainPage.Navigation.PopModalAsync(),
			() => !IsBusy);
            SubmitCommand = new Command(
                async () => await SubmitPayment(),
                () => !IsBusy);
        }

        private async void checkTotslAwait()
        {
            await checkeTotal();
        }

        public async Task checkeTotal()
        {
            Total = "";
            foreach (var item in myFlterList)
            {
                
                if ( Total !="")
                {
                    if (item.OutstandingBalance != "")
                    {
                        Total = (Convert.ToDecimal(Total) + Convert.ToDecimal(item.OutstandingBalance)).ToString();
                    }
                   
                }
                else
                {
                    if (item.OutstandingBalance != "")
                    {
                        Total = (Convert.ToDecimal(item.OutstandingBalance)).ToString();
                    }
                }
                Application.Current.Properties["Total"] = Total;
            }
        }
        private async Task SubmitPayment()
        {
			if (myFlterList.Count > 0)
			{
				if (Convert.ToDouble(myFlterList[0].OutstandingBalance) > 0)
				{
					string personID = Application.Current.Properties["PersonID"].ToString();
					await App.Current.MainPage.Navigation.PushModalAsync(new SelectPaymentMethod() { BindingContext = new SelectPaymentMethodViewModel(personID, myFlterList) });

				}
				else
				{
					await Application.Current.MainPage.DisplayAlert("Error!", AppResource.min_max_payment, "OK");
				}

			}
			else
			{
				await Application.Current.MainPage.DisplayAlert("Error!", AppResource.min_max_payment, "OK");
			}
            
        }
    }
}
