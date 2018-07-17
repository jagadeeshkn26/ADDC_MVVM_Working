using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ADDC_MVVM.Resx;
using Rg.Plugins.Popup.Extensions;

namespace ADDC_MVVM.Views
{
    public partial class WaterBill : ContentPage
    {
		private string fontNrStl = "";
		private string fontBldStl = "";
		private double fontsize = 15;
		TextAlignment txtAlign;
		private double screenHeight = 0;
		private double ScreenWidth = 0;
		public WaterBill()
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
			if (AppResource.hor_Label == "Start")
			{
				txtAlign = TextAlignment.Start;
			}
			else
			{
				txtAlign = TextAlignment.End;
			}
			if (Device.OS == TargetPlatform.iOS)
			{
				fontNrStl = "BlissRegular";
				fontBldStl = "BlissBold";
				rowHeight1.HeightRequest = (screenHeight * 0.30);
				rowHeight2.HeightRequest = (screenHeight * 0.40);
				rowHeight3.HeightRequest = (screenHeight * 0.15);

				//waitiOS(popup1);
			}
			else {
				rowHeight1.HeightRequest = (screenHeight * 0.15);
				rowHeight2.HeightRequest = (screenHeight * 0.40);
				rowHeight3.HeightRequest = (screenHeight * 0.15);

				fontNrStl = "bliss_regular.ttf#bliss_regular";
				fontBldStl = "bliss_bold.ttf#bliss_bold";
			}
			if (Device.Idiom == TargetIdiom.Phone)
			{
				menuBg.HeightRequest = 60;
				fontsize = 15;
			}
			else {
				menuBg.HeightRequest = 80;
				fontsize = 25;
			}

		}
			private void OnEmptyGridTap(object sender, EventArgs args)
		{


		}


		async void OnTapMenu(object sender, System.EventArgs e)
		{
			await App.Current.MainPage.Navigation.PopModalAsync();
		}


		private async void OnTapImage1(object sender, EventArgs args)
		{
			var title1 = new StackLayout()
			{
				BackgroundColor = Color.FromHex("#eff8e9"),
				Padding = 10,
				Children =
					{
					new Label {Text=AppResource.str_bill_top_header , FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontBldStl , TextColor = Color.Black},

					}
			};

			var text1 = new StackLayout()
			{
				Padding = 10,
				WidthRequest = ((3 * ScreenWidth / 4) - 2),
				Children =
					{
						new Label { Text = AppResource.str_bill_top_desc,  FontSize = fontsize, HorizontalTextAlignment = txtAlign,  FontFamily =fontNrStl , TextColor = Color.Black, BackgroundColor = Color.White,}
					}
			};

			var popup1 = new StackLayout()
			{
				BackgroundColor = Color.White,

				WidthRequest = (3 * ScreenWidth / 4),
				HeightRequest = (screenHeight / 2),
				Children =
					{
						title1,text1,
					}
			};

			if (Device.OS == TargetPlatform.iOS)
			{
				waitiOS(popup1);
			}
			else {
				showPopUp(popup1);
			}


		}

		async void showPopUp(StackLayout popup1)
		{
			var popup2 = new StackLayout()
			{
				BackgroundColor = Color.Green,
				Padding = 2,
				WidthRequest = (3 * ScreenWidth / 4),
				HeightRequest = (screenHeight / 2),
				Children =
					{
						popup1
					}
			};
			var page = new UserAnimationPage(popup2);
			await Navigation.PushPopupAsync(page);
			//var scroolview = new ScrollView
			//{
			//	BackgroundColor = Color.Green,
			//	Padding = 2,
			//	WidthRequest = (3 * ScreenWidth / 4),
			//	HeightRequest = (screenHeight / 2),
			//	VerticalOptions = LayoutOptions.FillAndExpand,
			//	Content = popup1

			//};
			//	popupLayout.ShowPopup(popup2);
		}

		async void waitiOS(StackLayout popup1)
		{
			await Task.Delay(1);
			showPopUp(popup1);

		}

