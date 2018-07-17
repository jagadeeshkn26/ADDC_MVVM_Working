using ADDC_MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
    public partial class EditAccountView : ContentPage
    {
        public EditAccountView()
        {
            InitializeComponent();
            addrview.IsVisible = false;
            PoBoxview.IsVisible = false;
            if (Application.Current.Properties.ContainsKey("BillPreference"))
            {
                int id = Int32.Parse(Application.Current.Properties["BillPreference"].ToString());
                pkrBill.SelectedIndex = id;
                // do something with id
            }
           // int bilId = Int(Application.Current.Properties["BillPreference"]) ;
           
                pkrAddr.SelectedIndex = 4;
        }
        

        public EditAccountViewModel ViewModel { get { return (BindingContext as EditAccountViewModel); } }
        
        public void OnPrefPickerChanged(object sender, EventArgs args)
        {
            var selVal = pkrBill.Items[pkrBill.SelectedIndex];
            var selVali = pkrBill.SelectedIndex;
            if(selVali != 0 )
            {
                addrview.IsVisible = true;
                PoBoxview.IsVisible = true;
                Application.Current.Properties["BillPreference"] = pkrBill.SelectedIndex;
            }
            else
            {
                addrview.IsVisible = false;
                PoBoxview.IsVisible = false;
                Application.Current.Properties["BillPreference"] = pkrBill.SelectedIndex;
            }
            //if(sender)
        }
        public void OnAddrPickerChanged(object sender, EventArgs args)
        {
           // Application.Current.Properties["AddVal"] = pkrAddr.SelectedIndex;
            var selVal = pkrAddr.Items[pkrAddr.SelectedIndex];
            Application.Current.Properties["AddVal"] = selVal;
			Application.Current.Properties["IndexVal"] = pkrAddr.SelectedIndex;

		}
    }
}
