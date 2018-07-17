using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ADDC_MVVM.Resx;
using ADDC_MVVM.ViewModels;
using Xamarin.Forms;

namespace ADDC_MVVM
{
	public class AboutUsViewModel : ViewModelBase
	{
		public ICommand OnTapMenu { get; set; }
		public ICommand OnTapOverview { get; set; }
		public ICommand OnTapMission { get; set; }
		public ICommand OnTapVision { get; set; }
		public ICommand OnTapValues { get; set; }
		public ICommand OnFbview { get; set; }
		public ICommand Ontwtview { get; set; }
		public ICommand OnInstaview { get; set; }
		String FBLink = "https://www.facebook.com/addc.official/";
		string TwtLink = "https://twitter.com/ADDC_Official";
		string InstLink = "https://instagram.com/addc_abudhabi/";
		string selectedTxt = "#5e9622";
		string deselectedTxt = "Black";
		string decView;
		string txtOverview;
		string valueView;
		string overviewImg;
		string lblOverviewColor;
		string missionImg;
		string lblMissionColor;
		string vissionImg;
		string lblVisionColor;
		string valueImg;
		string lblValuesColor;
		string _pointerHeight;
		string _iconHeight;

		string _menuiconHeight;

		public string menuiconHeight
		{
			get { return _menuiconHeight; }
			set { SetProperty(ref _menuiconHeight, value); }
		}
		string _menuHeight;
		public string menuHeight
		{
			get { return _menuHeight; }
			set { SetProperty(ref _menuHeight, value); }
		}
		public string iconHeight
		{
			get { return _iconHeight; }
			set { SetProperty(ref _iconHeight, value); }
		}
		public string pointerHeight
		{
			get { return _pointerHeight; }
			set { SetProperty(ref _pointerHeight, value); }
		}
		public string DecView
		{
			get { return decView; }
			set { SetProperty(ref decView, value); }
		}
		public string TxtOverview
		{
			get { return txtOverview; }
			set { SetProperty(ref txtOverview, value); }
		}
		public string ValueView
		{
			get { return valueView; }
			set { SetProperty(ref valueView, value); }
		}
		public string OverviewImg
		{
			get { return overviewImg; }
			set { SetProperty(ref overviewImg, value); }
		}
		public string LblOverviewColor
		{
			get { return lblOverviewColor; }
			set { SetProperty(ref lblOverviewColor, value); }
		}
		public string MissionImg
		{
			get { return missionImg; }
			set { SetProperty(ref missionImg, value); }
		}

		public string LblMissionColor
		{
			get { return lblMissionColor; }
			set { SetProperty(ref lblMissionColor, value); }
		}
		public string VissionImg
		{
			get { return vissionImg; }
			set { SetProperty(ref vissionImg, value); }
		}

		public string LblVisionColor
		{
			get { return lblVisionColor; }
			set { SetProperty(ref lblVisionColor, value); }
		}

		public string ValueImg
		{
			get { return valueImg; }
			set { SetProperty(ref valueImg, value); }
		}

		public string LblValuesColor
		{
			get { return lblValuesColor; }
			set { SetProperty(ref lblValuesColor, value); }
		}

		public AboutUsViewModel()
		{
				if (Device.Idiom == TargetIdiom.Phone)
				{
					pointerHeight = "15";
					iconHeight = "50";
					menuHeight = "60";
					menuiconHeight = "30";
				}
				else {
					pointerHeight = "25";
					iconHeight = "65";
					menuHeight = "80";
					menuiconHeight = "50";
				}
		
		
				OnTapMenu = new Command(
			  async () => await OnTapMenuCmd(),
			  () => !IsBusy);
			OnTapOverview = new Command(
				async () => await OnTapOverviewCmd(),
			  () => !IsBusy);
			OnTapMission = new Command(
				async () => await OnTapMissionCmd(),
			  () => !IsBusy);
			OnTapVision = new Command(
				async () => await OnTapVisionCmd(),
			  () => !IsBusy);
			OnTapValues = new Command(
				async () => await OnTapValuesCmd(),
			  () => !IsBusy);
			OnFbview = new Command(
				 () =>  WebViewPAge(FBLink),
			  () => !IsBusy);
			Ontwtview = new Command(
				 () =>  WebViewPAge(TwtLink),
			  () => !IsBusy);
			OnInstaview = new Command(
				 () =>  WebViewPAge(InstLink),
			  () => !IsBusy);

			DisplayView("overview_select",
			 				selectedTxt,
			 				"mission_deselect",
			 				deselectedTxt,
			 				"vission_deselect",
			 				deselectedTxt,
			 				"value_deselect",
							deselectedTxt, 
			            	"true",
			            	AppResource.TxtOverview,
			            	"false");
			
		}

