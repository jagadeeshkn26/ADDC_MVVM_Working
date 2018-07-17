using System;
using System.IO;
using ADDC_MVVM;
using ADDC_MVVM.iOS;
using ADDC_MVVM.Views;
using Foundation;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HybridWebView), typeof(HybridWebViewRenderer))]
namespace ADDC_MVVM.iOS
{
    public class HybridWebViewRenderer : ViewRenderer<HybridWebView, WKWebView>, IWKScriptMessageHandler
    {
        const string JavaScriptFunction = "function invokeCSharpAction(data){window.webkit.messageHandlers.invokeAction.postMessage(data);}";
        WKUserContentController userController;

        string htmlstringnew;
        NSUrl url;
        protected override void OnElementChanged(ElementChangedEventArgs<HybridWebView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                userController = new WKUserContentController();
                var script = new WKUserScript(new NSString(JavaScriptFunction), WKUserScriptInjectionTime.AtDocumentEnd, false);
                userController.AddUserScript(script);
                userController.AddScriptMessageHandler(this, "invokeAction");

                var config = new WKWebViewConfiguration { UserContentController = userController };
                var webView = new WKWebView(Frame, config);
                webView.NavigationDelegate = new NavigationDelegate();

                url = new NSUrl(Element.Uri);

                NSMutableUrlRequest req = new NSMutableUrlRequest(url);

                NSObject postObj = FromObject("TransactionID=" + Element.transactionID);

                NSString postString = (NSString)postObj;

                req.HttpMethod = "POST";
                NSData postData = postString.Encode(NSStringEncoding.UTF8);

                htmlstringnew = string.Format(@"<html><head></head><body 
                onload=""setTimeout('document.MyPaymentForm.submit()',1000);""><form name=""MyPaymentForm"" method=""POST"" action= ""{0}"" >Connecting to payment gateway....<input name=""TransactionID"" type=""hidden"" value= ""{1}""></form></body></html>", Element.Uri, Element.transactionID);
                
                webView.LoadData(htmlstringnew, "text/html", "UTF-8", url);
                var ul = webView.Url;
                SetNativeControl(webView);
            }
            if (e.OldElement != null)
            {
                userController.RemoveAllUserScripts();
                userController.RemoveScriptMessageHandler("invokeAction");
                var hybridWebView = e.OldElement as HybridWebView;
                hybridWebView.Cleanup();
            }
            if (e.NewElement != null)
            { }

        }

        public void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
        {
            throw new NotImplementedException();
        }
    }

    public class NavigationDelegate : NSObject, IWKNavigationDelegate
    {
        [Export("webView:didFinishNavigation:")]
        public async void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
        {
            var content = await webView.EvaluateJavaScriptAsync("(function() { return ('<html>'+document.getElementsByTagName('html')[0].innerHTML+'</html>'); })();");
            var html = FromObject(content);
            Console.WriteLine((html.ToString()).Substring(0, 40));
        }
        [Export("webView:didFailNavigation:withError:")]
        public void DidFailNavigation(WKWebView webView, WKNavigation navigation, NSError error)
        {
            // If navigation fails, this gets called
            Console.WriteLine("DidFailNavigation");
        }

        [Export("webView:didFailProvisionalNavigation:withError:")]
        public void DidFailProvisionalNavigation(WKWebView webView, WKNavigation navigation, NSError error)
        {
            // If navigation fails, this gets called
            Console.WriteLine("DidFailProvisionalNavigation");
        }

        [Export("webView:didStartProvisionalNavigation:")]
        public void DidStartProvisionalNavigation(WKWebView webView, WKNavigation navigation)
        {
            // When navigation starts, this gets called
            string url = webView.Url.ToString();
            if (url == "https://localhost:52457/Finalize.aspx")
            {
                HybridWebViewPage hyPage = new HybridWebViewPage();
                hyPage.GetResp(url);
                //webView.endDestroy();
                webView.GoBack();


            }
            Console.WriteLine("DidStartProvisionalNavigation");
        }
    }
}
