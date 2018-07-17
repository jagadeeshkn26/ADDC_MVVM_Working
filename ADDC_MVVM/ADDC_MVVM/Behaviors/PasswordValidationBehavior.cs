using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace ADDC_MVVM
{
	 
    public class PasswordValidationBehavior : Behavior<Entry>
	{
		const string passwordRegex = "^(?=.*?[a-zA-Z])(?=.*?[0-9])(?=.*?[_@.-]).{8,30}$";


		protected override void OnAttachedTo(Entry bindable)
		{
			bindable.TextChanged += HandleTextChanged;
			base.OnAttachedTo(bindable);
		}

		void HandleTextChanged(object sender, TextChangedEventArgs e)
		{
			bool IsValid = false;
			IsValid = (Regex.IsMatch(e.NewTextValue, passwordRegex));
			((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
		}

		protected override void OnDetachingFrom(Entry bindable)
		{
			bindable.TextChanged -= HandleTextChanged;
			base.OnDetachingFrom(bindable);
		}
	}
}