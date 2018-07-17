using ADDC_MVVM.Resx;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ADDC_MVVM.Views;

namespace ADDC_MVVM.ViewModels
{
    public class TariffInformationViewModel : ViewModelBase
    {
        public string tSlabImg = "";//{ get; set; }
        public string tCalcImg = "";//{ get; set; }

        public string tCalc2016;
        public string tCalc2017;

        public string tCalcWater;
        public string tCalcElec;
        


        public string currYear = "2016";
        public string currentStatus = "National"; //Expat

        private string tariff_cubic_per_day_com;
        private string tariff_cubic_per_day_res;
        private string tariff_uae_green_water_units;
        private string tariff_uae_red_water_units;

        private string tariff_uae_green_elec_units;
        private string tariff_uae_red_elec_units;
        private string tariff_uae_home_elec_units;
        private string tariff_uae_com_elec_units;


        public string tSlabColor = "";//{ get; set; }
        public string tCalcColor = "";//{ get; set; }

        public string tabImgEx = "";//{ get; set; }
        public string tabImgUAE = "";//{ get; set; }

        public string tSlab2016 = "";//{ get; set; }
        public string tSlab2017 = "";//{ get; set; }

        public string numdays = "";
        public string consumptionUnits="";
        public string total = "";
        public string greenUnits = "";
        public string redUnits = "";

        public bool _totalVisible = false;
        public bool _paymentsVisible = false;
        public bool _tariffCalculator = false;
        public bool _tariffSlab = true;
        public bool _isSocialSelected = false;
        public bool _isUnmeterSelected = false;
        private string waterNumdays, waterCompAmt;
        private int waterNumdaysVal, waterCompAmtVal;

        private string currentYearCalc="2016";
        private string socialCard = "No";
        private string unmetered = "Yes";
        private string servSelected = "water";



        double waterGreenLimit, waterRedLimit, waterGreenTariffAmt,waterRedTariffAmt;
        double elecGreenLimit, elecRedLimit, elecGreenTariffAmt, elecRedTariffAmt;

        double unitWaterGreenLimit, unitWaterGreenTariff, unitWaterRedTariff;

        double unitElecGreenLimit, unitElecGreenTariff, unitElecRedTariff;

        private string units;

        public ICommand OnTapTariffSlab { get; set; }
        public ICommand OnTapTariffCalc { get; set; }
		public ICommand OnSwitchClicked { get; set; }

        public ICommand OnTap2016 { get; set; }
        public ICommand OnTap2017 { get; set; }

        public ICommand OnTapNationals { get; set; }
        public ICommand OnTapExpats { get; set; }

        public ICommand OnTapCalc2016 { get; set; }
        public ICommand OnTapCalc2017 { get; set; }

        public ICommand OnTapTCalcWater { get; set; }
        public ICommand OnTapTCalcElec { get; set; }

        public ICommand OnCalculate { get; set; }
        public ICommand OnTapMenu { get; set; }
        public ICommand onTariffChart { get; set; }

        //    TCalc2016
        //}"   Command="{Binding OnTapCalc2016}"/> categoryType

        public ObservableCollection<string> primiseType { get; set; }

        public ObservableCollection<string> categoryType { get; set; }

        private string waterPremiseType, waterCateType ;
		private string _cUnits = "true";

				public string CUnits
		{
			get { return _cUnits; }
			set { SetProperty(ref _cUnits, value); }

		}
		public string TSlabColor
        {
            get { return tSlabColor; }
            set { SetProperty(ref tSlabColor, value); }

        }
        public string Tariff_cubic_per_day_com
        {
            get { return tariff_cubic_per_day_com; }
            set { SetProperty(ref tariff_cubic_per_day_com, value); }
        }
        public string Tariff_cubic_per_day_res
        {
            get { return tariff_cubic_per_day_res; }
            set { SetProperty(ref tariff_cubic_per_day_res, value); }
        }
        public string Tariff_uae_green_water_units
        {
            get { return tariff_uae_green_water_units; }
            set { SetProperty(ref tariff_uae_green_water_units, value); }
        }
        public string Tariff_uae_red_water_units
        {
            get { return tariff_uae_red_water_units; }
            set { SetProperty(ref tariff_uae_red_water_units, value); }
        }
        public string Tariff_uae_green_elec_units
        {
            get { return tariff_uae_green_elec_units; }
            set { SetProperty(ref tariff_uae_green_elec_units, value); }
        }
        public string Tariff_uae_red_elec_units
        {
            get { return tariff_uae_red_elec_units; }
            set { SetProperty(ref tariff_uae_red_elec_units, value); }
        }
        public string Tariff_uae_home_elec_units
        {
            get { return tariff_uae_home_elec_units; }
            set { SetProperty(ref tariff_uae_home_elec_units, value); }
        }
        public string Tariff_uae_com_elec_units
        {
            get { return tariff_uae_com_elec_units; }
            set { SetProperty(ref tariff_uae_com_elec_units, value); }
        }

        public string TCalcColor
        {
            get { return tCalcColor; }
            set { SetProperty(ref tCalcColor, value); }
        }

        public string TSlab2016
        {
            get { return tSlab2016; }
            set { SetProperty(ref tSlab2016, value); }
        }
        
        public string TSlab2017
        {
            get { return tSlab2017; }
            set { SetProperty(ref tSlab2017, value); }
        }
        public string TCalc2016
        {
            get { return tCalc2016; }
            set { SetProperty(ref tCalc2016, value); }
        }

        public string TCalc2017
        {
            get { return tCalc2017; }
            set { SetProperty(ref tCalc2017, value); }
        }
        public string TCalcWater
        {
            get { return tCalcWater; }
            set { SetProperty(ref tCalcWater, value); }
        }

        public string TCalcElec
        {
            get { return tCalcElec; }
            set { SetProperty(ref tCalcElec, value); }
        }
        public string TSlabImg
        {
            get { return tSlabImg; }
            set { SetProperty(ref tSlabImg, value); }
        }

        public string TCalcImg
        {
            get { return tCalcImg; }
            set { SetProperty(ref tCalcImg, value); }
        }

        public string TabImgEx
        {
            get { return tabImgEx; }
            set { SetProperty(ref tabImgEx, value); }
        }

        public string TabImgUAE
        {
            get { return tabImgUAE; }
            set { SetProperty(ref tabImgUAE, value); }
        }

        public string Numdays
        {
            get { return numdays; }
            set { SetProperty(ref numdays, value); }
        }

        public string ConsumptionUnits
        {
            get { return consumptionUnits; }
            set { SetProperty(ref consumptionUnits, value); }
        }

        public string Total
        {
            get { return total; }
            set { SetProperty(ref total, value); }
        }
        public string Units
        {
            get { return units; }
            set { SetProperty(ref units, value); }
        }
        public string GreenUnits
        {
            get { return greenUnits; }
            set { SetProperty(ref greenUnits, value); }
        }
        public bool TotalVisible
        {
            get { return _totalVisible; }
            set { SetProperty(ref _totalVisible, value); }
        }

        public bool PaymentsVisible
        {
            get { return _paymentsVisible; }
            set { SetProperty(ref _paymentsVisible, value); }
        }
        public bool TariffCalculator
        {
            get { return _tariffCalculator; }
            set { SetProperty(ref _tariffCalculator, value); }
        }
        
         public bool TariffSlab
        {
            get { return _tariffSlab; }
            set { SetProperty(ref _tariffSlab, value); }
        }
        public bool IsSocialSelected
        {
            get { return _isSocialSelected; }
            set { SetProperty(ref _isSocialSelected, value); }
        }

