using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace ADDC_MVVM.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
			// if you want to use a different Application Delegate class from "AppDelegate"
			// you can specify it here.
			var pixels = UIScreen.MainScreen.Bounds.Width;// Resources.DisplayMetrics.WidthPixels;
			var scale = UIScreen.MainScreen.Scale; //Resources.DisplayMetrics.Density;
			double dps = (double)((pixels * 1.5f) / scale);
			App.ScreenWidth = (int)dps;

			pixels = UIScreen.MainScreen.Bounds.Height;
			dps = (double)((pixels * 1.5f) / scale);
			App.ScreenHeight = (int)dps;
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
