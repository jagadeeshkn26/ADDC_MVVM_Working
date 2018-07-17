using ADDC_MVVM.Models;
using ADDC_MVVM.Views;
using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ADDC_MVVM.ViewModels
{
	public class SelectPaymentMethodViewModel : ViewModelBase
    {
        public ICommand SavedCardsCommand { get; set; }
        public ICommand PayAndSaveCommand { get; set; }
        public ICommand PayWithoutSaveCommand { get; set; }
		 public ObservableCollection<GetSavedCardRes> getSavedCrd;
		public ObservableCollection<GetSavedCardRes> getSavedCardRes;
		public ObservableCollection<GetSavedCardRes> getSavedCardResp { get; set; }
		public ObservableCollection<GetSavedCardRes> flterCardRes;//{ get; set; }
		private ObservableCollection<AccountDetailsRes> myFlterList;

		public ICommand btnPayBill { get; set; }

		public ICommand OnTapMenu { get; set; }
        public string personId_;
		public bool _savedCard;

		public bool SavedCard
		{
			get { return _savedCard; }
			set { SetProperty(ref _savedCard, value); }
		}

        public AuthorizePaymentRes authorizePaymentRes { get; set; }

        public  OASetUserDetailsRes oaSetUserDetailsRes { get; set; }

        public SelectPaymentMethodViewModel() { }

        public SelectPaymentMethodViewModel(string personID, ObservableCollection<AccountDetailsRes> myFlterList)
        {
            this.myFlterList = myFlterList;
             personId_ = personID;
			SavedCard = false;
			getSavedCardResp = new ObservableCollection<GetSavedCardRes>();
			 OnTapMenu = new Command(
			  async () => await OnTapMenuCmd(),
			  () => !IsBusy);
			btnPayBill = new Command(
				async () => await SubmitPayment(),
				() => !IsBusy);
			SavedCardsCommand = new Command(
                async () => await getSavedCards(personId_),
                () => !IsBusy);
            PayAndSaveCommand = new Command(
                            async () => await PayAndSaveCards(true),
                            () => !IsBusy);
            PayWithoutSaveCommand = new Command(
                            async () => await PayAndSaveCards(false),
                            () => !IsBusy);

        }
		private async Task OnTapMenuCmd()
		{

			await App.Current.MainPage.Navigation.PopModalAsync();
		}

        async Task getSavedCards(string personId_)
        {
            {
                string requestUrl = "";

                if (IsBusy)
                    return;

                Exception error = null;
                try
                {
					SavedCard = true;
                    IsBusy = true;

                    using (var client = new HttpClient(new NativeMessageHandler()))
                    {

                        GetSavedCardReq parameter = new GetSavedCardReq() { PersonID = personId_ };

                        string jsonParameter = JsonConvert.SerializeObject(parameter);

                        requestUrl = Constants.BaseAddressUrl + "/PaymentService.svc/GetSavedCardsForPerson";

                        client.BaseAddress = new System.Uri(Constants.BaseAddressUrl);

                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

                        var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));

                        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        getSavedCardRes = JsonConvert.DeserializeObject<ObservableCollection<GetSavedCardRes>>(json);

                        Debug.WriteLine(json.ToString());

                        if (json != null)
                        {
							getSavedCrd = new ObservableCollection<GetSavedCardRes>();
							flterCardRes = new ObservableCollection<GetSavedCardRes>();
							if (getSavedCardRes.Count > 5)
							{
								int i = 0;
								foreach (var savedCard in getSavedCardRes)
								{
									if (i < 5)
									{
										getSavedCardResp.Add(savedCard);
										i++;
									}
								}
							}
							else
							{
								foreach (var savedCard in getSavedCardRes)
								{
									
										getSavedCardResp.Add(savedCard);

								}
							}
							//getSavedCardResp = getSavedCrd;
                            //string tokenID = createUserRes.tokenID;
						//await App.Current.MainPage.Navigation.PushModalAsync(new SavedCardsView() { BindingContext = new SavedCardsViewModel(getSavedCardRes, myFlterList) });

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
        async Task PayAndSaveCards(bool saveCard)
        {
            {
                string requestUrl = "";

                if (IsBusy)
                    return;

                Exception error = null;
                try
                {
					SavedCard = false;
                    IsBusy = true;

                    using (var client = new HttpClient(new NativeMessageHandler()))
                    {

                        string tokenID = Application.Current.Properties["TokenID"].ToString();
                        string personID = Application.Current.Properties["PersonID"].ToString();
                        string Total = Application.Current.Properties["Total"].ToString();
                        int total = Int32.Parse(Total);
                       
                            CardInfo cardInfo = new CardInfo()
                            {
                                Brand = "",
                                Name = "",
                                Number = ""
                            };
                            List<BillInfoAuthorise> billInfo = new List<BillInfoAuthorise>();

                            BillInfoAuthorise billIn = new BillInfoAuthorise();
                            foreach (var billinf in myFlterList)
                            {
                                BillInfoAuthorise billInfoAuthorise = new BillInfoAuthorise();
                                billInfoAuthorise.AccountNumber = billinf.AccountID;
                                billInfoAuthorise.Amount = billinf.OutstandingBalance;
                                billInfoAuthorise.FriendPayment = false;
                                // billIn = billInfoAuthorise;
                                billInfo.Add(billInfoAuthorise);
                            }
                            BillInfoCollection billInfoCollection = new BillInfoCollection() { BillInfo = billInfo };
                            CLRegisterPaymentRequest CL_RegisterPaymentRequest = new CLRegisterPaymentRequest()
                            {
                                PersonID = personID,
                                TotalAmount = total,
                                ReturnPath = "https://localhost:52457/Finalize.aspx",
                                SaveCard = saveCard,
                                PaymentMethod = 0,
                                BillInfoCollection = billInfoCollection,
                                CardInfo = cardInfo
                            };
                            AuthPaymentReq parameter2 = new AuthPaymentReq() { CL_RegisterPaymentRequest = CL_RegisterPaymentRequest, token = tokenID };

                            var jsonParameter = JsonConvert.SerializeObject(parameter2);


                            requestUrl = Constants.BaseAddressUrl + "/PaymentService.svc/RegisterPaymentForAccounts";

                        client.BaseAddress = new System.Uri(Constants.BaseAddressUrl);

                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

                        var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));

                        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        var cardResponse = JsonConvert.DeserializeObject<NewCardPaymentReq>(json);

                        await App.Current.MainPage.Navigation.PushModalAsync(new HybridWebViewPage(cardResponse.ReturnPath, cardResponse.TransactionID, cardResponse.OrderID, saveCard));


                        /////////////////////////////////////////////////
                        // await App.Current.MainPage.Navigation.PushAsync(new InAppBrowserXaml(cardResponse.ReturnPath));
                        // Device.OpenUri(new Uri(cardResponse.ReturnPath));
                        Debug.WriteLine(json.ToString());

                        if (json != null)
                        {
                            //string tokenID = createUserRes.tokenID;
                           // await App.Current.MainPage.Navigation.PushAsync(new SavedCardsView() { BindingContext = new SavedCardsViewModel(getSavedCardRes, myFlterList) });

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
        async Task PayWithoutSaveCards()
        {
            {
                string requestUrl = "";

                if (IsBusy)
                    return;

                Exception error = null;
                try
                {
					SavedCard = false;
                    IsBusy = true;

                    using (var client = new HttpClient(new NativeMessageHandler()))
                    {

                        GetSavedCardReq parameter = new GetSavedCardReq() { PersonID = personId_ };

                        string jsonParameter = JsonConvert.SerializeObject(parameter);

                        requestUrl = Constants.BaseAddressUrl + "/PaymentService.svc/GetSavedCardsForPerson";

                        client.BaseAddress = new System.Uri(Constants.BaseAddressUrl);

                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

                        var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));

                        var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                        getSavedCardRes = JsonConvert.DeserializeObject<ObservableCollection<GetSavedCardRes>>(json);

                        Debug.WriteLine(json.ToString());

                        if (json != null)
                        {
                            //string tokenID = createUserRes.tokenID;
                            await App.Current.MainPage.Navigation.PushAsync(new SavedCardsView() { BindingContext = new SavedCardsViewModel(getSavedCardRes, myFlterList) });

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

		// public SavedCardsViewModel(ObservableCollection<GetSavedCardRes> getSavedCard, ObservableCollection<AccountDetailsRes> myFlterList)
		//{
		//	this.myFlterList = myFlterList;


		//}



		private async Task SubmitPayment()
		{

			if (IsBusy)
				return;

			Exception error = null;
			try
			{
				IsBusy = true;
				string tokenID = Application.Current.Properties["TokenID"].ToString();
				string personID = Application.Current.Properties["PersonID"].ToString();
				string Total = Application.Current.Properties["Total"].ToString();
				//int total = Double.TryParse(Total, double);//(Total);
				double total;
				double.TryParse(Total, out total);
				using (var client = new HttpClient(new NativeMessageHandler()))
				{
					CardInfo cardInfo = new CardInfo()
					{
						Brand = flterCardRes[0].Brand,
						Name = flterCardRes[0].Name,
						Number = "1111"
					};
					List<BillInfoAuthorise> billInfo = new List<BillInfoAuthorise>();

					BillInfoAuthorise billIn = new BillInfoAuthorise();
					foreach (var billinf in myFlterList)
					{
						BillInfoAuthorise billInfoAuthorise = new BillInfoAuthorise();
						billInfoAuthorise.AccountNumber = billinf.AccountID;
						billInfoAuthorise.Amount = billinf.OutstandingBalance;
						billInfoAuthorise.FriendPayment = false;
						// billIn = billInfoAuthorise;
						billInfo.Add(billInfoAuthorise);
					}
					BillInfoCollection billInfoCollection = new BillInfoCollection() { BillInfo = billInfo };
					CLRegisterPaymentRequest CL_RegisterPaymentRequest = new CLRegisterPaymentRequest()
					{
						PersonID = personID,
						TotalAmount = total,
						ReturnPath = "https://localhost:52457/Finalize.aspx",
						SaveCard = true,
						PaymentMethod = 0,
						BillInfoCollection = billInfoCollection,
						CardInfo = cardInfo
					};
					AuthPaymentReq parameter2 = new AuthPaymentReq() { CL_RegisterPaymentRequest = CL_RegisterPaymentRequest, token = tokenID };

					var jsonParameter = JsonConvert.SerializeObject(parameter2);
					var requestUrl = Constants.BaseAddressUrl + "/PaymentService.svc/AuthorizePaymentForAccounts";

					client.BaseAddress = new Uri(Constants.BaseAddressUrl);
					client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
					var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
					var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
					Debug.WriteLine(json.ToString());
					if (json != null)
					{
						var responsecls = JsonConvert.DeserializeObject<PayResponse>(json);
						//	var authRes4 = new MyAccountDetails();

						await App.Current.MainPage.Navigation.PushModalAsync(new ReciptPage(responsecls.TransactionID));


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


		//async Task AthorizePayment(string personId)
		//{
		//    {
		//        string requestUrl = "";

		//        if (IsBusy)
		//            return;

		//        Exception error = null;
		//        try
		//        {
		//            IsBusy = true;

		//            using (var client = new HttpClient(new NativeMessageHandler()))
		//            {

		//                AuthorizePaymentReq parameter = new AuthorizePaymentReq() {  };

		//                string jsonParameter = JsonConvert.SerializeObject(parameter);

		//                requestUrl = Constants.BaseAddressUrl + "/PaymentService.svc/AuthorizePaymentForAccounts";

		//                client.BaseAddress = new System.Uri(Constants.BaseAddressUrl);

		//                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

		//                var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

		//                var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));

		//                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

		//                authorizePaymentRes = JsonConvert.DeserializeObject<AuthorizePaymentRes>(json);

		//                Debug.WriteLine(json.ToString());

		//                if (json != null)
		//                {
		//                    //string tokenID = createUserRes.tokenID;

		//                    //if (createUserRes.code == "100")
		//                    //{
		//                    //    IsBusy = false;
		//                    //    await Application.Current.MainPage.DisplayAlert("Thank You", createUserRes.description, "OK");
		//                    //    // await setUserDetails(tokenID);

		//                    //}
		//                }

		//            }
		//        }
		//        catch (Exception ex)
		//        {
		//            Debug.WriteLine("Error: " + ex); //to show Network error...
		//            error = ex;
		//        }
		//        finally
		//        {
		//            IsBusy = false;
		//        }

		//        if (error != null)
		//            await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");

		//    }
		//}

		//async Task getPayWithOutSave(string personId)
		//{
		//    {
		//        string requestUrl = "";

		//        if (IsBusy)
		//            return;

		//        Exception error = null;
		//        try
		//        {
		//            IsBusy = true;

		//            using (var client = new HttpClient(new NativeMessageHandler()))
		//            {

		//                //CreateUserReq parameter = new CreateUserReq() { Pwd = password_, UserID = userName_, EmailID = email };

		//                //string jsonParameter = JsonConvert.SerializeObject(parameter);

		//                //requestUrl = Constants.BaseAddressUrl + "/Userservice.svc/ActivatePortalUser";

		//                //client.BaseAddress = new System.Uri(Constants.BaseAddressUrl);

		//                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

		//                //var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

		//                //var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));

		//                //var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

		//                //createUserRes = JsonConvert.DeserializeObject<OASetUserDetailsRes>(json);

		//                //Debug.WriteLine(json.ToString());

		//                //if (json != null)
		//                //{
		//                //    //string tokenID = createUserRes.tokenID;

		//                //    if (createUserRes.code == "100")
		//                //    {
		//                //        IsBusy = false;
		//                //        await Application.Current.MainPage.DisplayAlert("Thank You", createUserRes.description, "OK");
		//                //        // await setUserDetails(tokenID);

		//                //    }
		//                //}

		//            }
		//        }
		//        catch (Exception ex)
		//        {
		//            Debug.WriteLine("Error: " + ex); //to show Network error...
		//            error = ex;
		//        }
		//        finally
		//        {
		//            IsBusy = false;
		//        }

		//        if (error != null)
		//            await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");

		//    }
		//}
	}
}