        public bool IsUnmeterSelected
        {
            get { return _isUnmeterSelected; }
            set { SetProperty(ref _isUnmeterSelected, value); }
        }

        public string RedUnits
        {
            get { return redUnits; }
            set { SetProperty(ref redUnits, value); }
        }

        private string _primiseName;
        public string PrimiseName
        {
            get { return _primiseName; }
            set { SetProperty(ref _primiseName, value); }
        }


        private string categoryName;
        public string CategoryName
        {
            get { return categoryName; }
            set { SetProperty(ref categoryName, value); }
        }

        public TariffInformationViewModel() {


            TCalcColor = "#545b66";
            TCalcImg = "ic_action_deselect";

            TSlabColor = "#5e9622";
            TSlabImg = "ic_action_selected_tariff";

            TabImgUAE = "tab.png";
            TabImgEx = "";

            TSlab2016 = "#D0E766";
            TSlab2017 = "#E7F1C1";

            TCalc2016 = "#D0E766"; 
            TCalc2017 = "#E7F1C1";

            TCalcWater = "#D0E766";
            TCalcElec =  "#E7F1C1";

			Units = AppResource.traiff_water_units;

            Tariff_cubic_per_day_com = AppResource.tariff_cubic_per_day_com;
            Tariff_cubic_per_day_res = AppResource.tariff_cubic_per_day_res;
            Tariff_uae_green_water_units = AppResource.tariff_uae_green_water_units;
            Tariff_uae_red_water_units = AppResource.tariff_uae_red_wter_units;

            Tariff_uae_green_elec_units = AppResource.tariff_uae_green_elec_units; 
            Tariff_uae_red_elec_units = AppResource.tariff_uae_red_elec_units;
            Tariff_uae_home_elec_units = AppResource.tariff_uae_home_elec_units;
            Tariff_uae_com_elec_units = AppResource.tariff_uae_com_elec_units;

            primiseType = new ObservableCollection<string>();
            primiseType.Add(AppResource.traiff_premise_type_0);
            primiseType.Add(AppResource.traiff_premise_type_1);
            // primiseType.Add(AppResource.traiff_premise_type_2);
            //

            categoryType = new ObservableCollection<string>();
            categoryType.Add(AppResource.traiff_cate_type_0);
            categoryType.Add(AppResource.traiff_cate_type_1);
            //categoryType.Add(AppResource.traiff_cate_type_2);

            CategoryName = AppResource.traiff_cate_type_0;
            PrimiseName = AppResource.traiff_premise_type_0;
			//CUnits = "true";


			// Units= AppResource.traiff_water_units;
			CUnits = "true";
			OnTapTariffSlab = new Command(
                async () => await OnTapSlab(),
               () => !IsBusy);

            OnTapMenu = new Command(
                async () => await App.Current.MainPage.Navigation.PopModalAsync(),
                () => !IsBusy);

            OnTapTariffCalc = new Command(
                async () => await OnTapCalc(),
               () => !IsBusy);

            OnTapExpats = new Command(
                async () => await OnTapExpatsDesp(),
               () => !IsBusy);

            OnTapNationals = new Command(
                async () => await OnTapNationalsDesp(),
               () => !IsBusy);
            OnTap2016 = new Command(
			   async () => await OnTap2016sDesp(),
			  () => !IsBusy);
			 OnSwitchClicked = new Command(
				async () => await OnSwitchClick(),
			 () => !IsBusy);
			
            OnTap2017 = new Command(
                async () => await OnTap2017Desp(),
               () => !IsBusy);

            OnTapCalc2016 = new Command(
              async () => await OnTapCalc2016Desp(),
             () => !IsBusy);

            OnTapCalc2017 = new Command(
                async () => await OnTapCalc2017Desp(),
               () => !IsBusy);
            OnTapTCalcWater = new Command(
              async () => await OnTapTCalcWaterDesp(),
             () => !IsBusy);

            OnTapTCalcElec = new Command(
                async () => await OnTapTCalcElecDesp(),
               () => !IsBusy);
            OnCalculate = new Command(
                async () => await OnTapOnCalculateDesp(),
               () => !IsBusy);

            onTariffChart = new Command(
               async () => await OnTaponTariffChart(),
              () => !IsBusy);
        }

		private async Task OnSwitchClick()
		{
			if (IsUnmeterSelected)
			{
				unmetered = "Yes";

			}
			else
			{
				unmetered = "No";

			}
		}

		public static string DoFormat(double myNumber)
        {
            var s = string.Format("{0:0.00}", myNumber);

            //if (s.EndsWith("00"))
            //{
            //    return ((int)myNumber).ToString();
            //}
            //else
            //{
                return s;
            //}
        }

