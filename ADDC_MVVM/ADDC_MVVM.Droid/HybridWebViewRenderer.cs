using Android.Webkit;
using ADDC_MVVM;
using Org.Apache.Http.Util;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ADDC_MVVM.Models;
using System;
using Android.Graphics;
using Android.Views;
using System.ComponentModel;
using ADDC_MVVM.Droid.IntClass;
using ADDC_MVVM.Droid;
using ADDC_MVVM.Views;

[assembly: ExportRenderer (typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace ADDC_MVVM.Droid
{
    public class HybridWebViewRenderer : ViewRenderer<HybridWebView, global::Android.Webkit.WebView>
    {
        const string JavaScriptFunction = "function invokeCSharpAction(data){jsBridge.invokeAction(data);}";
        public HybridWebView FormsWebViewItem { get { return Element as HybridWebView; } }
        public global::Android.Webkit.WebView webView = new global::Android.Webkit.WebView(Forms.Context);

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
        {
            base.OnElementChanged(e);
            // string url = "https://demo-ipg.comtrust.ae/Payment/PaymentPartner.aspx?lang=en&layout=C0BSTCBLEI";

            if (Control == null)
            {
                webView = new global::Android.Webkit.WebView(Forms.Context);
                webView.SetWebViewClient(new FormsWebViewClient(this, FormsWebViewItem));
                webView.Settings.JavaScriptEnabled = true;//
                byte[] post = EncodingUtils.GetBytes("TransactionID=" + Element.transactionID, "BASE64");
				webView.PostUrl(Element.Uri, post);

				webView.Settings.JavaScriptEnabled = true;
                
                webView.FocusChange += WebView_FocusChange;
                webView.ScrollChange += WebView_ScrollChange;
                webView.LayoutChange += WebView_LayoutChange;
                SetNativeControl(webView);
            }
            if (e.OldElement != null)
            {
                Control.RemoveJavascriptInterface("jsBridge");
                var hybridWebView = e.OldElement as HybridWebView;
                hybridWebView.Cleanup();
            }
            if (e.NewElement != null)
            {
                Control.AddJavascriptInterface(new JSBridge(this), "jsBridge");
                Control.LoadUrl(string.Format("https://", Element.Uri));
                InjectJS(JavaScriptFunction);
            }
        }

        private void WebView_LayoutChange(object sender, LayoutChangeEventArgs e)
        {
            if (webView.Url != null && webView.Url.Contains("https://localhost:52457/Finalize.aspx"))
            {
                //string pos = ""; 
                //pos= "Finally value is updated";
                //WebCallBack.mySelf.receivedNewPosition(pos);

            }
        }

        private void WebView_ScrollChange(object sender, ScrollChangeEventArgs e)
        {
            if (webView.Url != null && webView.Url.Contains("https://localhost:52457/Finalize.aspx"))
            {
                
                return;
                
            }

        }

        private void WebView_FocusChange(object sender, FocusChangeEventArgs e)
        {
            if (webView.Url != null && webView.Url.Contains("https://localhost:52457/Finalize.aspx"))
            {

            }
        }

        private void WebView_Find(object sender, global::Android.Webkit.WebView.FindEventArgs e)
        {
            var test = e.ActiveMatchOrdinal;
        }
       
        public override void OnViewAdded(global::Android.Views.View child)
        {
            base.OnViewAdded(child);
        }
        public override void OnViewRemoved(global::Android.Views.View child)
        {
            base.OnViewRemoved(child);
        }
        protected override void OnFinishInflate()
        {
            base.OnFinishInflate();
        }
        void InjectJS(string script)
        {
            if (Control != null)
            {
                Control.LoadUrl(string.Format("javascript: {0}", script));
            }
        }

        private class FormsWebViewClient : WebViewClient
        {
            private object formsWebViewItem;
            private HybridWebViewRenderer hybridWebViewRenderer;
            webCallBackAnd webCallBack1;
            public FormsWebViewClient(HybridWebViewRenderer hybridWebViewRenderer, object formsWebViewItem)
            {
                this.hybridWebViewRenderer = hybridWebViewRenderer;
                this.formsWebViewItem = formsWebViewItem;
                webCallBack1 = new webCallBackAnd();
                webCallBack1.start();
            }
            public override void OnPageFinished(global::Android.Webkit.WebView view, string url)
            {
                Console.WriteLine("Finished =" + url);
                if (url.Contains("https://localhost:52457/Finalize.aspx"))
                {
                    HybridWebViewPage hyPage = new HybridWebViewPage();
                    hyPage.GetResp(url);
                     view.Destroy();
                    view.GoBack();
                   
                 
                }
                else
                {
                    // base.OnPageFinished(view, url);
                }

            }
            
          

            public override void OnPageStarted(global::Android.Webkit.WebView view, string url, Bitmap favicon)
            {
                Console.WriteLine("Started=" + url);
                if (url.Contains("https://localhost:52457/Finalize.aspx"))
                {
                    //if (WebCallBack.mySelf != null)
                    //{
                    //    string pos = "";
                    //    pos = "Finally value is updated";
                    //    WebCallBack.mySelf.receivedNewPosition(pos);
                    //}

                }
                else
                {
                    //  base.OnPageStarted(view, url, favicon);
                }

            }
        }
    }
}
