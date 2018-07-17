using ADDC_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using ADDC_MVVM.ViewModels;
using ADDC_MVVM.Models;

namespace ADDC_MVVM.Views
{
    public partial class billHistory : ContentPage
    {
        private Dictionary<string, string> _AccountList { set; get; }
        public billHistory()
        {
            InitializeComponent();
            BindingContext = new billHistoryViewModel();
            _AccountList = new Dictionary<string, string>
           {
                { Application.Current.Properties["AccountID"].ToString(), "1" }

            };

            foreach (string frequencyName in _AccountList.Keys)
            {
                Accountname.Items.Add(frequencyName);
            }
			if (Accountname.Items.Count > 0)
			{
				Accountname.SelectedIndex = 0;
			}
        }
    async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var temp = args.SelectedItem;
			var item1 = args.SelectedItem as BillInfo;
			if (item1 == null)
			{

			}
			await Navigation.PushModalAsync(new lastBillDetailsTabPage()
			{ BindingContext = new TBlastBillDetailsViewModel(item1) });
		}

	}
}