		/// <summary>
		/// Displaies the view.
		/// </summary>
		/// <param name="ovImg">Ov image.</param>
		/// <param name="lblOviewColor">Lbl oview color.</param>
		/// <param name="mImg">M image.</param>
		/// <param name="lblM">Lbl m.</param>
		/// <param name="lblMColor">Lbl MC olor.</param>
		/// <param name="vImg">V image.</param>
		/// <param name="lblV">Lbl v.</param>
		/// <param name="lblVColor">Lbl VC olor.</param>
		/// <param name="vaImg">Va image.</param>
		/// <param name="lblVa">Lbl va.</param>
		/// <param name="lblVaColor">Lbl va color.</param>
		/// <param name="DView">DV iew.</param>
		/// <param name="TxtOview">Text oview.</param>
		/// <param name="ValueVw">Value vw.</param>
		void DisplayView(string ovImg,
		                 string lblOviewColor, string mImg, string lblMColor,
		                 string vImg, 
		                 string lblVColor, string vaImg, string lblVaColor ,
		                 string DView ,string TxtOview ,string ValueVw)
		{
			 OverviewImg= ovImg;
			 
			 LblOverviewColor= lblOviewColor;
			 MissionImg= mImg;
			 
			 LblMissionColor= lblMColor;
			 VissionImg= vImg;
			 
			 LblVisionColor= lblVColor;
			 ValueImg= vaImg;
			 
			 LblValuesColor= lblVaColor;
			DecView = DView;
			TxtOverview = TxtOview ;
			ValueView = ValueVw;
		}

		private void WebViewPAge(string WebLink)
		{
		 Device.OpenUri(new Uri(WebLink));
			//throw new NotImplementedException();
		}

		/// <summary>
		///  menu button is clicked to navigate to menu options   
		/// </summary>
		/// <returns></returns>
		private async Task OnTapMenuCmd()
		{

			await App.Current.MainPage.Navigation.PopModalAsync();

		}

		private async Task OnTapOverviewCmd()
		{

			DisplayView("overview_select",
			 				selectedTxt,
			 				"mission_deselect",
			 				deselectedTxt,
			 				"vission_deselect",
			 				deselectedTxt,
			 				"value_deselect",
							deselectedTxt,
							"true",
							AppResource.TxtOverview,
							"false");

		}

		private async Task OnTapMissionCmd()
		{

			DisplayView("overview_deselect",
			 			deselectedTxt,
			 			"mission_select",
			 			selectedTxt,
			 			"vission_deselect",
			 			deselectedTxt,
						"value_deselect",
						deselectedTxt,
						"true",
		            	AppResource.TxtMission,
			            "false");
		}

		private async Task OnTapVisionCmd()
		{
			DisplayView("overview_deselect",
			 			deselectedTxt,
			 			"mission_deselect",
			 			deselectedTxt,
			 			"vission_select",
			 			selectedTxt,
						"value_deselect",
						deselectedTxt,
						"true",
						AppResource.TxtVision,
						"false");

		}

		private async Task OnTapValuesCmd()
		{
			DisplayView("overview_deselect",
			 			deselectedTxt,
			 			"mission_deselect",
			 			deselectedTxt,
			 			"vission_deselect",
			 			deselectedTxt,
						"value_select",
						selectedTxt,
						"false",
						AppResource.TxtValue,
						"true");

		}
	}
}