		private void OnTapImage2(object sender, EventArgs args)
		{
			var title2 = new StackLayout()
			{
				BackgroundColor = Color.FromHex("#eff8e9"),
				Padding = 10,
				Children =
					{
						new Label {Text=AppResource.str_bill_custsupport,  FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontBldStl , TextColor = Color.Black  },

					}
			};

			var text2 = new StackLayout()
			{
				BackgroundColor = Color.White,
				Padding = 10,
				WidthRequest = ((3 * ScreenWidth / 4) - 2),
				Children =
					{
						  new Label { Text = AppResource.str_bill_custsupport_desc, FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontNrStl , TextColor = Color.Black,
							BackgroundColor = Color.White,}
					}
			};

			var popup2 = new StackLayout()
			{
				BackgroundColor = Color.White,

				WidthRequest = (3 * ScreenWidth / 4),
				HeightRequest = (screenHeight / 2),
				Children =
					{
						title2,text2,
					}
			};



			if (Device.OS == TargetPlatform.iOS)
			{
				waitiOS(popup2);
			}
			else
			{
				showPopUp(popup2);
			}

		}
		private void OnTapImage3(object sender, EventArgs args)
		{

			var title3 = new StackLayout()
			{
				BackgroundColor = Color.FromHex("#eff8e9"),
				Padding = 10,
				Children =
					{
						new Label {Text= AppResource.str_bill_left_header,  FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily = fontBldStl , TextColor = Color.Black},

					}
			};
			//dec
			var text3 = new StackLayout()
			{
				BackgroundColor = Color.White,
				Padding = 10,
				Children =
					{
						new Label { Text = AppResource.str_meter_title_desc,
							 FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontNrStl , TextColor = Color.Black,
							BackgroundColor = Color.White}
					}
			};

			//tilt1
			var text31 = new StackLayout()
			{
				BackgroundColor = Color.White,
				Padding = 10,
				Children =
					{
						new Label { Text = AppResource.str_meter_title2,
							 FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontBldStl , TextColor = Color.Black,
							BackgroundColor = Color.White},
						new Label{ Text = AppResource.str_meter_desc1,  FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontNrStl , TextColor = Color.Black,
							BackgroundColor = Color.White}
					}
			};


			//title2
			var text32 = new StackLayout()
			{
				BackgroundColor = Color.White,
				Padding = 10,
				Children =
					{
						new Label { Text = AppResource.str_meter_title2,
							 FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontBldStl , TextColor = Color.Black,
							BackgroundColor = Color.White},
						new Label{ Text = AppResource.str_meter_desc2,
							 FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontNrStl , TextColor = Color.Black,
							BackgroundColor = Color.White}

					}
			};



			///title 3
			var text33 = new StackLayout()
			{
				BackgroundColor = Color.White,
				Padding = 10,
				Children =
					{
						new Label { Text = AppResource.str_meter_title3,
							 FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontBldStl , TextColor = Color.Black,
							BackgroundColor = Color.White},
						new Label{ Text = AppResource.str_meter_desc3,
							 FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontNrStl , TextColor = Color.Black,
							BackgroundColor = Color.White}
					}
			};


			//title 4
			//var text34 = new StackLayout()
			//{
			//	BackgroundColor = Color.White,
			//	Padding = 10,
			//	Children =
			//	{
			//		new Label { Text = AppResource.str_meter_title4,
			//			 FontSize = fontsize, HorizontalTextAlignment = txtAlign,
			//			FontFamily =fontBldStl , TextColor = Color.Black,
			//			BackgroundColor = Color.White},
			//		new Label{ Text = AppResource.str_meter_desc4,
			//			 FontSize = fontsize, HorizontalTextAlignment = txtAlign,
			//			FontFamily =fontNrStl , TextColor = Color.Black,
			//			BackgroundColor = Color.White}
			//	}
			//};

			//title 5
			//var text35 = new StackLayout()
			//{
			//	BackgroundColor = Color.White,
			//	Padding = 10,
			//	Children =
			//	{
			//		new Label { Text = AppResource.str_meter_title5, 
			//			 FontSize = fontsize, HorizontalTextAlignment = txtAlign,
			//			FontFamily =fontNrStl , TextColor = Color.Black,
			//			BackgroundColor = Color.White},
			//		new Label{ Text = AppResource.str_meter_desc5,  FontSize = fontsize, HorizontalTextAlignment = txtAlign,
			//			FontFamily =fontNrStl , TextColor = Color.Black,
			//			BackgroundColor = Color.White}
			//	}
			//};


			var popup3 = new StackLayout()
			{
				BackgroundColor = Color.White,
				WidthRequest = (3 * ScreenWidth / 4),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children =
					{
						text3,text31,text32, text33//, text34, text35
					}
			};

			var scroolview = new ScrollView
			{

				WidthRequest = (3 * ScreenWidth / 4),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Content = popup3

			};
			var popup31 = new StackLayout()
			{
				BackgroundColor = Color.White,
				WidthRequest = (3 * ScreenWidth / 4),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children =
					{
						title3,scroolview
					}
			};

			if (Device.OS == TargetPlatform.iOS)
			{
				waitiOS(popup31);
			}
			else
			{
				showPopUp(popup31);
			}

		}

