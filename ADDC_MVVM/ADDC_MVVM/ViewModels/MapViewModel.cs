using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ADDC_MVVM.Models;
using ADDC_MVVM.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ADDC_MVVM
{
	public class MapViewModel: ViewModelBase
	{
		private LocateUsBean authRes4;
		//private ObservableCollection<string> ServicesLst;
		private int br = 0, kis = 0, part = 0;
		private string tableName = "LocateUSEng";
		private string selectedIndexItem;// = "Bill Payment";
		private int selectedIndex;//= 5;// = "";
		private List<LocateUsBean> ServicesLs1t;
		public ObservableCollection<string> primiseType { get; set; }
		private LocateUsLstBean mapMistItem;
		public ObservableCollection<CustomPin> CSPins { get; set; }

		private List<string> ServicesLst;
		public ICommand BranchClicked { get; set; }
		public ICommand KioskClicked { get; set; }
		public ICommand partnerClicked { get; set; }
		public ObservableCollection<LocateUsLstBean> mapMist { get; set; }//private ObservableCollection<LocateUsBean> ServicesLs1t;
		public MapViewModel()
		{
			GetServices(tableName);
			GetAllLocationServices(tableName);

			mapMist = new ObservableCollection<LocateUsLstBean>();
			mapMistItem = new LocateUsLstBean();
			primiseType = new ObservableCollection<string>();
			CSPins = new ObservableCollection<CustomPin>();
			BranchClicked = new Command(
				async () => await BranchClick(),
			  () => !IsBusy);
			KioskClicked = new Command(
				async () =>await KioskClik(),
			  () => !IsBusy);
			partnerClicked = new Command(
				async () => await partnerClick(),
			  () => !IsBusy);
		}
		//public void OnServicesPickerChanged(object sender, EventArgs args)
		//{
		//	selectedIndex = Services.SelectedIndex;
		//	selectedIndexItem = primiseType[Services.SelectedIndex];
		//	showLocations(selectedIndex, selectedIndexItem, tableName);
		//}
		private async void GetAllLocationServices(String tableName)
		{
			DataAccess dataAccess = new DataAccess();
			ServicesLs1t = await dataAccess.getAllServices("LocateUSEng");

			showPins(ServicesLs1t);
			//customMap.CustomPins = new List<CustomPin> ();
			//foreach (var item in ServicesLs1t)
			//{
			//     if (item.BKP1.Equals("Branch"))
			//    {
			//        var type = PinType.Place;
			//    }
			//    var pin = new CustomPin
			//    {
			//        Pin = new Pin                              //Kiosk,PARTNERS
			//        {

			//     Type = type,
			//            Position = new Position(double.Parse(item.Latitude), double.Parse(item.Longitude)),
			//            Label = "ADDC",
			//            Address = item.Address


			//        },

			//    };

			//    customMap.CustomPins.Add(pin);// = new List<CustomPin> { pin };
			//    customMap.Pins.Add(pin.Pin);

			//}

		}
		private async void GetServices(String tableName)
		{
			DataAccess dataAccess = new DataAccess();
			//var ServicesLs1t = dataAccess.getAllServices("LocateUSEng");
			ServicesLst = new List<string>();

			ServicesLs1t = await dataAccess.GetAll(tableName);
			foreach (var item in ServicesLs1t)
			{

				//ServicesLst.Add(item.Services);
				//primiseType.Add(item.Services);
			}
			System.Diagnostics.Debug.WriteLine("LocateUs ===      " + "Services List...");
		}
		public async Task BranchClick()
		{
			//var imageSender = (Image)sender;
		//	imageSender.Source = "accept_select.png";
			if (br == 0)
			{
			//	imageSender.Source = "accept_select.png";
				br = 1;
				showLocations(selectedIndex, selectedIndexItem, tableName);
			}
			else
			{
				//imageSender.Source = "accept_deselect.png";
				br = 0;
				showLocations(selectedIndex, selectedIndexItem, tableName);
			}


		}
		public async Task  partnerClick()
		{

			//var imageSender = (Image)sender;
			//imageSender.Source = "accept_select.png";
			if (part == 0)
			{
			//	imageSender.Source = "accept_select.png";
				part = 1;
				showLocations(selectedIndex, selectedIndexItem, tableName);
			}
			else
			{
				//imageSender.Source = "accept_deselect.png";
				part = 0;
				showLocations(selectedIndex, selectedIndexItem, tableName);
			}

		}
		public async Task KioskClik()
		{
			//var imageSender = (Image)sender;
			//imageSender.Source = "accept_select.png";
			if (kis == 0)
			{
			//	imageSender.Source = "accept_select.png";
				kis = 1;
				showLocations(selectedIndex, selectedIndexItem, tableName);
			}
			else
			{
				//imageSender.Source = "accept_deselect.png";
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

			var gen = "Branch";
			//int i = 0;
			CSPins = new ObservableCollection<CustomPin>();
			mapMist = new ObservableCollection<LocateUsLstBean>();
			mapMistItem = new LocateUsLstBean();
			if (CSPins.Count > 0)
			{

				CSPins.Clear();
			}

			foreach (var item in locs)
			{

				if (item.BKP1.Equals("Branch"))
				{
					gen = "Branch";
				}
				else if (item.BKP1.Equals("Kiosk"))
				{
					gen = "Kiosk";
				}
				else if (item.BKP1.Equals("PARTNERS"))
				{
					gen = "PARTNERS";
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
					//Id = "Xamarin",
					//Url = "http://xamarin.com/about/",
					Type = gen
				};

				CSPins.Add(pin);
				//CSPins.Add(pin.Pin);
				//customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(customMap.CustomPins[0].Pin.Position.Latitude, customMap.CustomPins[0].Pin.Position.Longitude), Distance.FromMiles(1.0)));
				mapMistItem.Address = item.Address;
				mapMistItem.BKP1 = item.BKP1;
				mapMistItem.BKP2 = item.BKP2;
				mapMistItem.BKPLocation = item.BKPLocation;
				if (item.BKP1.Equals("Branch"))
				{
					mapMistItem.Img = "branch";
				}
				else if (item.BKP1.Equals("Kiosk"))
				{
					mapMistItem.Img = "kiosk";
				}
				else if (item.BKP1.Equals("PARTNERS"))
				{
					mapMistItem.Img = "patren";
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
			}
			//customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(customMap.CustomPins[0].Pin.Position.Latitude,customMap.CustomPins[0].Pin.Position.Latitude), Distance.FromMiles(1.0)));

			//Content = customMap;

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
			CSPins = new ObservableCollection<CustomPin>();
			showPins(ServicesLs1t);
			System.Diagnostics.Debug.WriteLine("LocateUs ===      " + "All Kiosk and Branchs...");
		}

		//public void OnServicesPickerChanged(object sender, EventArgs args)
		//{
		//    selectedIndex = Services.SelectedIndex;
		//    selectedIndexItem = primiseType[Services.SelectedIndex];
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
