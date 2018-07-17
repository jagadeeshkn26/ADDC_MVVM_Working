using System;
using System.Collections.Generic;
using ADDC_MVVM.Resx;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace ADDC_MVVM
{
	public partial class UserAnimationPage : PopupPage
	{private string fontNrStl = "";
		private string fontBldStl = "";
		private double fontsize = 15;
		private PopupPage popupLayout = new PopupPage();
		private double screenHeight = 0;
		private double ScreenWidth = 0;
		StackLayout popup1;

		public UserAnimationPage()
		{
			
		//	Content = pageContent2;
		//	popupLayout.Content = pageContent2;
			//Content = popupLayout;
			if (App.ScreenHeight > App.ScreenWidth)
			{
				screenHeight = App.ScreenHeight;
				ScreenWidth = App.ScreenWidth;
			}
			else
			{
				screenHeight = App.ScreenWidth;
				ScreenWidth = App.ScreenHeight;
			}

		var title1 = new StackLayout()
		{
			BackgroundColor = Color.FromHex("#eff8e9"),
			Padding = 10,
			Children =
					{
						new Label {Text=AppResource.str_bill_top_header , FontSize = fontsize,
							FontFamily =fontBldStl , TextColor = Color.Black},

					}
		};

			var text1 = new StackLayout()
			{
				Padding = 10,
				//WidthRequest = ((3 * ScreenWidth / 4) - 2),
				Children =
					{
						new Label { Text = AppResource.str_bill_top_desc,  FontSize = fontsize,  FontFamily =fontNrStl , TextColor = Color.Black, BackgroundColor = Color.White,}
					}
			};

			var popup1 = new StackLayout()
			{
				BackgroundColor = Color.White,

				Children =
					{
						title1,text1,
					}
			};
			pageContent.WidthRequest = ((3 * ScreenWidth / 4) - 2);
			pageContent.HeightRequest = (screenHeight / 2);
			pageContent.Children.Add(popup1);
		}

		public UserAnimationPage(StackLayout popup1)
		{
			InitializeComponent();
			if (App.ScreenHeight > App.ScreenWidth)
			{
				screenHeight = App.ScreenHeight;
				ScreenWidth = App.ScreenWidth;
			}
			else
			{
				screenHeight = App.ScreenWidth;
				ScreenWidth = App.ScreenHeight;
			}

			this.popup1 = popup1;
		//	pageContent.WidthRequest = ((3 * ScreenWidth / 4) - 2);
		//	pageContent.HeightRequest = (screenHeight / 2);
			pageContent.Children.Add(popup1);
		}

		private async void OnTapMenu(object sender, EventArgs args)
		{
			await Navigation.PopModalAsync();
			// Navigation.PushModalAsync(new ADDCPage());
		}

		private void OnClose(object sender, EventArgs e)
		{
			PopupNavigation.PopAsync();
		}
	}

}
