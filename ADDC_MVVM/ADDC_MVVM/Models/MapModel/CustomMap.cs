﻿using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace ADDC_MVVM
{
	public class CustomMap : Map
	{
		public List<CustomPin> CustomPins { get; set; }
	}
}