		private void OnTapImage4(object sender, EventArgs args)
		{

			var title4 = new StackLayout()
			{
				BackgroundColor = Color.FromHex("#eff8e9"),
				Padding = 10,
				Children =
					{
						new Label {Text= AppResource.str_bill_middle_top_header,  FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily = fontBldStl , TextColor = Color.Black},

					}
			};
			//dec
			var text4 = new StackLayout()
			{
				BackgroundColor = Color.White,
				Padding = 10,
				Children =
					{
						new Label { Text = AppResource.str_bill_middle_top_header_desc,
							 FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontNrStl , TextColor = Color.Black,
							BackgroundColor = Color.White}
					}
			};

			var text41 = new StackLayout()
			{
				BackgroundColor = Color.White,
				Padding = 10,
				Children =
					{
						new Label { Text = AppResource.str_sum_title1,
							 FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontBldStl , TextColor = Color.Black,
							BackgroundColor = Color.White},
						new Label{ Text = AppResource.str_sum_desc1,  FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontNrStl , TextColor = Color.Black,
							BackgroundColor = Color.White}
					}
			};

			//tilt1
			var text42 = new StackLayout()
			{
				BackgroundColor = Color.White,
				Padding = 10,
				Children =
					{
						new Label { Text = AppResource.str_sum_title2,
							 FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontBldStl , TextColor = Color.Black,
							BackgroundColor = Color.White},
						new Label{ Text = AppResource.str_sum_desc2,  FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontNrStl , TextColor = Color.Black,
							BackgroundColor = Color.White}
					}
			};


			//title2
			var text43 = new StackLayout()
			{
				BackgroundColor = Color.White,
				Padding = 10,
				Children =
					{
						new Label { Text = AppResource.str_sum_title3,
							 FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontBldStl , TextColor = Color.Black,
							BackgroundColor = Color.White},
						new Label{ Text = AppResource.str_sum_desc3,
							 FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontNrStl , TextColor = Color.Black,
							BackgroundColor = Color.White}

					}
			};





			var popup4 = new StackLayout()
			{
				BackgroundColor = Color.White,
				WidthRequest = (3 * ScreenWidth / 4),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children =
					{
						text4,text41,text42, text43//, text34, text35
					}
			};

			var scroolview = new ScrollView
			{

				WidthRequest = (3 * ScreenWidth / 4),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Content = popup4

			};
			var popup41 = new StackLayout()
			{
				BackgroundColor = Color.White,
				WidthRequest = (3 * ScreenWidth / 4),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children =
					{
						title4,scroolview
					}
			};

			if (Device.OS == TargetPlatform.iOS)
			{
				waitiOS(popup41);
			}
			else
			{
				showPopUp(popup41);
			}

		}

		private void OnTapImage5(object sender, EventArgs args)
		{

			var title5 = new StackLayout()
			{
				BackgroundColor = Color.FromHex("#eff8e9"),
				Padding = 10,
				Children =
					{
						new Label {Text= AppResource.str_bill_middle_bottom_header,  FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily = fontBldStl , TextColor = Color.Black},

					}
			};
			//dec

			var text51 = new StackLayout()
			{
				BackgroundColor = Color.White,
				Padding = 10,
				Children =
					{
						new Label { Text = AppResource.str_bill_middle_bottom_desc,
							 FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontBldStl , TextColor = Color.Black,
							BackgroundColor = Color.White},
						new Label{ Text = AppResource.str_bill_middle_bottom_cont,  FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontNrStl , TextColor = Color.Black,
							BackgroundColor = Color.White}
					}
			};

			//tilt1
			var text52 = new StackLayout()
			{
				BackgroundColor = Color.White,
				Padding = 10,
				Children =
					{
						new Label { Text = AppResource.str_btp_title4_bold,
							 FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontBldStl , TextColor = Color.Black,
							BackgroundColor = Color.White},
						new Label{ Text = AppResource.str_bill_latest_middle_bottom_desc,  FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontNrStl , TextColor = Color.Black,
							BackgroundColor = Color.White}
					}
			};



			var popup4 = new StackLayout()
			{
				BackgroundColor = Color.White,
				WidthRequest = (3 * ScreenWidth / 4),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children =
					{
						text51,text52
					}
			};

			var scroolview = new ScrollView
			{

				WidthRequest = (3 * ScreenWidth / 4),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Content = popup4

			};
			var popup41 = new StackLayout()
			{
				BackgroundColor = Color.White,
				WidthRequest = (3 * ScreenWidth / 4),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children =
					{
						title5,scroolview
					}
			};

			if (Device.OS == TargetPlatform.iOS)
			{
				waitiOS(popup41);
			}
			else
			{
				showPopUp(popup41);
			}
		}