        private async Task OnTapOnCalculateDesp()
        {
			if (IsSocialSelected)
			{
				socialCard = "Yes";
			}
			else
			{
				socialCard = "No";
			}

			if (IsUnmeterSelected)
			{
				unmetered = "Yes";

			}
			else
			{
				unmetered = "No";
				 
			}

            if (unmetered.Equals("Yes") && servSelected.Equals("water"))
            {
                waterNumdays = Numdays.ToString();
                 if ((!waterNumdays.Equals("")))
                {
					waterNumdaysVal = Int32.Parse(waterNumdays);

					double unmetreAmt = 0.0d;
                    if ((currentYearCalc.Equals("2017")))
                    {
                        unmetreAmt = waterNumdaysVal * 5;
                    }
                    else
                    {
                        unmetreAmt = waterNumdaysVal * 3;
                    }

                    //decimal totDouble = Math.Round(unmetreAmt, 2);
                    string totalUnits = DoFormat(unmetreAmt);
                    Total = ("" + "AED " + totalUnits);
                    TotalVisible = true;
                    PaymentsVisible = false;
					var tarrif = new TariffInformation();
					tarrif.setFocus();
                    //totalDetails.setVisibility(View.VISIBLE);
                    //if (paymentDetails.isShown())
                    //    paymentDetails.setVisibility(View.GONE);

                }
                else
                {
                    //Toast.makeText(mActivity, getResources().getString(R.string.str_mandatory_feilds_myprofile), Toast.LENGTH_LONG).show();
                    //Disply Alert for mandatory feilds
                }



            }
            else {

                waterNumdays = Numdays.ToString();
                

                waterCompAmt = ConsumptionUnits.ToString();
               

                if (servSelected.Equals("water"))
                {

                    if ((!waterNumdays.Equals("") && !waterCompAmt.Equals("")))
                    {
						waterNumdaysVal = Int32.Parse(waterNumdays);
						waterCompAmtVal = Int32.Parse(waterCompAmt);
                        //waterNumdays = Numdays.ToString();
                        //waterNumdaysVal = Int32.Parse(waterNumdays);

                        // Residential-nationals
                        if (CategoryName.Equals(AppResource.traiff_cate_type_0))
                        {

                            if (PrimiseName.Equals(AppResource.traiff_premise_type_0))
                            {

                                //Residential-nationals and flat 
                                if (currentYearCalc.Equals("2016"))
                                {
                                    if (socialCard.Equals("Yes"))
                                    {
                                        unitWaterGreenLimit = Constants.WATER_UNIT_UAE_NATIONAL_FLAT_GREEN_LIMIT_16_SC; // values
                                        unitWaterGreenTariff = Constants.WATER_UNIT_UAE_NATIONAL_FLAT_GREEN_TARIFF_16_SC;
                                        unitWaterRedTariff = Constants.WATER_UNIT_UAE_NATIONAL_FLAT_RED_TARIFF_16_SC;
                                    }
                                    else
                                    {
                                        unitWaterGreenLimit = Constants.WATER_UNIT_UAE_NATIONAL_FLAT_GREEN_LIMIT; // values
                                        unitWaterGreenTariff = Constants.WATER_UNIT_UAE_NATIONAL_FLAT_GREEN_TARIFF;
                                        unitWaterRedTariff = Constants.WATER_UNIT_UAE_NATIONAL_FLAT_RED_TARIFF;
                                    }
                                }
                                else if (currentYearCalc.Equals("2017"))
                                {
                                    if (socialCard.Equals("Yes"))
                                    {
                                        unitWaterGreenLimit = Constants.WATER_UNIT_UAE_NATIONAL_FLAT_GREEN_LIMIT_17_SC; // values
                                        unitWaterGreenTariff = Constants.WATER_UNIT_UAE_NATIONAL_FLAT_GREEN_TARIFF_17_SC;
                                        unitWaterRedTariff = Constants.WATER_UNIT_UAE_NATIONAL_FLAT_RED_TARIFF_17_SC;
                                    }
                                    else
                                    {
                                        unitWaterGreenLimit = Constants.WATER_UNIT_UAE_NATIONAL_FLAT_GREEN_LIMIT_17; // values
                                        unitWaterGreenTariff = Constants.WATER_UNIT_UAE_NATIONAL_FLAT_GREEN_TARIFF_17;
                                        unitWaterRedTariff = Constants.WATER_UNIT_UAE_NATIONAL_FLAT_RED_TARIFF_17;
                                    }
                                }

                                waterGreenLimit = waterNumdaysVal
                                        * unitWaterGreenLimit; // water
                                                               // Green
                                                               // Limit
                                if (waterCompAmtVal > waterGreenLimit)
                                {
                                    waterRedLimit = waterCompAmtVal
                                            - waterGreenLimit;
                                }
                                else
                                {
                                    waterRedLimit = 0; // water Red Limit
                                }

                                if (waterCompAmtVal <= waterGreenLimit)
                                { // Water
                                  // Green
                                    waterGreenLimit = waterCompAmtVal;
                                    // Tariff
                                    // Amount
                                    waterGreenTariffAmt = waterCompAmtVal
                                            * unitWaterGreenTariff;
                                }
                                else
                                {
                                    waterGreenTariffAmt = waterGreenLimit
                                            * unitWaterGreenTariff;
                                }
                                if (waterCompAmtVal > waterGreenLimit)
                                    waterRedTariffAmt = (waterCompAmtVal - waterGreenLimit)
                                    * unitWaterRedTariff;
                                else
                                    waterRedTariffAmt = 0;
                            }// falt
                             // villa
                            if (PrimiseName.Equals(AppResource.traiff_premise_type_1))
                            {

                                if (currentYearCalc.Equals("2016"))
                                {
                                    if (socialCard.Equals("Yes"))
                                    {
                                        unitWaterGreenLimit = Constants.WATER_UNIT_UAE_NATIONAL_VILLA_GREEN_LIMIT_16_SC;// 7;
                                        unitWaterGreenTariff = Constants.WATER_UNIT_UAE_NATIONAL_VILLA_GREEN_TARIFF_16_SC;// 1.7;
                                        unitWaterRedTariff = Constants.WATER_UNIT_UAE_NATIONAL_VILLA_RED_TARIFF_16_SC;// 1.89;
                                    }
                                    else
                                    {
                                        unitWaterGreenLimit = Constants.WATER_UNIT_UAE_NATIONAL_VILLA_GREEN_LIMIT;// 7;
                                        unitWaterGreenTariff = Constants.WATER_UNIT_UAE_NATIONAL_VILLA_GREEN_TARIFF;// 1.7;
                                        unitWaterRedTariff = Constants.WATER_UNIT_UAE_NATIONAL_VILLA_RED_TARIFF;// 1.89;
                                    }
                                }
                                else if (currentYearCalc.Equals("2017"))
                                {
                                    if (socialCard.Equals("Yes"))
                                    {
                                        unitWaterGreenLimit = Constants.WATER_UNIT_UAE_NATIONAL_VILLA_GREEN_LIMIT_17_SC;// 7;
                                        unitWaterGreenTariff = Constants.WATER_UNIT_UAE_NATIONAL_VILLA_GREEN_TARIFF_17_SC;// 1.7;
                                        unitWaterRedTariff = Constants.WATER_UNIT_UAE_NATIONAL_VILLA_RED_TARIFF_17_SC;// 1.89;
                                    }
                                    else
                                    {
                                        unitWaterGreenLimit = Constants.WATER_UNIT_UAE_NATIONAL_VILLA_GREEN_LIMIT_17;// 7;
                                        unitWaterGreenTariff = Constants.WATER_UNIT_UAE_NATIONAL_VILLA_GREEN_TARIFF_17;// 1.7;
                                        unitWaterRedTariff = Constants.WATER_UNIT_UAE_NATIONAL_VILLA_RED_TARIFF_17;// 1.89;
                                    }
                                }

                                waterGreenLimit = waterNumdaysVal
                                        * unitWaterGreenLimit; // water
                                                               // Green
                                                               // Limit
                                if (waterCompAmtVal > waterGreenLimit)
                                {
                                    waterRedLimit = waterCompAmtVal
                                            - waterGreenLimit;
                                }
                                else
                                {
                                    waterRedLimit = 0; // water Red Limit
                                }

                                if (waterCompAmtVal <= waterGreenLimit)
                                { // Water
                                  // Green
                                    waterGreenLimit = waterCompAmtVal;
                                    // Tariff
                                    // Amount
                                    waterGreenTariffAmt = waterCompAmtVal
                                            * unitWaterGreenTariff;
                                }
                                else
                                {
                                    waterGreenTariffAmt = waterGreenLimit
                                            * unitWaterGreenTariff;
                                }
                                if (waterCompAmtVal > waterGreenLimit)
                                    waterRedTariffAmt = (waterCompAmtVal - waterGreenLimit)
                                    * unitWaterRedTariff;
                                else
                                    waterRedTariffAmt = 0;
                            }

                        }// Residential Expats
                        if (CategoryName.Equals(AppResource.traiff_cate_type_1))
                        {
                            if (PrimiseName.Equals(AppResource.traiff_premise_type_0))
                            {
                                if (currentYearCalc.Equals("2016"))
                                {
                                    if (socialCard.Equals("Yes"))
                                    {
                                        unitWaterGreenLimit = Constants.WATER_UNIT_UAE_EXPATS_FLAT_GREEN_LIMIT_16_SC; // values
                                        unitWaterGreenTariff = Constants.WATER_UNIT_UAE_EXPATS_FLAT_GREEN_TARIFF_16_SC;
                                        unitWaterRedTariff = Constants.WATER_UNIT_UAE_EXPATS_FLAT_RED_TARIFF_16_SC;
                                    }
                                    else
                                    {
                                        unitWaterGreenLimit = Constants.WATER_UNIT_UAE_EXPATS_FLAT_GREEN_LIMIT; // values
                                        unitWaterGreenTariff = Constants.WATER_UNIT_UAE_EXPATS_FLAT_GREEN_TARIFF;
                                        unitWaterRedTariff = Constants.WATER_UNIT_UAE_EXPATS_FLAT_RED_TARIFF;
                                    }
                                }
                                else if (currentYearCalc.Equals("2017"))
                                {
                                    if (socialCard.Equals("Yes"))
                                    {
                                        unitWaterGreenLimit = Constants.WATER_UNIT_UAE_EXPATS_FLAT_GREEN_LIMIT_17_SC; // values
                                        unitWaterGreenTariff = Constants.WATER_UNIT_UAE_EXPATS_FLAT_GREEN_TARIFF_17_SC;
                                        unitWaterRedTariff = Constants.WATER_UNIT_UAE_EXPATS_FLAT_RED_TARIFF_17_SC;
                                    }
                                    else
                                    {
                                        unitWaterGreenLimit = Constants.WATER_UNIT_UAE_EXPATS_FLAT_GREEN_LIMIT_17; // values
                                        unitWaterGreenTariff = Constants.WATER_UNIT_UAE_EXPATS_FLAT_GREEN_TARIFF_17;
                                        unitWaterRedTariff = Constants.WATER_UNIT_UAE_EXPATS_FLAT_RED_TARIFF_17;
                                    }
                                }

                                waterGreenLimit = waterNumdaysVal
                                        * unitWaterGreenLimit; // water
                                                               // Green
                                                               // Limit
                                if (waterCompAmtVal > waterGreenLimit)
                                {
                                    waterRedLimit = waterCompAmtVal
                                            - waterGreenLimit;
                                }
                                else
                                {
                                    waterRedLimit = 0; // water Red Limit
                                }

                                if (waterCompAmtVal <= waterGreenLimit)
                                { // Water
                                  // Green
                                    waterGreenLimit = waterCompAmtVal;
                                    // Tariff
                                    // Amount
                                    waterGreenTariffAmt = waterCompAmtVal
                                            * unitWaterGreenTariff;
                                }
                                else
                                {
                                    waterGreenTariffAmt = waterGreenLimit
                                            * unitWaterGreenTariff;
                                }
                                if (waterCompAmtVal > waterGreenLimit)
                                    waterRedTariffAmt = (waterCompAmtVal - waterGreenLimit)
                                    * unitWaterRedTariff;
                                else
                                    waterRedTariffAmt = 0;
                            }// falt
                             // villa
                            if (PrimiseName.Equals(AppResource.traiff_premise_type_1))
                            {
                                if (currentYearCalc.Equals("2016"))
                                {
                                    if (socialCard.Equals("Yes"))
                                    {
                                        unitWaterGreenLimit = Constants.WATER_UNIT_UAE_EXPATS_VILLA_GREEN_LIMIT_16_SC; // values
                                        unitWaterGreenTariff = Constants.WATER_UNIT_UAE_EXPATS_VILLA_GREEN_TARIFF_16_SC;
                                        unitWaterRedTariff = Constants.WATER_UNIT_UAE_EXPATS_VILLA_RED_TARIFF_16_SC;
                                    }
                                    else
                                    {
                                        unitWaterGreenLimit = Constants.WATER_UNIT_UAE_EXPATS_VILLA_GREEN_LIMIT; // values
                                        unitWaterGreenTariff = Constants.WATER_UNIT_UAE_EXPATS_VILLA_GREEN_TARIFF;
                                        unitWaterRedTariff = Constants.WATER_UNIT_UAE_EXPATS_VILLA_RED_TARIFF;
                                    }
                                }
                                else if (currentYearCalc.Equals("2017"))
                                {    
                                    if (socialCard.Equals("Yes"))
                                    {
                                        unitWaterGreenLimit = Constants.WATER_UNIT_UAE_EXPATS_VILLA_GREEN_LIMIT_17_SC; // values
                                        unitWaterGreenTariff = Constants.WATER_UNIT_UAE_EXPATS_VILLA_GREEN_TARIFF_17_SC;
                                        unitWaterRedTariff = Constants.WATER_UNIT_UAE_EXPATS_VILLA_RED_TARIFF_17_SC;
                                    }
                                    else
                                    {
                                        unitWaterGreenLimit = Constants.WATER_UNIT_UAE_EXPATS_VILLA_GREEN_LIMIT_17; // values
                                        unitWaterGreenTariff = Constants.WATER_UNIT_UAE_EXPATS_VILLA_GREEN_TARIFF_17;
                                        unitWaterRedTariff = Constants.WATER_UNIT_UAE_EXPATS_VILLA_RED_TARIFF_17;
                                    }
                                }

                                waterGreenLimit = waterNumdaysVal
                                        * unitWaterGreenLimit; // water
                                                               // Green
                                                               // Limit
                                if (waterCompAmtVal > waterGreenLimit)
                                {
                                    waterRedLimit = waterCompAmtVal
                                            - waterGreenLimit;
                                }
                                else
                                {
                                    waterRedLimit = 0; // water Red Limit
                                }

                                if (waterCompAmtVal <= waterGreenLimit)
                                { // Water
                                  // Green
                                    waterGreenLimit = waterCompAmtVal;
                                    // Tariff
                                    // Amount
                                    waterGreenTariffAmt = waterCompAmtVal
                                            * unitWaterGreenTariff;
                                }
                                else
                                {
                                    waterGreenTariffAmt = waterGreenLimit
                                            * unitWaterGreenTariff;
                                }
                                if (waterCompAmtVal > waterGreenLimit)
                                    waterRedTariffAmt = (waterCompAmtVal - waterGreenLimit)
                                    * unitWaterRedTariff;
                                else
                                    waterRedTariffAmt = 0;
                            }

                        }// end Residential Expats



                        string waterGreenStr = DoFormat(waterGreenLimit);
                        string waterGreenTarrifStr = DoFormat(waterGreenTariffAmt);
                        string waterGreenUnitStr = DoFormat(unitWaterGreenTariff);


                        string waterRedStr = DoFormat(waterRedLimit);
                        string waterRedTarrifStr = DoFormat(waterRedTariffAmt);
                        string waterRedUnitStr = DoFormat(unitWaterRedTariff);

                        string total = DoFormat((waterGreenTariffAmt + waterRedTariffAmt));
                        GreenUnits = "" + waterGreenStr + " m3"
								+ "\n" + waterGreenTarrifStr + "\n"
								+ "(AED " + waterGreenUnitStr + "/m3)";

						RedUnits = "" + waterRedStr + " m3" + "\n"
								+ waterRedTarrifStr + "\n" +
								"(AED " + waterRedUnitStr + "/m3)";

						Total = "" + "AED " + total;
                        PaymentsVisible = true;
                        TotalVisible = true;
						var tarrif = new TariffInformation();
						tarrif.setFocus();
                        //paymentDetails.setVisibility(View.VISIBLE);
                        //totalDetails.setVisibility(View.VISIBLE);
                    }
                    else
                    {
                        //Toast.makeText(mActivity, getResources().getString(R.string.str_mandatory_feilds_myprofile),
                        //        Toast.LENGTH_LONG).show();
                    }
                } // Water end
                if (servSelected.Equals("electricity"))
                {
                    if ((!waterNumdays.Equals("") && !waterCompAmt.Equals("")))
                    {

                        waterNumdaysVal = Int32.Parse(waterNumdays); // 30;
                        waterCompAmtVal = Int32.Parse(waterCompAmt); // 21;

                        // Residential-nationals
                        if (CategoryName.Equals(AppResource.traiff_cate_type_0))
                        {
                            if (PrimiseName.Equals(AppResource.traiff_premise_type_0))
                            {
                                if (currentYearCalc.Equals("2016"))
                                {
                                    if (socialCard.Equals("Yes")) //check native
                                    {
                                        unitElecGreenLimit = Constants.ELEC_UNIT_UAE_NATIONAL_FLAT_GREEN_LIMIT_16_SC;
                                        unitElecGreenTariff = Constants.ELEC_UNIT_UAE_NATIONAL_FLAT_GREEN_TARIFF_16_SC;
                                        unitElecRedTariff = Constants.ELEC_UNIT_UAE_NATIONAL_FLAT_RED_TARIFF_16_SC;
                                    }
                                    else
                                    {
                                        unitElecGreenLimit = Constants.ELEC_UNIT_UAE_NATIONAL_FLAT_GREEN_LIMIT;
                                        unitElecGreenTariff = Constants.ELEC_UNIT_UAE_NATIONAL_FLAT_GREEN_TARIFF;
                                        unitElecRedTariff = Constants.ELEC_UNIT_UAE_NATIONAL_FLAT_RED_TARIFF;
                                    }
                                }
                                else if (currentYearCalc.Equals("2017"))
                                {
                                    if (socialCard.Equals("Yes"))
                                    {
                                        unitElecGreenLimit = Constants.ELEC_UNIT_UAE_NATIONAL_FLAT_GREEN_LIMIT_17_SC;
                                        unitElecGreenTariff = Constants.ELEC_UNIT_UAE_NATIONAL_FLAT_GREEN_TARIFF_17_SC;
                                        unitElecRedTariff = Constants.ELEC_UNIT_UAE_NATIONAL_FLAT_RED_TARIFF_17_SC;
                                    }
                                    else
                                    {
                                        unitElecGreenLimit = Constants.ELEC_UNIT_UAE_NATIONAL_FLAT_GREEN_LIMIT_17;
                                        unitElecGreenTariff = Constants.ELEC_UNIT_UAE_NATIONAL_FLAT_GREEN_TARIFF_17;
                                        unitElecRedTariff = Constants.ELEC_UNIT_UAE_NATIONAL_FLAT_RED_TARIFF_17;
                                    }
                                }



                                elecGreenLimit = waterNumdaysVal
                                        * unitElecGreenLimit; // elec
                                                              // Green
                                                              // Limit
                                if (waterCompAmtVal > elecGreenLimit)
                                {
                                    elecRedLimit = waterCompAmtVal - elecGreenLimit;
                                }
                                else
                                {
                                    elecRedLimit = 0; // water Red Limit
                                }

                                if (waterCompAmtVal <= elecGreenLimit)
                                { // Water
                                  // Green
                                    elecGreenLimit = waterCompAmtVal;
                                    // Tariff Amount
                                    elecGreenTariffAmt = waterCompAmtVal
                                            * unitElecGreenTariff;
                                }
                                else
                                {
                                    elecGreenTariffAmt = elecGreenLimit
                                            * unitElecGreenTariff;
                                }
                                if (waterCompAmtVal > elecGreenLimit)
                                    elecRedTariffAmt = (waterCompAmtVal - elecGreenLimit)
                                    * unitElecRedTariff;
                                else
                                    elecRedTariffAmt = 0;
                            }// falt
                             // villa
                            if (PrimiseName.Equals(AppResource.traiff_premise_type_1))
                            {
                                if (currentYearCalc.Equals("2016"))
                                {
                                    if (socialCard.Equals("Yes"))
                                    {
                                        unitElecGreenLimit = Constants.ELEC_UNIT_UAE_NATIONAL_VILLA_GREEN_LIMIT_16_SC;
                                        unitElecGreenTariff = Constants.ELEC_UNIT_UAE_NATIONAL_VILLA_GREEN_TARIFF_16_SC;
                                        unitElecRedTariff = Constants.ELEC_UNIT_UAE_NATIONAL_VILLA_RED_TARIFF_16_SC;
                                    }
                                    else
                                    {
                                        unitElecGreenLimit = Constants.ELEC_UNIT_UAE_NATIONAL_VILLA_GREEN_LIMIT;
                                        unitElecGreenTariff = Constants.ELEC_UNIT_UAE_NATIONAL_VILLA_GREEN_TARIFF;
                                        unitElecRedTariff = Constants.ELEC_UNIT_UAE_NATIONAL_VILLA_RED_TARIFF;
                                    }
                                }
                                else if (currentYearCalc.Equals("2017"))
                                {
                                    if (socialCard.Equals("Yes"))
                                    {
                                        unitElecGreenLimit = Constants.ELEC_UNIT_UAE_NATIONAL_VILLA_GREEN_LIMIT_17_SC;
                                        unitElecGreenTariff = Constants.ELEC_UNIT_UAE_NATIONAL_VILLA_GREEN_TARIFF_17_SC;
                                        unitElecRedTariff = Constants.ELEC_UNIT_UAE_NATIONAL_VILLA_RED_TARIFF_17_SC;
                                    }
                                    else
                                    {
                                        unitElecGreenLimit = Constants.ELEC_UNIT_UAE_NATIONAL_VILLA_GREEN_LIMIT_17;
                                        unitElecGreenTariff = Constants.ELEC_UNIT_UAE_NATIONAL_VILLA_GREEN_TARIFF_17;
                                        unitElecRedTariff = Constants.ELEC_UNIT_UAE_NATIONAL_VILLA_RED_TARIFF_17;
                                    }

                                }

                                elecGreenLimit = waterNumdaysVal
                                        * unitElecGreenLimit; // elec
                                                              // Green
                                                              // Limit
                                if (waterCompAmtVal > elecGreenLimit)
                                {
                                    elecRedLimit = waterCompAmtVal - elecGreenLimit;
                                }
                                else
                                {
                                    elecRedLimit = 0; // water Red Limit
                                }

                                if (waterCompAmtVal <= elecGreenLimit)
                                { // elec
                                  // Green
                                    elecGreenLimit = waterCompAmtVal;
                                    // Tariff Amount
                                    elecGreenTariffAmt = waterCompAmtVal
                                            * unitElecGreenTariff;
                                }
                                else
                                {
                                    elecGreenTariffAmt = elecGreenLimit
                                            * unitElecGreenTariff;
                                }
                                if (waterCompAmtVal > elecGreenLimit)
                                    elecRedTariffAmt = (waterCompAmtVal - elecGreenLimit)
                                    * unitElecRedTariff;
                                else
                                    elecRedTariffAmt = 0;
                            }

                        }// Residential Expats
                        if (CategoryName.Equals(AppResource.traiff_cate_type_1))
                        {
                            if (PrimiseName.Equals(AppResource.traiff_premise_type_0))
                            {
                                if (currentYearCalc.Equals("2016"))
                                {
                                    if (socialCard.Equals("Yes"))
                                    {
                                        unitElecGreenLimit = Constants.ELEC_UNIT_UAE_EXPATS_FLAT_GREEN_LIMIT_16_SC; // values
                                        unitElecGreenTariff = Constants.ELEC_UNIT_UAE_EXPATS_FLAT_GREEN_TARIFF_16_SC;
                                        unitElecRedTariff = Constants.ELEC_UNIT_UAE_EXPATS_FLAT_RED_TARIFF_16_SC;
                                    }
                                    else
                                    {
                                        unitElecGreenLimit = Constants.ELEC_UNIT_UAE_EXPATS_FLAT_GREEN_LIMIT; // values
                                        unitElecGreenTariff = Constants.ELEC_UNIT_UAE_EXPATS_FLAT_GREEN_TARIFF;
                                        unitElecRedTariff = Constants.ELEC_UNIT_UAE_EXPATS_FLAT_RED_TARIFF;
                                    }
                                }
                                else if (currentYearCalc.Equals("2017"))
                                {
                                    if (socialCard.Equals("Yes"))
                                    {
                                        unitElecGreenLimit = Constants.ELEC_UNIT_UAE_EXPATS_FLAT_GREEN_LIMIT_17_SC; // values
                                        unitElecGreenTariff = Constants.ELEC_UNIT_UAE_EXPATS_FLAT_GREEN_TARIFF_17_SC;
                                        unitElecRedTariff = Constants.ELEC_UNIT_UAE_EXPATS_FLAT_RED_TARIFF_17_SC;
                                    }
                                    else
                                    {
                                        unitElecGreenLimit = Constants.ELEC_UNIT_UAE_EXPATS_FLAT_GREEN_LIMIT_17; // values
                                        unitElecGreenTariff = Constants.ELEC_UNIT_UAE_EXPATS_FLAT_GREEN_TARIFF_17;
                                        unitElecRedTariff = Constants.ELEC_UNIT_UAE_EXPATS_FLAT_RED_TARIFF_17;
                                    }
                                }

                                elecGreenLimit = waterNumdaysVal
                                        * unitElecGreenLimit; // elec
                                                              // Green
                                                              // Limit
                                if (waterCompAmtVal > elecGreenLimit)
                                {
                                    elecRedLimit = waterCompAmtVal - elecGreenLimit;
                                }
                                else
                                {
                                    elecRedLimit = 0; // elec Red Limit
                                }

                                if (waterCompAmtVal <= elecGreenLimit)
                                { // Water
                                  // Green
                                    elecGreenLimit = waterCompAmtVal;
                                    // Tariff Amount

                                    elecGreenTariffAmt = waterCompAmtVal
                                            * unitElecGreenTariff;
                                }
                                else
                                {
                                    elecGreenTariffAmt = elecGreenLimit
                                            * unitElecGreenTariff;
                                }
                                if (waterCompAmtVal > elecGreenLimit)
                                    elecRedTariffAmt = (waterCompAmtVal - elecGreenLimit)
                                    * unitElecRedTariff;
                                else
                                    elecRedTariffAmt = 0;
                            }// falt
                             // villa
                            if (PrimiseName.Equals(AppResource.traiff_premise_type_1))
                            {
                                if (currentYearCalc.Equals("2016"))
                                {
                                    if (socialCard.Equals("Yes"))
                                    {
                                        unitElecGreenLimit = Constants.ELEC_UNIT_UAE_EXPATS_VILLA_GREEN_LIMIT_16_SC; // values
                                        unitElecGreenTariff = Constants.ELEC_UNIT_UAE_EXPATS_VILLA_GREEN_TARIFF_16_SC;
                                        unitElecRedTariff = Constants.ELEC_UNIT_UAE_EXPATS_VILLA_RED_TARIFF_16_SC;
                                    }
                                    else
                                    {
                                        unitElecGreenLimit = Constants.ELEC_UNIT_UAE_EXPATS_VILLA_GREEN_LIMIT; // values
                                        unitElecGreenTariff = Constants.ELEC_UNIT_UAE_EXPATS_VILLA_GREEN_TARIFF;
                                        unitElecRedTariff = Constants.ELEC_UNIT_UAE_EXPATS_VILLA_RED_TARIFF;
                                    }
                                }
                                else if (currentYearCalc.Equals("2017"))
                                {
                                    if (socialCard.Equals("Yes"))
                                    {
                                        unitElecGreenLimit = Constants.ELEC_UNIT_UAE_EXPATS_VILLA_GREEN_LIMIT_17_SC; // values
                                        unitElecGreenTariff = Constants.ELEC_UNIT_UAE_EXPATS_VILLA_GREEN_TARIFF_17_SC;
                                        unitElecRedTariff = Constants.ELEC_UNIT_UAE_EXPATS_VILLA_RED_TARIFF_17_SC;
                                    }
                                    else
                                    {
                                        unitElecGreenLimit = Constants.ELEC_UNIT_UAE_EXPATS_VILLA_GREEN_LIMIT_17; // values
                                        unitElecGreenTariff = Constants.ELEC_UNIT_UAE_EXPATS_VILLA_GREEN_TARIFF_17;
                                        unitElecRedTariff = Constants.ELEC_UNIT_UAE_EXPATS_VILLA_RED_TARIFF_17;
                                    }

                                }
                                elecGreenLimit = waterNumdaysVal
                                        * unitElecGreenLimit; // elec
                                                              // Green
                                                              // Limit
                                if (waterCompAmtVal > elecGreenLimit)
                                {
                                    elecRedLimit = waterCompAmtVal - elecGreenLimit;
                                }
                                else
                                {
                                    elecRedLimit = 0; // elec Red Limit
                                }

                                if (waterCompAmtVal <= elecGreenLimit)
                                { // elec
                                  // Green
                                    elecGreenLimit = waterCompAmtVal;
                                    // Tariff Amount
                                    elecGreenTariffAmt = waterCompAmtVal
                                            * unitElecGreenTariff;
                                }
                                else
                                {
                                    elecGreenTariffAmt = elecGreenLimit
                                            * unitElecGreenTariff;
                                }
                                if (waterCompAmtVal > elecGreenLimit)
                                    elecRedTariffAmt = (waterCompAmtVal - elecGreenLimit)
                                    * unitElecRedTariff;
                                else
                                    elecRedTariffAmt = 0;
                            }

                        }// end Residential Expats

                       


                        string elecGreenStr = DoFormat(elecGreenLimit);
                        string elecGreenTarrifStr = DoFormat(elecGreenTariffAmt);
                        string elecGreenUnitStr = DoFormat(unitElecGreenTariff);


                        string elecRedStr = DoFormat(elecRedLimit);
                        string elecRedTarrifStr = DoFormat(elecRedTariffAmt);
                        string elecRedUnitStr = DoFormat(unitElecRedTariff);

                        string total = DoFormat((elecGreenTariffAmt + elecRedTariffAmt));
                        GreenUnits = "" + elecGreenStr + " kWh"
								+ "\n" + elecGreenTarrifStr + "\n"
								+ "(AED " + elecGreenUnitStr + "/kWh)";
						

						RedUnits = "" + elecRedStr + " kWh" + "\n"
								+ elecRedTarrifStr + "\n" +
								"(AED " + elecRedUnitStr + "/kWh)";

						Total = "" + "AED " + total;

                        PaymentsVisible = true;
                        TotalVisible = true;
						var tarrif = new TariffInformation();
						tarrif.setFocus();
                        //paymentDetails.setVisibility(View.VISIBLE);
                        //totalDetails.setVisibility(View.VISIBLE);
                    }
                    else
                    {
                        //Toast.makeText(mActivity, getResources().getString(R.string.str_mandatory_feilds_myprofile),
                        //        Toast.LENGTH_LONG).show();
                    }

                } //scroll.fullScroll(View.FOCUS_DOWN);
                  //scroll.fullScroll(View.FOCUS_DOWN);//electricity end

            }
        }
        private async Task OnTapCalc2017Desp()
        {
            TCalc2016 = "#E7F1C1";
            TCalc2017 = "#D0E766";
            currentYearCalc = "2017";
        }

