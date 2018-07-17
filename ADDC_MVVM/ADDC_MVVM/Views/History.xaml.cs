using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
    public partial class History : TabbedPage
    {
        public History()
        {
            InitializeComponent();
            Children.Add(new billHistory());
            Children.Add(new paymentHistory());
        }
    }
}
