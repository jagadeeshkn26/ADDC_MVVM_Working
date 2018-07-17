using System;
using System.Globalization;

namespace ADDC_MVVM
{
	public interface ILocalize
	{
	
        CultureInfo GetCurrentCultureInfo();
        CultureInfo GetCurrentCultureInfo(string sLanguageCode);
        void SetLocale();
        void ChangeLocale(string sLanguageCode);
    }
}