        private async Task OnTapCalc2016Desp()
        {
            TCalc2016 = "#D0E766";
            TCalc2017 = "#E7F1C1";
            currentYearCalc = "2016";
        }
       
        private async Task OnTaponTariffChart()
        {
            String url = "";
            if (currYear.Equals("2016"))
            {
                 if (App.CultureCode.Equals("ar"))
                {
                    url = "https://www.addc.ae/ar-ae/residential/pages/residential%20rates%20and%20tariffs.aspx";
                }
                else
                {
                    url = "https://www.addc.ae/en-US/residential/Pages/Residential%20rates%20and%20tariffs.aspx";
                }
            }
            else if (currYear.Equals("2017"))
            {
                if (App.CultureCode.Equals("ar"))
                {
                    url = "https://www.addc.ae/ar-ae/residential/pages/residential%20rates%20and%20tariffs.aspx";
                }
                else
                {
                    url = "https://www.addc.ae/en-US/residential/Pages/Residential%20rates%20and%20tariffs.aspx";
                }
            }
            Device.OpenUri(new Uri(url));
        }
        private async Task OnTapTCalcElecDesp()
        {
            TCalcWater = "#E7F1C1";
            TCalcElec = "#D0E766";
			CUnits = "false";
            servSelected = "electricity";
            Units = AppResource.traiff_electric_units;
        }
        private async Task OnTapTCalcWaterDesp()
        {
            TCalcWater = "#D0E766";
            TCalcElec = "#E7F1C1";
            servSelected = "water";
			CUnits = "true";
            Units = AppResource.traiff_water_units;
        }

