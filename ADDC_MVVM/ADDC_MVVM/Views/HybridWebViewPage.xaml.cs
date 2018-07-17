using System;
using ADDC_MVVM.Interfaces;
using ADDC_MVVM.Models;
//using Org.Apache.Http.Util;
using Xamarin.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Net.Http;
using ModernHttpClient;
using Newtonsoft.Json;
using System.Text;
using System.Collections.ObjectModel;
using ADDC_MVVM.ViewModels;

namespace ADDC_MVVM.Views
{
	public partial class HybridWebViewPage : ContentPage , webCallBack
	{
        private string returnPath;
        private string transactionID;
        private string orderID;
        private bool savedCard;

        private webCallBack currentLocationService;

        public event EventHandler<WebResp> positionChanged;

        private void OnPositionChange(object sender, WebResp e)
        {
            Debug.WriteLine("Got the update in ContentPage from service ");
        }

        public HybridWebViewPage()
        {



        }
        public HybridWebViewPage(string returnPath, string transactionID , string orderID, bool savedCard)
        {
            InitializeComponent();
            this.returnPath = returnPath;
            this.transactionID = transactionID;
            this.orderID = orderID;
            this.savedCard = savedCard;
            Application.Current.Properties["savedCard"] = savedCard;
            Application.Current.Properties["transactionID"] = transactionID;
            Application.Current.Properties["orderID"] = orderID;
            hybridWebView.Uri = returnPath;
            //byte[] post = EncodingUtils.GetBytes("TransactionID=" + transactionID, "BASE64");
            hybridWebView.transactionID = transactionID;
			//hybridWebView.Post = post;

            //var currentLocationService = DependencyService.Get<webCallBack>();
            //currentLocationService.positionChanged += OnPositionChange;
           // LocationService.positionChanged += LocationService_positionChanged;
                //  return currentLocationService;
            // hybridWebView.BindingContextChanged += HybridWebView_BindingContextChanged;
            ///hybridWebView.PropertyChanged += HybridWebView_PropertyChanged;
        }

        private void LocationService_positionChanged(object sender, WebResp e)
        {
            Debug.WriteLine("Got the update in ContentPage from service ");
        }

        public webCallBack LocationService
{
    get
	{
		
			currentLocationService = DependencyService.Get<webCallBack>();
			currentLocationService.positionChanged += OnPositionChange;
		
		return currentLocationService;
	}
   

}
        public async void GetResp(string test)
        {
            Exception error = null;
            try
            {
             //   hybridWebView = new HybridWebView();
                Debug.WriteLine("Got the update in ContentPage from service ");
               // hybridWebView.IsVisible = false;
              //  OnBackButtonPressed();
                await FinalPAyment();
            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error: " + ex); //to show Network error...
                error = ex;
            }
            

        }

        async Task FinalPAyment()
        {
            {
                string requestUrl = "";
                savedCard= Convert.ToBoolean(Application.Current.Properties["savedCard"].ToString())  ;
                transactionID = Application.Current.Properties["transactionID"].ToString() ;
                orderID =  Application.Current.Properties["orderID"].ToString() ;
                if (IsBusy)
                    return;

                Exception error = null;
                try
                {
                    IsBusy = true;

                    using (var client = new HttpClient(new NativeMessageHandler()))
                    {
                        CLFinalisePaymentRequest CL_FinalisePaymentRequest = new CLFinalisePaymentRequest() { TransactionID = transactionID, SaveCard = savedCard, OrderID = orderID };
                        FinalPaymentReq parameter = new FinalPaymentReq() { CL_FinalisePaymentRequest = CL_FinalisePaymentRequest  , token = Application.Current.Properties["TokenID"].ToString()};

                        string jsonParameter = JsonConvert.SerializeObject(parameter);

                        requestUrl = Constants.BaseAddressUrl + "/PaymentService.svc/FinalizePaymentForAccounts";

                        client.BaseAddress = new System.Uri(Constants.BaseAddressUrl);

                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

                        var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));

                        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                      //  getSavedCardRes = JsonConvert.DeserializeObject<ObservableCollection<GetSavedCardRes>>(json);

                        Debug.WriteLine(json.ToString());

                        if (json != null)
                        {
                            var authRes4 = new MyAccountDetails();
                            await App.Current.MainPage.Navigation.PushModalAsync(new MyAccountView() { BindingContext = new MyAccountViewModel() });

                            //string tokenID = createUserRes.tokenID;


                            //if (createUserRes.code == "100")
                            //{
                            //    IsBusy = false;
                            //    await Application.Current.MainPage.DisplayAlert("Thank You", createUserRes.description, "OK");
                            //    // await setUserDetails(tokenID);

                            //}
                        }

                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error: " + ex); //to show Network error...
                    error = ex;
                }
                finally
                {
                    IsBusy = false;
                }

                if (error != null)
                    await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");

            }



        }

        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);
        }
        protected override void OnParentSet()
        {
            base.OnParentSet();
        }
        void webOnEndNavigating(object sender, WebNavigatedEventArgs e)
        {
            if (hybridWebView.Uri != null && hybridWebView.Uri.Contains("https://localhost:52457/Finalize.aspx"))
            {

            }
        }

        public void start()
        {
            throw new NotImplementedException();
        }
    }
}
