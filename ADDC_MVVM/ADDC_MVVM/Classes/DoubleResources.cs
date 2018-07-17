using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ADDC_MVVM
{
    public static class DoubleResources
    {
        public static readonly Thickness ButtonGroupPadding = new Thickness(0, Device.OnPlatform(25, 0, 0), 0, 0);
        public static readonly double SignUpButtonHeight = Device.OnPlatform(40, 40, 80);
		public static readonly double EnglishButtonHeight = Device.OnPlatform(30, 25, 80);
		public static readonly double FBButtonHeight = Device.OnPlatform(75, 60, 64);
    }
}
    