        private async Task OnTap2016sDesp()
        {
            TSlab2016 = "#D0E766";
            TSlab2017 = "#E7F1C1";
            currYear = "2016";
            if (currYear.Equals("2016"))
            {
                if (currentStatus.Equals("National")) 
                {
                    Tariff_cubic_per_day_com = AppResource.tariff_cubic_per_day_com;
                    Tariff_cubic_per_day_res = AppResource.tariff_cubic_per_day_res;
                    Tariff_uae_green_water_units = AppResource.tariff_uae_green_water_units;
                    Tariff_uae_red_water_units = AppResource.tariff_uae_red_wter_units;

                    Tariff_uae_green_elec_units = AppResource.tariff_uae_green_elec_units;
                    Tariff_uae_red_elec_units = AppResource.tariff_uae_red_elec_units;
                    Tariff_uae_home_elec_units = AppResource.tariff_uae_home_elec_units;
                    Tariff_uae_com_elec_units = AppResource.tariff_uae_com_elec_units;
                }
                else
                {//Expats
                    Tariff_cubic_per_day_com = AppResource.tariff_expats_com_water_units;
                    Tariff_cubic_per_day_res = AppResource.tariff_cubic_per_day_res;
                    Tariff_uae_green_water_units = AppResource.tariff_expats_green_water_units;
                    Tariff_uae_red_water_units = AppResource.tariff_expats_red_wter_units;

                    Tariff_uae_green_elec_units = AppResource.tariff_expats_green_elec_units;
                    Tariff_uae_red_elec_units = AppResource.tariff_expats_red_elec_units;
                    Tariff_uae_home_elec_units = AppResource.tariff_expats_home_elec_units;
                    Tariff_uae_com_elec_units = AppResource.tariff_expats_com_elec_units;
                }
            }
            else
            {
                if (currentStatus.Equals("National"))
                {
                    Tariff_cubic_per_day_com = AppResource.tariff_cubic_per_day_com;
                    Tariff_cubic_per_day_res = AppResource.tariff_cubic_per_day_res;
                    Tariff_uae_green_water_units = AppResource.tariff_uae_green_water_units_17;
                    Tariff_uae_red_water_units = AppResource.tariff_uae_red_wter_units_17;

                    Tariff_uae_green_elec_units = AppResource.tariff_uae_green_elec_units_17;
                    Tariff_uae_red_elec_units = AppResource.tariff_uae_red_elec_units_17;
                    Tariff_uae_home_elec_units = AppResource.tariff_uae_home_elec_units_17;
                    Tariff_uae_com_elec_units = AppResource.tariff_uae_com_elec_units_17;
                }
                else
                {//Expats
                    Tariff_cubic_per_day_com = AppResource.tariff_expats_com_water_units_17;
                    Tariff_cubic_per_day_res = AppResource.tariff_cubic_per_day_res;
                    Tariff_uae_green_water_units = AppResource.tariff_expats_green_water_units_17;
                    Tariff_uae_red_water_units = AppResource.tariff_expats_red_wter_units_17;

                    Tariff_uae_green_elec_units = AppResource.tariff_expats_green_elec_units_17;
                    Tariff_uae_red_elec_units = AppResource.tariff_expats_red_elec_units_17;
                    Tariff_uae_home_elec_units = AppResource.tariff_expats_home_elec_units_17;
                    Tariff_uae_com_elec_units = AppResource.tariff_expats_com_elec_units_17;
                }
            }
        }

