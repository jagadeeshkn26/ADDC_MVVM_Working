using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ADDC_MVVM
{
	public class HybridWebView : WebView
	{
		Action<string> action;

		public static readonly BindableProperty UriProperty = BindableProperty.Create (
			propertyName: "Uri",
			returnType: typeof(string),
			declaringType: typeof(HybridWebView),
			defaultValue: default(string));

        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);
        }
        protected override void OnChildRemoved(Element child)
        {
            base.OnChildRemoved(child);
        }
        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }

        public string Uri {
			get { return (string)GetValue (UriProperty); }
			set { SetValue (UriProperty, value); }
		}


		public string transactionID{ get; internal set; }
        public byte[] Post { get; internal set; }

        public void ActionCalback (CollectionSynchronizationCallback collectoncall)
        {
           var clactioin = collectoncall;
        }
        public void RegisterAction (Action<string> callback)
		{
			action = callback;
		}

        protected override void OnParentSet()
        {
            base.OnParentSet();
        }
        protected override void OnPropertyChanging([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanging(propertyName);
        }
        
        public void Cleanup ()
		{
			action = null;
		}
		public Action<string> MyAction;

		public void LoadUrl(string url)
		{
			var t = (this.Source as HtmlWebViewSource);

			MyAction.Invoke(url);

		}
		public void InvokeAction (string data)
		{
			if (action == null || data == null) {
				return;
			}
			action.Invoke (data);
		}
	}
}
