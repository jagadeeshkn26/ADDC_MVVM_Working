using ADDC_MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
    public partial class ChangePassword : ContentPage
    {
        public ChangePassword()
        {
            InitializeComponent();
        }
        public ChangePasswordViewModel changePass { get { return (BindingContext as ChangePasswordViewModel); } }
    }
}
