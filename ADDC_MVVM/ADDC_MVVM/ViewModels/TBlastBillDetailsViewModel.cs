using ADDC_MVVM.Models;
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
   public class TBlastBillDetailsViewModel:ViewModelBase
    {
		public ICommand OnTapMenu { get; set; }
        private LastBillRes lastBillRes;
        private LastBillResp lastBillResp;

        private string _accountNumber;
        public string accountNumber
        {
            get { return _accountNumber; }
            set { SetProperty(ref _accountNumber, value); }
        }

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
        string tokenID = Application.Current.Properties["TokenID"].ToString();
        private string _responseTxt;
        private BillInfo item1;

        public string ResponseTxt
        {
            get { return _responseTxt; }
            set { SetProperty(ref _responseTxt, value); }
        }

        public TBlastBillDetailsViewModel(BillInfo item1)
        {
            this.item1 = item1;
			OnTapMenu = new Command(
			   async () =>
				await App.Current.MainPage.Navigation.PopModalAsync(),
			() => !IsBusy);
            GetLatestBillAsync(item1);

           

    }

        private async void GetLatestBillAsync(BillInfo item1)
        {
           await GetLatestBill(item1);
            if (lastBillRes != null)
            {
                accountNumber = item1.AccountNumber;
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
				previousCharges = lastBillRes.PreviousCharges.ToString();
                currentCycleCharges = lastBillRes.CurrentCycleCharges.ToString();
                OtherCharges = lastBillResp.OtherCharges.ToString();
				AdjustmentsAndCorrection = lastBillResp.AdjustmentsAndCorrection.ToString();
				MunicipalBalanceAmt = lastBillResp.MunicipalBalanceAmt.ToString();
				paymentReceived = lastBillRes.PaymentsReceived.ToString();
                totalAmountDue = lastBillRes.TotalDue.ToString();
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

        private async Task GetLatestBill(BillInfo item1)
        {

            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                IsBusy = true;

                using (var client = new HttpClient(new NativeMessageHandler()))
                {
                    AccountRequest accountRequest = new AccountRequest() { AccountID = item1.AccountNumber };
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
                    CLBillRequest CL_BillRequest = new CLBillRequest() { AccountID = item1.AccountNumber, BillID = lastBillRes.BillID, BillFetchConfiguration = billFetchConfiguration };
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