        private async Task OnTap2017Desp()
        {
            TSlab2016 = "#E7F1C1";
            TSlab2017 = "#D0E766";
            
            currYear = "2017";
            if (currYear.Equals("2016"))
            {
                if (currentStatus.Equals("National"))
                {
                    Tariff_cubic_per_day_com = AppResource.tariff_cubic_per_day_com;
                    Tariff_cubic_per_day_res = AppResource.tariff_cubic_per_day_res;
                    Tariff_uae_green_water_units = AppResource.tariff_uae_green_water_units;
                    Tariff_uae_red_water_units = AppResource.tariff_uae_red_wter_units;

                    Tariff_uae_green_elec_units = AppResource.tariff_uae_green_elec_units;
                    Tariff_uae_red_elec_units = AppResource.tariff_uae_red_elec_units;
                    Tariff_uae_home_elec_units = AppResource.tariff_uae_home_elec_units;
                    Tariff_uae_com_elec_units = AppResource.tariff_uae_com_elec_units;
                }
                else
                {//Expats
                    Tariff_cubic_per_day_com = AppResource.tariff_expats_com_water_units;
                    Tariff_cubic_per_day_res = AppResource.tariff_cubic_per_day_res;
                    Tariff_uae_green_water_units = AppResource.tariff_expats_green_water_units;
                    Tariff_uae_red_water_units = AppResource.tariff_expats_red_wter_units;

                    Tariff_uae_green_elec_units = AppResource.tariff_expats_green_elec_units;
                    Tariff_uae_red_elec_units = AppResource.tariff_expats_red_elec_units;
                    Tariff_uae_home_elec_units = AppResource.tariff_expats_home_elec_units;
                    Tariff_uae_com_elec_units = AppResource.tariff_expats_com_elec_units;
                }
            }
            else
            {
                if (currentStatus.Equals("National"))
                {
                    Tariff_cubic_per_day_com = AppResource.tariff_cubic_per_day_com;
                    Tariff_cubic_per_day_res = AppResource.tariff_cubic_per_day_res;
                    Tariff_uae_green_water_units = AppResource.tariff_uae_green_water_units_17;
                    Tariff_uae_red_water_units = AppResource.tariff_uae_red_wter_units_17;

                    Tariff_uae_green_elec_units = AppResource.tariff_uae_green_elec_units_17;
                    Tariff_uae_red_elec_units = AppResource.tariff_uae_red_elec_units_17;
                    Tariff_uae_home_elec_units = AppResource.tariff_uae_home_elec_units_17;
                    Tariff_uae_com_elec_units = AppResource.tariff_uae_com_elec_units_17;
                }
                else
                {//Expats
                    Tariff_cubic_per_day_com = AppResource.tariff_expats_com_water_units;
                    Tariff_cubic_per_day_res = AppResource.tariff_cubic_per_day_res;
                    Tariff_uae_green_water_units = AppResource.tariff_expats_green_water_units_17;
                    Tariff_uae_red_water_units = AppResource.tariff_expats_red_wter_units_17;

                    Tariff_uae_green_elec_units = AppResource.tariff_expats_green_elec_units_17;
                    Tariff_uae_red_elec_units = AppResource.tariff_expats_red_elec_units_17;
                    Tariff_uae_home_elec_units = AppResource.tariff_expats_home_elec_units_17;
                    Tariff_uae_com_elec_units = AppResource.tariff_expats_com_elec_units_17;
                }
            }
        }

