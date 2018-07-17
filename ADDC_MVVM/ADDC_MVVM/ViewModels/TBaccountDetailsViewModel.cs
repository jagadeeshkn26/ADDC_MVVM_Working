using ADDC_MVVM.Models;
using ADDC_MVVM.Views;
using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ADDC_MVVM.ViewModels
{
   public class TBaccountDetailsViewModel:ViewModelBase
    {
		public ICommand OnTapMenu { get; set; }
		public ICommand OnTapACCDet { get; set; }
		public ICommand OnTapBillSum { get; set; }
		public ICommand OnTapPayHis { get; set; }
		public ICommand OneditClicked { get; set; }
		public string aDTxtColor = "";//{ get; set; }
		public string lBTxtColor = "";//{ get; set; }
		public string lPTxtColor = "";// { get; set; }
		public string aDImg = "";//{ get; set; }
		public string lBImg = "";//{ get; set; }
		public string lPImg = "";//{ get; set; }

		bool accDetView = true;
		bool acclastBillView = false;
		bool lastBillView = false;
		bool paymentHisView = false;
		bool _editVis = true;

		public string ADTxtColor
		{
			get { return aDTxtColor; }
			set { SetProperty(ref aDTxtColor, value); }
		}

		public string LBTxtColor
		{
			get { return lBTxtColor; }
			set { SetProperty(ref lBTxtColor, value); }
		}

		public string LPTxtColor
		{
			get { return lPTxtColor; }
			set { SetProperty(ref lPTxtColor, value); }
		}

		public string ADImg
		{
			get { return aDImg; }
			set { SetProperty(ref aDImg, value); }
		}

		public string LBImg
		{
			get { return lBImg; }
			set { SetProperty(ref lBImg, value); }
		}
		public string LPImg
		{
			get { return lPImg; }
			set { SetProperty(ref lPImg, value); }
		}

		public bool AccDetView
		{
			get { return accDetView; }
			set { SetProperty(ref accDetView, value); }
		}
		public bool AccLastBillView
		{
			get { return acclastBillView; }
			set { SetProperty(ref acclastBillView, value); }
		}
		public bool LastBillView
		{
			get { return lastBillView; }
			set { SetProperty(ref lastBillView, value); }
		}
		public bool PaymentHisView
		{
			get { return paymentHisView; }
			set { SetProperty(ref paymentHisView, value); }
		}
		public bool editVis
		{
			get { return _editVis; }
			set { SetProperty(ref _editVis, value); }
		}

		private string _accountNumber;
        public string accountNumber
        {
            get { return _accountNumber; }
            set { SetProperty(ref _accountNumber, value); }
        }

        private string _billCycle;
        public string billCycle
        {
            get { return _billCycle; }
            set { SetProperty(ref _billCycle, value); }
        }

        private string _premiseID;
        public string premiseID
        {
            get { return _premiseID; }
            set { SetProperty(ref _premiseID, value); }
        }

        private string _premiseType;
        public string premiseType
        {
            get { return _premiseType; }
            set { SetProperty(ref _premiseType, value); }
        }

        private string _billPreference;
        public string billPreference
        {
            get { return _billPreference; }
            set { SetProperty(ref _billPreference, value); }
        }

        private string _billingAddress;
        public string billingAddress
        {
            get { return _billingAddress; }
            set { SetProperty(ref _billingAddress, value); }
        }

        private string _poNumber;
        public string poNumber
        {
            get { return _poNumber; }
            set { SetProperty(ref _poNumber, value); }
        }

        private string _tariffType;
        public string tariffType
        {
            get { return _tariffType; }
            set { SetProperty(ref _tariffType, value); }
        }

		// Last bill payment constants 

		private LastBillRes lastBillRes;
		private LastBillResp lastBillResp;


		private string _billNumber;
		public string billNumber
		{
			get
			{
				return _billNumber;
			}
			set
			{
				SetProperty(ref _billNumber, value);
			}
		}
		private string _billDate;
		public string billDate
		{
			get
			{
				return _billDate;
			}
			set
			{
				SetProperty(ref _billDate, value);
			}
		}
		private string _payByDate;
		public string PayByDate
		{
			get
			{
				return _payByDate;
			}
			set
			{
				SetProperty(ref _payByDate, value);
			}
		}
		private string _previousCharges;
		public string previousCharges
		{
			get
			{
				return _previousCharges;
			}
			set
			{
				SetProperty(ref _previousCharges, value);
			}
		}
		private string _currentCycleCharges;
		public string currentCycleCharges
		{
			get
			{
				return _currentCycleCharges;
			}
			set
			{
				SetProperty(ref _currentCycleCharges, value);
			}
		}

		private string _municipalBalanceAmt;
		public string MunicipalBalanceAmt
		{
			get
			{
				return _municipalBalanceAmt;
			}
			set
			{
				SetProperty(ref _municipalBalanceAmt, value);
			}
		}

		private string _adjustmentsAndCorrection;
		public string AdjustmentsAndCorrection
		{
			get
			{
				return _adjustmentsAndCorrection;
			}
			set
			{
				SetProperty(ref _adjustmentsAndCorrection, value);
			}
		}

		private string _otherCharges;
		public string OtherCharges
		{
			get
			{
				return _otherCharges;
			}
			set
			{
				SetProperty(ref _otherCharges, value);
			}
		}

		private string _paymentReceived;
		public string paymentReceived
		{
			get
			{
				return _paymentReceived;
			}
			set
			{
				SetProperty(ref _paymentReceived, value);
			}
		}
		private string _totalAmountDue;
		public string totalAmountDue
		{
			get
			{
				return _totalAmountDue;
			}
			set
			{
				SetProperty(ref _totalAmountDue, value);
			}
		}
		private string _wGunits;
		public string WGunits
		{
			get
			{
				return _wGunits;
			}
			set
			{
				SetProperty(ref _wGunits, value);
			}
		}
		private string _wGamount;
		public string WGamount
		{
			get
			{
				return _wGamount;
			}
			set
			{
				SetProperty(ref _wGamount, value);
			}
		}
		private string _wGtariff;
		public string WGtariff
		{
			get
			{
				return _wGtariff;
			}
			set
			{
				SetProperty(ref _wGtariff, value);
			}
		}
		private string _wRunits;
		public string WRunits
		{
			get
			{
				return _wRunits;
			}
			set
			{
				SetProperty(ref _wRunits, value);
			}
		}
		private string _wRamount;
		public string WRamount
		{
			get
			{
				return _wRamount;
			}
			set
			{
				SetProperty(ref _wRamount, value);
			}
		}
		private string _wRtariff;
		public string WRtariff
		{
			get
			{
				return _wRtariff;
			}
			set
			{
				SetProperty(ref _wRtariff, value);
			}
		}
		private string _eGunits;
		public string EGunits
		{
			get
			{
				return _eGunits;
			}
			set
			{
				SetProperty(ref _eGunits, value);
			}
		}

		private string _eGamount;
		public string EGamount
		{
			get
			{
				return _eGamount;
			}
			set
			{
				SetProperty(ref _eGamount, value);
			}
		}
		private string _eGtariff;
		public string EGtariff
		{
			get
			{
				return _eGtariff;
			}
			set
			{
				SetProperty(ref _eGtariff, value);
			}
		}
		private string _eRunits;
		public string ERunits
		{
			get
			{
				return _eRunits;
			}
			set
			{
				SetProperty(ref _eRunits, value);
			}
		}
		private string _eRamount;
		public string ERamount
		{
			get
			{
				return _eRamount;
			}
			set
			{
				SetProperty(ref _eRamount, value);
			}
		}
		private string _eRtariff;
		public string ERtariff
		{
			get
			{
				return _eRtariff;
			}
			set
			{
				SetProperty(ref _eRtariff, value);
			}
		}


		string tokenID = Application.Current.Properties["TokenID"].ToString();
		private string _responseTxt;
		private AccountDetailsRes item1;

		public string ResponseTxt
		{
			get { return _responseTxt; }
			set { SetProperty(ref _responseTxt, value); }
		}

		//PAyment Constants 
		private string _date;
		public string date
		{
			get
			{
				return _date;
			}
			set
			{
				SetProperty(ref _date, value);
			}
		}
		private string _transactionID;
		public string transactionID
		{
			get
			{
				return _transactionID;
			}
			set
			{
				SetProperty(ref _transactionID, value);
			}
		}

		private string _paidAmount;
		public string paidAmount
		{
			get
			{
				return _paidAmount;
			}
			set
			{
				SetProperty(ref _paidAmount, value);
			}
		}

        private AccountDetailsRes authResAccDet;


        public TBaccountDetailsViewModel(AccountDetailsRes item1)
        {
            this.item1 = item1;
            GetAucountDetailsAsync(item1);
			OnTapMenu = new Command(
			   async () =>
				await App.Current.MainPage.Navigation.PopModalAsync(),
			() => !IsBusy);

			OnTapACCDet = new Command(
				async () => await OnTapACCDetCmd(),
			   () => !IsBusy);

			OnTapBillSum = new Command(
				async () => await OnTapBillSumCmd(),
			   () => !IsBusy);

			OnTapPayHis = new Command(
				async () => await OnTapPayHisCmd(),
			   () => !IsBusy);

			//LoadView();
			 GetLatestBillAsync(item1);
			GetGetPaymentInfoAsync(item1);
			//OneditClicked = new Command(
			//	async () => await App.Current.MainPage.Navigation.PushModalAsync(new EditAccountView()
			//{ BindingContext = new EditAccountViewModel(item1) }),
			//	() => !IsBusy);
			ADTxtColor = "#5e9622";
			ADImg = "acc_details_select";
			LBTxtColor = "Black";
			LBImg = "last_bill_sum_deselect";
			LPTxtColor = "Black";
			LPImg = "last_pay_sum_deselect";
			editVis = true;
		}

		private async Task OnTapACCDetCmd()
		{
			AccDetView = true;
			AccLastBillView = false;
			PaymentHisView = false;
			ADTxtColor = "#5e9622";
			ADImg = "acc_details_select";
			LBTxtColor = "Black";
			LBImg = "last_bill_sum_deselect";
			LPTxtColor = "Black";
			LPImg = "last_pay_sum_deselect";
			editVis = true;
			if (string.IsNullOrEmpty(accountNumber))
			{
				LoadView();
			}
			else
			{
			}

		}

		private async Task OnTapBillSumCmd()
		{
			AccDetView = false;

			PaymentHisView = false;

		AccLastBillView = true;
			ADTxtColor = "Black";
			ADImg = "acc_details_deselect";
			LBTxtColor = "#5e9622";
			LBImg = "last_bill_sum_select";
			LPTxtColor = "Black";
			LPImg = "last_pay_sum_deselect";
			editVis = false;
			if (lastBillRes == null)
			{
				await GetLatestBill(item1);
			}


		}
		private async Task OnTapPayHisCmd()
		{
			AccDetView = false;
			AccLastBillView = false;
			PaymentHisView = true;
			ADTxtColor = "Black";
			ADImg = "acc_details_deselect";
			LBTxtColor = "Black";
			LBImg = "last_bill_sum_deselect";
			LPTxtColor = "#5e9622";
			LPImg = "last_pay_sum_select";
			editVis = false;
			if (string.IsNullOrEmpty(paidAmount))
			{
			await GetGetPaymentInfoList(item1);
			}
				
			//if (paymentHistoryItems.Count < 1)
			//{
			//	await GetpaymentHistoryDetails();
			//}
			//else
			//{
			//}


		}

        private void LoadView()
        {
            if (authResAccDet != null)
            {
                accountNumber = authResAccDet.AccountID;
                billCycle = authResAccDet.BillCycle.MasterData.Value;
                premiseID = authResAccDet.Premises[0].ID;
                premiseType = authResAccDet.Premises[0].Type;
                billPreference = authResAccDet.BillRoute.BillPreference.ToString();
                billingAddress = authResAccDet.Premises[0].Address.City;
				tariffType = authResAccDet.ElectricityMeterCollection.ElectricityMeter[0].ServiceAgreement.TariffType;
            }

            else
            {
                accountNumber = "";
                billCycle = "";
            }
        }

        private async void GetAucountDetailsAsync(AccountDetailsRes item1)
        {
            await GetAucountDetails(item1);
            if (authResAccDet != null)
            {
                LoadView();
            }
        }
        private class AccountReqAcc
        {

            public string token { get; set; }
            public Userreq userreq { get; set; }
        }

        private class Userreq
        {

            public string Item { get; set; }
            public int ItemElementName { get; set; }
        }
        private async Task GetAucountDetails(AccountDetailsRes item1)
        {

            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;

                using (var client = new HttpClient(new NativeMessageHandler()))
                {
                    //Authentication step1
                    Personaccountrequest perReq = new Personaccountrequest() { AccountID = item1.AccountID };
                    // string 
                    AccountReq parameterAccDet = new AccountReq() { personaccountrequest = perReq, token = tokenID };
                    string jsonParameterAccDet = JsonConvert.SerializeObject(parameterAccDet);
                    string requestUrlAccDet = Constants.BaseAddressUrl + "/AccountService.svc/GetAccount";

                    client.BaseAddress = new Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var responseAccDet = await client.PostAsync(requestUrlAccDet, new StringContent(jsonParameterAccDet, Encoding.UTF8, "application/json"));
                    var jsonAccDet = await responseAccDet.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Debug.WriteLine(jsonAccDet.ToString());
                    authResAccDet = JsonConvert.DeserializeObject<AccountDetailsRes>(jsonAccDet);
                    // Application.Current.Properties["TokenID"] = authResAccDet.TokenID;
                    // ResponseTxt = json.ToString();
                    Application.Current.Properties["AccDet"] = authResAccDet;
                    Application.Current.Properties["BillPreference"] = authResAccDet.BillRoute.BillPreference;

                    /////GetPersonMaintenanceDetails
                    Userreq userreq = new Userreq() { Item = Application.Current.Properties["PersonID"].ToString(), ItemElementName = 0 };
                    // string 
                    AccountReqAcc parameterAccDet1 = new AccountReqAcc() { token = tokenID, userreq = userreq };
                    string jsonParameterAccDet1 = JsonConvert.SerializeObject(parameterAccDet1);
                    string requestUrlAccDet1 = Constants.BaseAddressUrl + "/UserService.svc/GetPersonMaintenanceDetails";

                    client.BaseAddress = new Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var responseAccDet1 = await client.PostAsync(requestUrlAccDet1, new StringContent(jsonParameterAccDet1, Encoding.UTF8, "application/json"));
                    var jsonAccDet1 = await responseAccDet1.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Debug.WriteLine(jsonAccDet1.ToString());
                    AuthRes1 authResAccDet1 = JsonConvert.DeserializeObject<AuthRes1>(jsonAccDet1);
                    //Application.Current.Properties["TokenID"] = authResAccDet1.TokenID;
                    ResponseTxt = jsonAccDet.ToString();
                    //poNumber = authResAccDet.AuthResponce..;
                    //tariffType = authResAccDet.AccountID;
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
    
		///Last bil payment Tab


		private async Task GetGetPaymentInfoList(AccountDetailsRes item1)
		{

			if (IsBusy)
				return;

			Exception error = null;
			try
			{
				IsBusy = true;

				using (var client = new HttpClient(new NativeMessageHandler()))
				{
					//Authentication step1
					AccountRequestPay accountRequest = new AccountRequestPay() { AccountID = item1.AccountID, PersonID = Application.Current.Properties["PersonID"].ToString() };
					PageSettings pageSettings = new PageSettings() { PageNumber = "1", PageSize = "12", TotalCount = "10" };
					CLPaymentFilter CL_PaymentFilter = new CLPaymentFilter() { AccountRequest = accountRequest, PageSettings = pageSettings };
					PaymentInfoReq parameterPayInfo = new PaymentInfoReq() { token = tokenID, CL_PaymentFilter = CL_PaymentFilter };
					// string 
					//AccountReq parameterPayInfo = new AccountReq() { personaccountrequest = perReq, token = tokenID };
					string jsonParameterPayInfo = JsonConvert.SerializeObject(parameterPayInfo);
					string requestUrlPayInfo = Constants.BaseAddressUrl + "/BillService.svc/GetPaymentInfoListForAccount";

					client.BaseAddress = new Uri(Constants.BaseAddressUrl);
					client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
					var responsePayInfo = await client.PostAsync(requestUrlPayInfo, new StringContent(jsonParameterPayInfo, Encoding.UTF8, "application/json"));
					var jsonPayInfo = await responsePayInfo.Content.ReadAsStringAsync().ConfigureAwait(false);
					Debug.WriteLine(jsonPayInfo.ToString());
					//string newRes = jsonPayInfo.Replace("\" , "");
					LastPaymentRes authRes1 = JsonConvert.DeserializeObject<LastPaymentRes>(jsonPayInfo);
					ResponseTxt = jsonPayInfo.ToString();
					 if (App.CultureCode == "ar")
					{
						DependencyService.Get<ILocalize>().ChangeLocale("ar");
						//App.CultureCode.
					}
					else
					{
						DependencyService.Get<ILocalize>().SetLocale();
						App.CultureCode = string.Empty;
					}
					var dd = authRes1.PaymentInfo[0].PaymentDate.Day;
					var mm = authRes1.PaymentInfo[0].PaymentDate.Month;
					var yyyy = authRes1.PaymentInfo[0].PaymentDate.Year;
					date = dd + "-" + mm + "-" + yyyy;

					//date = authRes1.PaymentInfo[0].PaymentDate.Date.ToString("dd-MM-yyyy");
					//date = await convertToEnglishDigits(authRes1.PaymentInfo[0].PaymentDate.Date.ToString());

					transactionID = authRes1.PaymentInfo[0].TransactionID;
					paidAmount = authRes1.PaymentInfo[0].PaidAmount.ToString();
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

		public async Task<string> convertToEnglishDigits(string value)
		{
			string newValue = value.Replace("١", "1").Replace("٢", "2").Replace("٣", "3").Replace("٤", "4").Replace("٥", "5")
						.Replace("٦", "6").Replace("٧", "7").Replace("٨", "8").Replace("٩", "9").Replace("٠", "0")
						.Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5")
						.Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9").Replace("۰", "0").Replace("٫", ".");
			return newValue;
		}

		//Last bill payment tab

		     private async void GetLatestBillAsync(AccountDetailsRes item1)
		{
			IsBusy = false;
			await GetLatestBill(item1);

		}
		     private async void GetGetPaymentInfoAsync(AccountDetailsRes item1)
		{
			IsBusy = false;
			await GetGetPaymentInfoList(item1);

		}



		private async Task GetLatestBill(AccountDetailsRes item1)
		{

			if (IsBusy)
				return;

			Exception error = null;
			try
			{
				IsBusy = true;

				using (var client = new HttpClient(new NativeMessageHandler()))
				{
					AccountRequest accountRequest = new AccountRequest() { AccountID = item1.AccountID };
					PageSettings pageSettings = new PageSettings() { PageNumber = "1", PageSize = "5", TotalCount = "10" };
					BillFetchConfiguration billFetchConfiguration = new BillFetchConfiguration() { FetchBillInfo = "true" };
					//Authentication step1
					Billfilter billfilter = new Billfilter() { AccountRequest = accountRequest, PayByDateDesc = "true", PageSettings = pageSettings, BillFetchConfiguration = billFetchConfiguration };
					// string 
					LastBillReq parameter = new LastBillReq() { billfilter = billfilter, token = tokenID };
					string jsonParameter = JsonConvert.SerializeObject(parameter);
					string requestUrl = Constants.BaseAddressUrl + "/AccountService.svc/GetLatestBill";

					client.BaseAddress = new Uri(Constants.BaseAddressUrl);
					client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
					var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
					var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
					Debug.WriteLine(json.ToString());
					lastBillRes = JsonConvert.DeserializeObject<LastBillRes>(json);
					// Application.Current.Properties["TokenID"] = lastBillRes.AuthResponce.TokenID;

					//final bill generate 
					CLBillRequest CL_BillRequest = new CLBillRequest() { AccountID = item1.AccountID, BillID = lastBillRes.BillID, BillFetchConfiguration = billFetchConfiguration };
					GetBillReq parameterLB = new GetBillReq() { token = tokenID, CL_BillRequest = CL_BillRequest };
					string jsonParameterLB = JsonConvert.SerializeObject(parameterLB);
					string requestUrlLB = Constants.BaseAddressUrl + "/BillService.svc/GetBill";

					client.BaseAddress = new Uri(Constants.BaseAddressUrl);
					client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
					var responseLB = await client.PostAsync(requestUrlLB, new StringContent(jsonParameterLB, Encoding.UTF8, "application/json"));
					var jsonLB = await responseLB.Content.ReadAsStringAsync().ConfigureAwait(false);
					Debug.WriteLine(jsonLB.ToString());
					lastBillResp = JsonConvert.DeserializeObject<LastBillResp>(jsonLB);
					// Application.Current.Properties["TokenID"] = lastBillRes.AuthResponce.TokenID;


					ResponseTxt = json.ToString();
					if (lastBillResp != null)
					{
						accountNumber = item1.AccountID;
						billNumber = lastBillRes.BillID;
						var dd = lastBillRes.Date.Day;
						var mm = lastBillRes.Date.Month;
						var yyyy = lastBillRes.Date.Year;
						billDate = dd + "-" + mm + "-" + yyyy;

						//billDate = lastBillRes.Date.ToString("dd-MM-yyyy");

						 dd = lastBillRes.DueDate.Day;
						 mm = lastBillRes.DueDate.Month;
						yyyy = lastBillRes.DueDate.Year;
						PayByDate = dd + "-" + mm + "-" + yyyy;

						//PayByDate = lastBillRes.DueDate.ToString("dd-MM-yyyy");
						previousCharges = lastBillResp.PreviousCharges.ToString();
						currentCycleCharges = lastBillResp.CurrentCycleCharges.ToString();
						OtherCharges = lastBillResp.OtherCharges.ToString();
						AdjustmentsAndCorrection = lastBillResp.AdjustmentsAndCorrection.ToString();
						MunicipalBalanceAmt = lastBillResp.MunicipalBalanceAmt.ToString();
						paymentReceived = lastBillResp.PaymentsReceived.ToString();
						totalAmountDue = lastBillResp.TotalDue.ToString();
						WGunits = lastBillResp.WaterConsumption.GreenCosumption.ToString();
						WGamount = lastBillResp.WaterConsumption.GreenCharges.ToString();
						WGtariff = lastBillResp.WaterConsumption.GreenTariff.ToString();
						WRunits = lastBillResp.WaterConsumption.RedConsumption.ToString();
						WRamount = lastBillResp.WaterConsumption.RedCharges.ToString();
						WRtariff = lastBillResp.WaterConsumption.RedTariff.ToString();
						EGunits = lastBillResp.ElectricityConsumption.GreenCosumption.ToString();
						EGamount = lastBillResp.ElectricityConsumption.GreenCharges.ToString();
						EGtariff = lastBillResp.ElectricityConsumption.GreenTariff.ToString();
						ERunits = lastBillResp.ElectricityConsumption.RedConsumption.ToString();
						ERamount = lastBillResp.ElectricityConsumption.RedCharges.ToString();
						ERtariff = lastBillResp.ElectricityConsumption.RedTariff.ToString();
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
}
