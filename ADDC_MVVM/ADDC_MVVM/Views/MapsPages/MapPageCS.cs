﻿using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace ADDC_MVVM
{
	public class MapPageCS : ContentPage
	{
		public MapPageCS ()
		{
			var customMap = new CustomMap {
				MapType = MapType.Street,
				WidthRequest = App.ScreenWidth,
				HeightRequest = App.ScreenHeight
			};

			var pin = new CustomPin {
				Pin = new Pin {
					Type = PinType.Place,
					Position = new Position (37.79752, -122.40183),
					Label = "Xamarin San Francisco Office",
					Address = "394 Pacific Ave, San Francisco CA"
				},
				//Id = "Xamarin",
				//Url = "http://xamarin.com/about/"
			};

            customMap.CustomPins = new List<CustomPin> { pin };
            customMap.Pins.Add(pin.Pin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37.79752, -122.40183), Distance.FromMiles(1.0)));

            Content = customMap;

           
            
        }
	}
}
