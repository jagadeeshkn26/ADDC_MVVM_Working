 using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	using Android.App;
	using Android.Content;
	using Android.OS;
	using Android.Runtime;
	using Android.Views;
	using Android.Widget;
	using Android.Content.PM;

	namespace ADDC_MVVM.Droid
	{
		[Activity(Label = "ADDC_MVVM", MainLauncher = true, NoHistory = true, Theme = "@style/Theme.Splash",
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
		class SplashScreen : Activity
		{
			System.Timers.Timer timer = null;

			protected override void OnCreate(Bundle bundle)
			{
				base.OnCreate(bundle);
			SetContentView(Resource.Layout.SplashLyt);
				timer = new System.Timers.Timer();
				timer.Interval = 1500;
				timer.Elapsed += new System.Timers.ElapsedEventHandler(t_Elapsed);
				timer.Start();
				//Finish();
			}
			void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
			{
				timer.Stop();
				StartActivity(typeof(MainActivity));
				Finish();
			}
		}
	}