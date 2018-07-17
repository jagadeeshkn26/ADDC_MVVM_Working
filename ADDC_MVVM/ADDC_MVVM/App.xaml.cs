using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ADDC_MVVM
{
    public partial class App : Application
    {
		public static int ScreenWidth;
		public static int ScreenHeight;
        public static string CultureCode
        {
            get; set;
        }
        public App()
        {
            CultureCode = "";
            if (Device.OS != TargetPlatform.WinPhone)
            {

                MainPage = new NavigationPage(new Views.ADDCPage());
                NavigationPage.SetHasNavigationBar(MainPage, false);
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
