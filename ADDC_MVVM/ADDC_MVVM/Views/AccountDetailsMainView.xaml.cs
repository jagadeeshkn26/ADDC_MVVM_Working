using System;
using ADDC_MVVM.Models;
using ADDC_MVVM.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
    public partial class AccountDetailsMainView : TabbedPage
    {
       private AccountDetailsRes item;
        public  AccountDetailsMainView(AccountDetailsRes item1)
        {
            InitializeComponent();
            item = item1;
            Children.Add(new accountDetailsTabPage() { BindingContext = new TBaccountDetailsViewModel(item1) });
            Children.Add(new lastPaymentDetailsTabPage() { BindingContext = new TBlastPaymentDetailsViewModel(item1) });
           // Children.Add(new lastBillDetailsTabPage() { BindingContext = new TBlastBillDetailsViewModel(item1) });

            
        }

        async void EditCommand(object sender, EventArgs args)
        {
            if(item != null)
            {
                 Navigation.PushAsync(new EditAccountView() { BindingContext = new EditAccountViewModel(item) });
            }
           
        }
    }
}
