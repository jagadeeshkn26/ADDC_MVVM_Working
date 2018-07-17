using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ADDC_MVVM.Resx;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ADDC_MVVM
{
	public partial class MapPage : ContentPage
	{
		public ObservableCollection<CustomPin> getSavedCrd;
		private List<string> ServicesLst;
		private int br = 0, kis = 0, part = 0;
		private string tableName = AppResource.LocateUSEng;
		private string selectedIndexItem;// = "Bill Payment";
		private int selectedIndex;//= 5;// = "";
		private List<LocateUsBean> ServicesLs1t;
		private LocateUsLstBean mapMistItem;
		private double fontsize = 15;
		TextAlignment txtAlign;
		LayoutOptions LytAlign;
		private string fontNrStl = "";
		private double screenHeight = 0;
		int heightReq = 0;
		private double ScreenWidth = 0;
		private  ObservableCollection<LocateUsLstBean> mapMist { get; set; }
		public MapPage()
		{
			InitializeComponent();
			customMap.CustomPins = new List<CustomPin>();
			if (Device.Idiom == TargetIdiom.Phone)
			{
				menuBg.HeightRequest = 60;
				heightReq = 25;
			}
			else
			{

				menuBg.HeightRequest = 80;
				heightReq = 40;
			}
			ListVw.IsVisible = false;
			mapVw.IsVisible = true;
			LstView.Source = "list_map_deselect";
			MapView.Source = "map_icon_select";
			GetDetails();
			fontNrStl = "bliss_regular.ttf#bliss_regular";
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
				LytAlign = LayoutOptions.Start;
			}
			else
			{
				txtAlign = TextAlignment.End;
				LytAlign = LayoutOptions.End;
			}

			if (Device.OS == TargetPlatform.iOS)
			{
				fontNrStl = "BlissRegular";


				//waitiOS(popup1);
			}
			else
			{
				fontNrStl = "bliss_regular.ttf#bliss_regular";
			}
			if (Device.Idiom == TargetIdiom.Phone)
			{
				menuBg.HeightRequest = 60;
				fontsize = 15;
			}
			else
			{
				menuBg.HeightRequest = 80;
				fontsize = 25;
			}
		}

		async Task GetDetails()
		{
			await GetServices(tableName);
			await GetAllLocationServices(tableName);
		}

		void help_Clicked(object sender, System.EventArgs e)
		{
			StackLayout popup1;
			StackLayout popup2 ;
			StackLayout popup3 ;

			var title1 = new StackLayout()
			{
				
				Children =
					{
						new Label {Text=AppResource.str_locate_branch , FontSize = fontsize, VerticalTextAlignment = TextAlignment.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalTextAlignment = txtAlign,
							FontFamily =fontNrStl , TextColor = Color.Black},

					}
			};

			var text1 = new StackLayout()
			{
				
				//WidthRequest = ((3 * ScreenWidth / 4) - 2),
				Children =
					{
					new Image { Source = "ic_branches" , HorizontalOptions = LytAlign, HeightRequest = heightReq}
				}
				};

			var title2 = new StackLayout()
			{
				
				Children =
					{
						new Label {Text=AppResource.str_locate_kiosk , FontSize = fontsize, VerticalTextAlignment = TextAlignment.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalTextAlignment = txtAlign,
							FontFamily =fontNrStl , TextColor = Color.Black},

					}
			};

			var text2 = new StackLayout()
			{
				
				//WidthRequest = ((3 * ScreenWidth / 4) - 2),
				Children =
					{
					new Image { Source = "ic_kiosks", HorizontalOptions = LytAlign , HeightRequest = heightReq}
				}
			};

			var title3 = new StackLayout()
			{
				Children =
					{
					new Label {Text=AppResource.str_partner , FontSize = fontsize, VerticalTextAlignment = TextAlignment.Center,
						VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalTextAlignment = txtAlign,
							FontFamily =fontNrStl , TextColor = Color.Black},

					}
			};

			var text3 = new StackLayout()
			{
				//WidthRequest = ((3 * ScreenWidth / 4) - 2),
				Children =
					{
					new Image { Source = "ic_partner" , HorizontalOptions = LytAlign, HeightRequest = heightReq}
				}
			};

			if (App.CultureCode == "ar")
			{
				popup1 = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					HorizontalOptions = LayoutOptions.End,
					//WidthRequest = ((3 * ScreenWidth / 4) - 2),
					//HeightRequest = (screenHeight / 2),
					Children =
					{

					title1,text1
					}
				};

				popup2 = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					HorizontalOptions = LayoutOptions.End,
					//WidthRequest = ((3 * ScreenWidth / 4) - 2),
					//HeightRequest = (screenHeight / 2),
					Children =
					{
						title2, text2
					}
				};

				popup3 = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					HorizontalOptions = LayoutOptions.End,
					VerticalOptions = LayoutOptions.Center,
					//WidthRequest = ((3 * ScreenWidth / 4) - 2),
					//HeightRequest = (screenHeight / 2),
					Children =
					{
						title3,text3
					}
				};

			}
			else
			{
				popup1 = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					HorizontalOptions = LayoutOptions.Start,
					//WidthRequest = ((3 * ScreenWidth / 4) - 2),
					//HeightRequest = (screenHeight / 2),
					Children =
					{

					text1,title1
					}
				};

				popup2 = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					HorizontalOptions = LayoutOptions.Start,
					//WidthRequest = ((3 * ScreenWidth / 4) - 2),
					//HeightRequest = (screenHeight / 2),
					Children =
					{
						text2,title2
					}
				};

				popup3 = new StackLayout()
				{
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.White,
					HorizontalOptions = LayoutOptions.Start,
					//WidthRequest = ((3 * ScreenWidth / 4) - 2),
					//HeightRequest = (screenHeight / 2),
					Children =
					{
						text3,title3
					}
				};

			}


			var popup4 = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				//VerticalOptions = LayoutOptions.FillAndExpand,
				BackgroundColor = Color.White,
				Padding = 5,
				//WidthRequest = ((3 * ScreenWidth / 4) - 2),
				//HeightRequest = (screenHeight / 2),
				Children =
					{
						popup1, popup2, popup3
					}
			};

			if (Device.OS == TargetPlatform.iOS)
			{
				waitiOS(popup4);
			}
			else
			{
				showPopUp(popup4);
			}


		}
		async void showPopUp(StackLayout popup1)
		{
			var popup2 = new StackLayout()
			{
				BackgroundColor = Color.Gray,
				Padding =2,
				//WidthRequest = (3 * ScreenWidth / 4),
				//HeightRequest = (screenHeight / 2),
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
			//	popupLayout.ShowPopup(popup2)
		}

		async void waitiOS(StackLayout popup1)
		{
			await Task.Delay(1);
			showPopUp(popup1);

		}

		public void OnServicesPickerChanged(object sender, EventArgs args)
		{
			selectedIndex = Services.SelectedIndex;
			selectedIndexItem = Services.Items[Services.SelectedIndex];
			showLocations(selectedIndex, selectedIndexItem, tableName);
		}
		private async Task GetAllLocationServices(String tableName)
		{
			IsBusy = true;
			DataAccess dataAccess = new DataAccess();
			ServicesLs1t = await dataAccess.getAllServices(AppResource.LocateUSEng);

			showPins(ServicesLs1t);
			IsBusy = false;

		}

		void MapDirect_Tapped(object sender, System.EventArgs e)
		{
			int index = mapMist.IndexOf((LocateUsLstBean)((Image)sender).BindingContext);
			String WebDirectLink = "http://maps.google.com/maps?q="
			+ mapMist[index].Latitude + "," + mapMist[index].Longitude + ""; 

			 Device.OpenUri(new Uri(WebDirectLink));
		}
		void FbDirect_Tapped(object sender, System.EventArgs e)
		{
			String FBLink = "https://www.facebook.com/addc.official/";
			Device.OpenUri(new Uri(FBLink));
		}

		void TwitterDirect_Tapped(object sender, System.EventArgs e)
		{
			string TwtLink = "https://twitter.com/ADDC_Official";
			Device.OpenUri(new Uri(TwtLink));
		}
		void LstView_Tapd(object sender, System.EventArgs e)
		{
			ListVw.IsVisible = true;
			mapVw.IsVisible = false;
			LstView.Source = "list_map_select";
			MapView.Source = "map_icon_deselect";

			//throw new NotImplementedException();
		}


		void MapView_Tapped(object sender, System.EventArgs e)
		{
			ListVw.IsVisible = false;
			mapVw.IsVisible = true;
			LstView.Source = "list_map_deselect";
			MapView.Source = "map_icon_select";
//throw new NotImplementedException();
		}


		private async Task GetServices(String tableName)
		{
			IsBusy = true;
			DataAccess dataAccess = new DataAccess();
			//var ServicesLs1t = dataAccess.getAllServices("LocateUSEng");
			ServicesLst = new List<string>();

			ServicesLs1t = await dataAccess.GetAll(tableName);
			foreach (var item in ServicesLs1t)
			{

				//ServicesLst.Add(item.Services);
				Services.Items.Add(item.Services);
			}
			System.Diagnostics.Debug.WriteLine("LocateUs ===      " + "Services List...");
			IsBusy = false;
		}
		public void BranchClicked(object sender, EventArgs args)
		{
			var imageSender = (Image)sender;
			imageSender.Source = "accept_select.png";
			if (br == 0)
			{
				imageSender.Source = "accept_select.png";
				br = 1;
				showLocations(selectedIndex, selectedIndexItem, tableName);
			}
			else
			{
				imageSender.Source = "accept_deselect.png";
				br = 0;
				showLocations(selectedIndex, selectedIndexItem, tableName);
			}


		}
		public void partnerClicked(object sender, EventArgs args)
		{

			var imageSender = (Image)sender;
			imageSender.Source = "accept_select.png";
			if (part == 0)
			{
				imageSender.Source = "accept_select.png";
				part = 1;
				showLocations(selectedIndex, selectedIndexItem, tableName);
			}
			else
			{
				imageSender.Source = "accept_deselect.png";
				part = 0;
				showLocations(selectedIndex, selectedIndexItem, tableName);
			}

		}
		public void KioskClicked(object sender, EventArgs args)
		{
			var imageSender = (Image)sender;
			imageSender.Source = "accept_select.png";
			if (kis == 0)
			{
				imageSender.Source = "accept_select.png";
				kis = 1;
				showLocations(selectedIndex, selectedIndexItem, tableName);
			}
			else
			{
				imageSender.Source = "accept_deselect.png";
				kis = 0;
				showLocations(selectedIndex, selectedIndexItem, tableName);
			}


		}
		private async void GetBranchLocations(String selectedIndexItem, String tableName)
		{
			DataAccess dataAccess = new DataAccess();
			ServicesLs1t = dataAccess.getBranches(selectedIndexItem, tableName);
			showPins(ServicesLs1t);
			System.Diagnostics.Debug.WriteLine("LocateUs ===      " + "Branchs...");
		}
		private async void GetKiosksLocations(String selectedIndexItem, String tableName)
		{
			DataAccess dataAccess = new DataAccess();
			ServicesLs1t = dataAccess.getKiosks(selectedIndexItem, tableName);
			showPins(ServicesLs1t);
			System.Diagnostics.Debug.WriteLine("LocateUs ===      " + "Kiosk...");
		}
		private async void GetPartnerLocations(String selectedIndexItem, String tableName)
		{
			DataAccess dataAccess = new DataAccess();
			ServicesLs1t = dataAccess.getPartners(selectedIndexItem, tableName);
			showPins(ServicesLs1t);
			System.Diagnostics.Debug.WriteLine("LocateUs ===      " + "Partner...");
		}
		private async void GetBrachesAndKiosks(String selectedIndexItem, String tableName)
		{
			DataAccess dataAccess = new DataAccess();
			ServicesLs1t = dataAccess.getBrachesAndKiosks(selectedIndexItem, tableName);
			showPins(ServicesLs1t);
			System.Diagnostics.Debug.WriteLine("LocateUs ===      " + "Branch n Kiosk...");
		}
		private async void GetBrachesAndParners(String selectedIndexItem, String tableName)
		{
			DataAccess dataAccess = new DataAccess();
			ServicesLs1t = dataAccess.getBrachesAndParners(selectedIndexItem, tableName);
			showPins(ServicesLs1t);
			System.Diagnostics.Debug.WriteLine("LocateUs ===      " + "Branch and Partner...");
		}
		private async void GetKiosksAndPartners(String selectedIndexItem, String tableName)
		{
			DataAccess dataAccess = new DataAccess();
			ServicesLs1t = dataAccess.getKiosksAndPartners(selectedIndexItem, tableName);
			showPins(ServicesLs1t);
			System.Diagnostics.Debug.WriteLine("LocateUs ===      " + "Kiosk and Partner...");
		}
		private async void GetSetviceBrachAndKioskListAndPartners(String selectedIndexItem, String tableName)
		{
			DataAccess dataAccess = new DataAccess();
			ServicesLs1t = dataAccess.getSetviceBrachAndKioskListAndPartners(selectedIndexItem, tableName);
			showPins(ServicesLs1t);
			System.Diagnostics.Debug.WriteLine("LocateUs ===      " + "Kiosk and Partner and Branchs...");
		}
		private void showPins(List<LocateUsBean> locs)
		{
			var gen = AppResource.str_locate_branch;
			//int i = 0;
			if (customMap.CustomPins != null)
			{
				customMap.CustomPins.Clear();
				customMap.Pins.Clear();
			}
			else
			{
				customMap.CustomPins = new List<CustomPin>();
			}

			mapMist = new ObservableCollection<LocateUsLstBean>();
			mapMistItem = new LocateUsLstBean();

			mapMist.Clear();

			//mapMist.Add(mapMistItem);
			mapLstVw.ItemsSource = mapMist;

			foreach (var item in locs)
			{
				if (!string.IsNullOrEmpty(item.BKPLocation))
				{
					if (item.BKP1.Equals(AppResource.str_locate_branch))
					{
						gen = AppResource.str_locate_branch;
					}
					else if (item.BKP1.Equals(AppResource.str_locate_kiosk))
					{
						gen = AppResource.str_locate_kiosk;
					}
					else if (item.BKP1.Equals(AppResource.str_locate_partner))
					{
						gen = AppResource.str_locate_partner;
					}
					var pin = new CustomPin
					{
						Pin = new Pin
						{
							Type = PinType.Place,
							Position = new Position(double.Parse(item.Latitude), double.Parse(item.Longitude)),
							Label = item.BKPLocation,

							Address = item.Address + " " + item.Timings + " " + item.Phone
						},
						branchId = AppResource.str_locate_branch,
						kioskId = AppResource.str_locate_kiosk,
						partnerId = AppResource.str_locate_partner,
						Type = gen
					};

					customMap.CustomPins.Add(pin);
					customMap.Pins.Add(pin.Pin);
					//customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(customMap.CustomPins[0].Pin.Position.Latitude, customMap.CustomPins[0].Pin.Position.Latitude), Distance.FromMiles(1.0)));
					mapMistItem.Address = item.Address;
					mapMistItem.BKP1 = item.BKP1;
					mapMistItem.BKP2 = item.BKP2;
					mapMistItem.BKPLocation = item.BKPLocation;
					if (item.BKP1.Equals(AppResource.str_locate_branch))
					{
						mapMistItem.Img = "ic_branches";
					}
					else if (item.BKP1.Equals(AppResource.str_locate_kiosk))
					{
						mapMistItem.Img = "ic_kiosks";
					}
					else if (item.BKP1.Equals(AppResource.str_locate_partner))
					{
						mapMistItem.Img = "ic_partner";
					}

					mapMistItem.Latitude = item.Latitude;
					mapMistItem.LatLong = item.LatLong;
					mapMistItem.Longitude = item.Longitude;
					mapMistItem.OpenDays = item.OpenDays;
					mapMistItem.Phone = item.Phone;
					mapMistItem.region = item.region;
					mapMistItem.Services = item.Services;
					mapMistItem.Timings = item.Timings;

					mapMist.Add(mapMistItem);
					mapLstVw.ItemsSource = mapMist;

				}
				else
				{
				}
				//customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(customMap.CustomPins[0].Pin.Position.Latitude, customMap.CustomPins[0].Pin.Position.Latitude), Distance.FromMiles(1.0)));

			}
			if (customMap.CustomPins.Count > 0)
			{
				customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(customMap.CustomPins[0].Pin.Position.Latitude, customMap.CustomPins[0].Pin.Position.Longitude), Distance.FromMiles(1.0)));

			}

			//Content = customMap;

		}
		private async void OnTapMenu(object sender, EventArgs args)
		{
			await Navigation.PopModalAsync();
			// Navigation.PushModalAsync(new ADDCPage());
		}

		private async void getAllBranches(String tableName)
		{
			DataAccess dataAccess = new DataAccess();
			ServicesLs1t = dataAccess.getAllBranches(tableName);
			showPins(ServicesLs1t);
			System.Diagnostics.Debug.WriteLine("LocateUs ===      " + "All Branchs...");
		}

		private async void getAllPartners(String tableName)
		{
			DataAccess dataAccess = new DataAccess();
			ServicesLs1t = dataAccess.getAllPartners(tableName);
			showPins(ServicesLs1t);
			System.Diagnostics.Debug.WriteLine("LocateUs ===      " + " All Partner...");
		}
		private async void getAllKiosk(String tableName)
		{
			DataAccess dataAccess = new DataAccess();
			ServicesLs1t = dataAccess.getAllKiosk(tableName);
			showPins(ServicesLs1t);
			System.Diagnostics.Debug.WriteLine("LocateUs ===      " + "All Kiosk...");
		}
		private async void getAllBrachesAndParners(String tableName)
		{
			DataAccess dataAccess = new DataAccess();
			ServicesLs1t = dataAccess.getAllBrachesAndParners(tableName);
			showPins(ServicesLs1t);
			System.Diagnostics.Debug.WriteLine("LocateUs ===      " + "All Partner and Branchs...");
		}
		private async void getAllKiosksAndPartners(String tableName)
		{
			DataAccess dataAccess = new DataAccess();
			ServicesLs1t = dataAccess.getAllKiosksAndPartners(tableName);
			showPins(ServicesLs1t);
			System.Diagnostics.Debug.WriteLine("LocateUs ===      " + "All Kiosk and Partner...");
		}
		private async void getAllBrachesAndKiosks(String tableName)
		{
			DataAccess dataAccess = new DataAccess();
			ServicesLs1t = dataAccess.getAllBrachesAndKiosks(tableName);

			showPins(ServicesLs1t);
			System.Diagnostics.Debug.WriteLine("LocateUs ===      " + "All Kiosk and Branchs...");
		}

		//public void OnServicesPickerChanged(object sender, EventArgs args)
		//{
		//    selectedIndex = Services.SelectedIndex;
		//    selectedIndexItem = Services.Items[Services.SelectedIndex];
		//    //if(sender)


		//    showLocations(selectedIndex, selectedIndexItem, tableName);
		//}


		public void showLocations(int selectedIndex, string selectedIndexItem, string tableName)
		{
			if (br == 1 && kis == 0 && part == 0)
			{
				if (!selectedIndex.Equals(0))
				{
					GetBranchLocations(selectedIndexItem, tableName);
				}
				else
				{
					getAllBranches(tableName);
				}
			}
			else if (br == 0 && kis == 1 && part == 0)
			{
				if (!selectedIndex.Equals(0))
				{
					GetKiosksLocations(selectedIndexItem, tableName);
				}
				else
				{
					getAllKiosk(tableName);
				}
			}
			else if (br == 0 && kis == 0 && part == 1)
			{

				if (!selectedIndex.Equals(0))
				{
					GetPartnerLocations(selectedIndexItem, tableName);
				}
				else
				{
					getAllPartners(tableName);
				}

			}
			else if (br == 1 && kis == 1 && part == 1)
			{
				if (!selectedIndex.Equals(0))
				{
					GetSetviceBrachAndKioskListAndPartners(selectedIndexItem, tableName);
				}
				else
				{
					GetAllLocationServices(tableName);
				}
			}
			else if (br == 0 && kis == 0 && part == 0)
			{
				if (!selectedIndex.Equals(0))
				{
					GetSetviceBrachAndKioskListAndPartners(selectedIndexItem, tableName);
				}
				else
				{
					GetAllLocationServices(tableName);
				}
			}
			else if (br == 1 && kis == 0 && part == 1)
			{
				if (!selectedIndex.Equals(0))
				{
					GetBrachesAndParners(selectedIndexItem, tableName);
				}
				else
				{
					getAllBrachesAndParners(tableName);
				}
			}
			else if (br == 0 && kis == 1 && part == 1)
			{
				if (!selectedIndex.Equals(0))
				{

					GetKiosksAndPartners(selectedIndexItem, tableName);
				}
				else
				{
					getAllKiosksAndPartners(tableName);
				}
			}
			else if (br == 1 && kis == 1 && part == 0)
			{
				if (!selectedIndex.Equals(0))
				{
					GetBrachesAndKiosks(selectedIndexItem, tableName);
				}
				else
				{
					getAllBrachesAndKiosks(tableName);
				}
			}
		}
	}
}
