using System;
using ADDC_MVVM.ViewModels;
using Xamarin.Forms;

namespace ADDC_MVVM
{
	public class CDAirConditionerVM: ViewModelBase
	{
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
		public CDAirConditionerVM()
		{
			if (Device.Idiom == TargetIdiom.Phone)
			{
				pointerHeight = "25";
				iconHeight = "50";
				menuHeight = "60";
				menuiconHeight = "30";
			}
			else
			{
				pointerHeight = "35";
				iconHeight = "65";
				menuHeight = "80";
				menuiconHeight = "50";
			}
		}
	}
}
