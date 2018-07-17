using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ADDC_MVVM.ViewModels;
using Xamarin.Forms;

namespace ADDC_MVVM
{
	public class ConservationTipsViewModel: ViewModelBase
	{
		public ICommand LoginCommand { get; set; }
		public ICommand OnTapMenu { get; set; }

		public ICommand Water_Tapped { get; set; }
		public ICommand Elec_Tapped { get; set; }
		private string wtrImg;
		string _pointerHeight;
		string _iconHeight;
		string _menuHeight;
		string _menuiconHeight;

		public string menuiconHeight
		{
			get { return _menuiconHeight; }
			set { SetProperty(ref _menuiconHeight, value); }
		}
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
		public string WtrImg
		{
			get { return wtrImg; }
			set { SetProperty(ref wtrImg, value); }
		}
		private string eleImg;
		public string EleImg
		{
			get { return eleImg; }
			set { SetProperty(ref eleImg, value); }
		}
		private string wtrTxt;
		public string WtrTxt
		{
			get { return wtrTxt; }
			set { SetProperty(ref wtrTxt, value); }
		}

		private string eleTxt;
		public string EleTxt
		{
			get { return eleTxt; }
			set { SetProperty(ref eleTxt, value); }
		}

		private string wtrView;
		public string WtrView
		{
			get { return wtrView; }
			set { SetProperty(ref wtrView, value); }
		}

		private string eleView;
		public string EleView
		{
			get { return eleView; }
			set { SetProperty(ref eleView, value); }
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="T:ADDC_MVVM.ConservationTipsViewModel"/> class.
		/// </summary>
		public ConservationTipsViewModel()
		{
			WtrTxt = "#5e9622";
			EleTxt = "Black";
			WtrView = "true";
			EleView = "false";
			WtrImg = "water_select";
			EleImg = "conserve_elec_deselect";

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
				async () => await App.Current.MainPage.Navigation.PopModalAsync(),
				() => !IsBusy);

			Water_Tapped = new Command(
				async () => await Water_View(),
				() => !IsBusy);

			Elec_Tapped = new Command(
				async () => await Elec_View(),
				() => !IsBusy);

		}

		async Task Water_View()
		{
			WtrImg = "water_select";
			EleImg = "conserve_elec_deselect";
			WtrTxt = "#5e9622";
			EleTxt = "Black";
			WtrView = "true";
			EleView = "false";
		}

		async Task Elec_View()
		{
			WtrImg = "water_deselect";
			EleImg = "conserve_elec_select";
			WtrTxt = "Black";
			EleTxt = "#5e9622";
			WtrView = "false";
			EleView = "true";
		}
}
}
