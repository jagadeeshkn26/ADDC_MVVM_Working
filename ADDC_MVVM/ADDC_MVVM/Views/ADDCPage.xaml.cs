using ADDC_MVVM.ViewModels;
using System;
using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
	public partial class ADDCPage : ContentPage
	{
		public ADDCPage()
		{
            
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
			if (Device.Idiom == TargetIdiom.Phone)
			{
				menuBg.HeightRequest = 60;
			}
			else {
				
				menuBg.HeightRequest = 80;
			}

		}

        public void ChangeLng(object sender, EventArgs args)
        {


            var vSelectedValue = pkrLanguage.Text;
            if (vSelectedValue.Trim() == "للتوزيع")
            {
                DependencyService.Get<ILocalize>().ChangeLocale("ar");
                App.CultureCode = "ar";
			}
            else
            {
                DependencyService.Get<ILocalize>().SetLocale();
                App.CultureCode = string.Empty;
            }           
            var vUpdatedPage = new ADDCPage();
            Navigation.InsertPageBefore(vUpdatedPage, this);
           // NavigationPage.SetHasNavigationBar(vUpdatedPage, false);
            Navigation.PopAsync();
        }

async void OnTapMenu(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new GuestMenu());
		}

       
        void OnTapped(object sender, EventArgs args)
        {
          
           // this.Navigation.PopModalAsync();
        }

        async void ExistingUser(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new LoginView() { BindingContext = new LoginViewModel() });           
        }
        async void NewUser(object sender, EventArgs args)
        {
            //var vUpdatedPage = new OAEmiratesEntry();
            await Navigation.PushModalAsync(new OAEmiratesEntry() { BindingContext = new EmiratesIdEntryViewModel() });
        }
      
    }
}

