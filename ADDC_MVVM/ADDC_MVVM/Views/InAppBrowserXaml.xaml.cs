using ADDC_MVVM.Models;
using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
	public partial class InAppBrowserXaml : ContentPage
	{
        private string transactionID;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebViewSample.InAppBrowserXaml"/> class.
        /// Takes a URL indicating the starting page for the browser control.
        /// </summary>
        /// <param name="URL">URL to display in the browser.</param>
        public InAppBrowserXaml(string URL)
		{
			InitializeComponent ();
			
            // webView.SetWebViewClient(client);
            // byte[] post = EncodingUtils.getBytes("TransactionID=" + transactionid, "BASE64");
            // webView.GetSettings().setJavaScriptEnabled(true);
            //webView.postUrl(url, post);

            //  AuthPaymentReq parameter2 = new AuthPaymentReq() { CL_RegisterPaymentRequest = CL_RegisterPaymentRequest, token = tokenID };
            using (var client = new HttpClient(new NativeMessageHandler()))
            {

                byte[] post = Encoding.UTF8.GetBytes("TransactionID=" + transactionID);
				post = Encoding.UTF8.GetBytes("BASE64");
				var jsonParameter = JsonConvert.SerializeObject(post);


                var requestUrl = Constants.BaseAddressUrl + "/PaymentService.svc/RegisterPaymentForAccounts";

                 client.BaseAddress = new System.Uri(Constants.BaseAddressUrl);

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                // var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
                var html = new HtmlWebViewSource
                {
                    Html = URL
                };
                // webView.BindingContext = post;//, Encoding.UTF8, "application/json");
                // webView.BindingContext = Encoding.UTF8;
                // webView.BindingContext = "application/json";
                bool useHtml = true;
                webView.Source = html;// +"?"+ post;
               // webView.SetValue(SetValue,)
               // webView.Source=(string.Format("javascript: Draw({0})", color));
            }
        }


        /// <summary>
        /// fired when the back button is clicked. If the browser can go back, navigate back.
        /// If the browser can't go back, leave the in-app browser page.
        /// </summary>
        void backButtonClicked (object sender, EventArgs e)
		{
			if (webView.CanGoBack) {
				webView.GoBack ();
			} else {
				this.Navigation.PopAsync (); // closes the in-app browser view.
			}
		}

		/// <summary>
		/// Navigates forward
		/// </summary>
		void forwardButtonClicked(object sender, EventArgs e)
		{
			if (webView.CanGoForward) {
				webView.GoForward ();
			}
		}
	}
}