        private async Task OnTapExpatsDesp()
        {
            TabImgUAE = "";
            TabImgEx = "tab.png";
            currentStatus = "Expat";
          //  currYear = "2016";
            if (currYear.Equals("2016"))
            {
                if (currentStatus.Equals("National"))
                {
                    Tariff_cubic_per_day_com = AppResource.tariff_cubic_per_day_com;
                    Tariff_cubic_per_day_res = AppResource.tariff_cubic_per_day_res;
                    Tariff_uae_green_water_units = AppResource.tariff_uae_green_water_units;
                    Tariff_uae_red_water_units = AppResource.tariff_uae_red_wter_units;

                    Tariff_uae_green_elec_units = AppResource.tariff_uae_green_elec_units;
                    Tariff_uae_red_elec_units = AppResource.tariff_uae_red_elec_units;
                    Tariff_uae_home_elec_units = AppResource.tariff_uae_home_elec_units;
                    Tariff_uae_com_elec_units = AppResource.tariff_uae_com_elec_units;
                }
                else
                {//Expats
                    Tariff_cubic_per_day_com = AppResource.tariff_expats_com_water_units;
                    Tariff_cubic_per_day_res = AppResource.tariff_cubic_per_day_res;
                    Tariff_uae_green_water_units = AppResource.tariff_expats_green_water_units;
                    Tariff_uae_red_water_units = AppResource.tariff_expats_red_wter_units;

                    Tariff_uae_green_elec_units = AppResource.tariff_expats_green_elec_units;
                    Tariff_uae_red_elec_units = AppResource.tariff_expats_red_elec_units;
                    Tariff_uae_home_elec_units = AppResource.tariff_expats_home_elec_units;
                    Tariff_uae_com_elec_units = AppResource.tariff_expats_com_elec_units;
                }
            }
            else
            {
                if (currentStatus.Equals("National"))
                {
                    Tariff_cubic_per_day_com = AppResource.tariff_cubic_per_day_com;
                    Tariff_cubic_per_day_res = AppResource.tariff_cubic_per_day_res;
                    Tariff_uae_green_water_units = AppResource.tariff_uae_green_water_units_17;
                    Tariff_uae_red_water_units = AppResource.tariff_uae_red_wter_units_17;

                    Tariff_uae_green_elec_units = AppResource.tariff_uae_green_elec_units_17;
                    Tariff_uae_red_elec_units = AppResource.tariff_uae_red_elec_units_17;
                    Tariff_uae_home_elec_units = AppResource.tariff_uae_home_elec_units_17;
                    Tariff_uae_com_elec_units = AppResource.tariff_uae_com_elec_units_17;
                }
                else
                {//Expats
                    Tariff_cubic_per_day_com = AppResource.tariff_expats_com_water_units;
                    Tariff_cubic_per_day_res = AppResource.tariff_cubic_per_day_res;
                    Tariff_uae_green_water_units = AppResource.tariff_expats_green_water_units_17;
                    Tariff_uae_red_water_units = AppResource.tariff_expats_red_wter_units_17;

                    Tariff_uae_green_elec_units = AppResource.tariff_expats_green_elec_units_17;
                    Tariff_uae_red_elec_units = AppResource.tariff_expats_red_elec_units_17;
                    Tariff_uae_home_elec_units = AppResource.tariff_expats_home_elec_units_17;
                    Tariff_uae_com_elec_units = AppResource.tariff_expats_com_elec_units_17;
                }
            }

        }

