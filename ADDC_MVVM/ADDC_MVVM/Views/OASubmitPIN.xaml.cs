﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADDC_MVVM.Models;
using ADDC_MVVM.ViewModels;
using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
    public partial class OASubmitPIN : ContentPage
    {
        public OASubmitPIN()
        {
            InitializeComponent();
        }

        public OASubmitPINViewModel ViewModel { get { return (BindingContext as OASubmitPINViewModel); } }
    }
}