		private void OnTapImage6(object sender, EventArgs args)
		{

			var title6 = new StackLayout()
			{
				BackgroundColor = Color.FromHex("#eff8e9"),
				Padding = 10,
				Children =
					{
						new Label {Text= AppResource.str_bill_custdetails,  FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily = fontBldStl , TextColor = Color.Black},

					}
			};
			//dec
			var text4 = new StackLayout()
			{
				BackgroundColor = Color.White,
				Padding = 10,
				Children =
					{
						new Label { Text = AppResource.str_cust_title1,
							 FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontNrStl , TextColor = Color.Black,
							BackgroundColor = Color.White}
					}
			};

			var text41 = new StackLayout()
			{
				BackgroundColor = Color.White,
				Padding = 10,
				Children =
					{
						new Label { Text = AppResource.str_cust_title3,
							 FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontBldStl , TextColor = Color.Black,
							BackgroundColor = Color.White},
						new Label{ Text = AppResource.str_bill_num_right_desc,  FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontNrStl , TextColor = Color.Black,
							BackgroundColor = Color.White}
					}
			};




			var popup4 = new StackLayout()
			{
				BackgroundColor = Color.White,
				WidthRequest = (3 * ScreenWidth / 4),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children =
					{
						text4,text41
					}
			};

			var scroolview = new ScrollView
			{

				WidthRequest = (3 * ScreenWidth / 4),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Content = popup4

			};
			var popup41 = new StackLayout()
			{
				BackgroundColor = Color.White,
				WidthRequest = (3 * ScreenWidth / 4),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children =
					{
						title6,scroolview
					}
			};

			if (Device.OS == TargetPlatform.iOS)
			{
				waitiOS(popup41);
			}
			else
			{
				showPopUp(popup41);
			}
		}


		private void OnTapImage7(object sender, EventArgs args)
		{

			var title4 = new StackLayout()
			{
				BackgroundColor = Color.FromHex("#eff8e9"),
				Padding = 10,
				Children =
					{
						new Label {Text= AppResource.str_bill_bottom_header,  FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily = fontBldStl , TextColor = Color.Black},

					}
			};
			//dec

			var text41 = new StackLayout()
			{
				BackgroundColor = Color.White,
				Padding = 10,
				Children =
					{
						new Label { Text = AppResource.str_btp_title4_bold,
							 FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontBldStl , TextColor = Color.Black,
							BackgroundColor = Color.White},
						new Label{ Text = AppResource.str_sum_desc1,  FontSize = fontsize, HorizontalTextAlignment = txtAlign,
							FontFamily =fontNrStl , TextColor = Color.Black,
							BackgroundColor = Color.White}
					}
			};



			var popup4 = new StackLayout()
			{
				BackgroundColor = Color.White,
				WidthRequest = (3 * ScreenWidth / 4),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children =
					{
						text41
					}
			};

			var scroolview = new ScrollView
			{

				WidthRequest = (3 * ScreenWidth / 4),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Content = popup4

			};
			var popup41 = new StackLayout()
			{
				BackgroundColor = Color.White,
				WidthRequest = (3 * ScreenWidth / 4),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children =
					{
						title4,scroolview
					}
			};

			if (Device.OS == TargetPlatform.iOS)
			{
				waitiOS(popup41);
			}
			else
			{
				showPopUp(popup41);
			}

		}


	}	
}