        private async Task OnTapNationalsDesp()
        {
            TabImgUAE = "tab.png";
            TabImgEx = "";
            currentStatus = "National";

          //  currYear = "2016";
            if (currYear.Equals("2016"))
            {
                if (currentStatus.Equals("National"))
                {
                    Tariff_cubic_per_day_com = AppResource.tariff_cubic_per_day_com;
                    Tariff_cubic_per_day_res = AppResource.tariff_cubic_per_day_res;
                    Tariff_uae_green_water_units = AppResource.tariff_uae_green_water_units;
                    Tariff_uae_red_water_units = AppResource.tariff_uae_red_wter_units;

                    Tariff_uae_green_elec_units = AppResource.tariff_uae_green_elec_units;
                    Tariff_uae_red_elec_units = AppResource.tariff_uae_red_elec_units;
                    Tariff_uae_home_elec_units = AppResource.tariff_uae_home_elec_units;
                    Tariff_uae_com_elec_units = AppResource.tariff_uae_com_elec_units;
                }
                else
                {//Expats
                    Tariff_cubic_per_day_com = AppResource.tariff_expats_com_water_units;
                    Tariff_cubic_per_day_res = AppResource.tariff_cubic_per_day_res;
                    Tariff_uae_green_water_units = AppResource.tariff_expats_green_water_units;
                    Tariff_uae_red_water_units = AppResource.tariff_expats_red_wter_units;

                    Tariff_uae_green_elec_units = AppResource.tariff_expats_green_elec_units;
                    Tariff_uae_red_elec_units = AppResource.tariff_expats_red_elec_units;
                    Tariff_uae_home_elec_units = AppResource.tariff_expats_home_elec_units;
                    Tariff_uae_com_elec_units = AppResource.tariff_expats_com_elec_units;
                }
            }
            else
            {
                if (currentStatus.Equals("National"))
                {
                    Tariff_cubic_per_day_com = AppResource.tariff_cubic_per_day_com;
                    Tariff_cubic_per_day_res = AppResource.tariff_cubic_per_day_res;
                    Tariff_uae_green_water_units = AppResource.tariff_uae_green_water_units_17;
                    Tariff_uae_red_water_units = AppResource.tariff_uae_red_wter_units_17;

                    Tariff_uae_green_elec_units = AppResource.tariff_uae_green_elec_units_17;
                    Tariff_uae_red_elec_units = AppResource.tariff_uae_red_elec_units_17;
                    Tariff_uae_home_elec_units = AppResource.tariff_uae_home_elec_units_17;
                    Tariff_uae_com_elec_units = AppResource.tariff_uae_com_elec_units_17;
                }
                else
                {//Expats
                    Tariff_cubic_per_day_com = AppResource.tariff_expats_com_water_units_17;
                    Tariff_cubic_per_day_res = AppResource.tariff_cubic_per_day_res;
                    Tariff_uae_green_water_units = AppResource.tariff_expats_green_water_units_17;
                    Tariff_uae_red_water_units = AppResource.tariff_expats_red_wter_units_17;

                    Tariff_uae_green_elec_units = AppResource.tariff_expats_green_elec_units_17;
                    Tariff_uae_red_elec_units = AppResource.tariff_expats_red_elec_units_17;
                    Tariff_uae_home_elec_units = AppResource.tariff_expats_home_elec_units_17;
                    Tariff_uae_com_elec_units = AppResource.tariff_expats_com_elec_units_17;
                }
            }
        }

        private async Task OnTapSlab()
        {
            TCalcColor = "#545b66";
            TCalcImg = "ic_action_deselect";

            TSlabColor = "#5e9622"; 
            TSlabImg = "ic_action_selected_tariff";

            TariffSlab = true;
            TariffCalculator = false;

        }

        private async Task OnTapCalc()
        {
            TCalcColor = "#5e9622";
            TCalcImg = "ic_action_select";

            TSlabColor = "#545b66";
            TSlabImg = "ic_action_deselected_tariff";

            TariffSlab = false;
            TariffCalculator = true;
        }
    }
}
