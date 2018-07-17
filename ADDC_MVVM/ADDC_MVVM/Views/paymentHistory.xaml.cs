using ADDC_MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
    public partial class paymentHistory : ContentPage
    {
        private Dictionary<string, string> _AccountList { set; get; }
        public paymentHistory()
        {
            InitializeComponent();
            BindingContext = new paymentHistoryViewModel();

            _AccountList = new Dictionary<string, string>
           {
                { Application.Current.Properties["AccountID"].ToString(), "1" }
               
            };
            foreach (string frequencyName in _AccountList.Keys)
            {
                Accountname.Items.Add(frequencyName);
            }
            
        }
    }
}
