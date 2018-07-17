using System;
namespace ADDC_MVVM
{
	public static class Constants
	{
		//For Production 
		//public static readonly string BaseAddressUrl = "https://extesb.addc.ae/Addc.Mobile.RestServices.Json/";
        //For UAT
        // public static readonly string BaseAddressUrl = "https://extesbuat.addc.ae/Addc.Mobile.RestServices.Json.dev";
      	
		//for testing
		public static readonly string BaseAddressUrl = "https://extesbuat.addc.ae/Addc.Mobile.RestServices.Json";

		public static double WATER_UNIT_UAE_NATIONAL_FLAT_GREEN_LIMIT = 0.7;
        public static double WATER_UNIT_UAE_NATIONAL_FLAT_GREEN_TARIFF = 1.70;
        public static double WATER_UNIT_UAE_NATIONAL_FLAT_RED_TARIFF = 1.89;

        public static double WATER_UNIT_UAE_NATIONAL_VILLA_GREEN_LIMIT = 7;
        public static double WATER_UNIT_UAE_NATIONAL_VILLA_GREEN_TARIFF = 1.70;
        public static double WATER_UNIT_UAE_NATIONAL_VILLA_RED_TARIFF = 1.89;

        public static double WATER_UNIT_UAE_EXPATS_FLAT_GREEN_LIMIT = 0.7;
        public static double WATER_UNIT_UAE_EXPATS_FLAT_GREEN_TARIFF = 5.95;
        public static double WATER_UNIT_UAE_EXPATS_FLAT_RED_TARIFF = 10.55;//9.90;// changed

        public static double WATER_UNIT_UAE_EXPATS_VILLA_GREEN_LIMIT = 5;
        public static double WATER_UNIT_UAE_EXPATS_VILLA_GREEN_TARIFF = 5.95;
        public static double WATER_UNIT_UAE_EXPATS_VILLA_RED_TARIFF = 10.55;//9.90;// changed here

        public static double ELEC_UNIT_UAE_NATIONAL_FLAT_GREEN_LIMIT = 30;
        public static double ELEC_UNIT_UAE_NATIONAL_FLAT_GREEN_TARIFF = 0.05;
        public static double ELEC_UNIT_UAE_NATIONAL_FLAT_RED_TARIFF = 0.055;

        public static double ELEC_UNIT_UAE_NATIONAL_VILLA_GREEN_LIMIT = 400;
        public static double ELEC_UNIT_UAE_NATIONAL_VILLA_GREEN_TARIFF = 0.05;
        public static double ELEC_UNIT_UAE_NATIONAL_VILLA_RED_TARIFF = 0.055;

        public static double ELEC_UNIT_UAE_EXPATS_FLAT_GREEN_LIMIT = 20;
        public static double ELEC_UNIT_UAE_EXPATS_FLAT_GREEN_TARIFF = 0.21;
        public static double ELEC_UNIT_UAE_EXPATS_FLAT_RED_TARIFF = 0.318;

        public static double ELEC_UNIT_UAE_EXPATS_VILLA_GREEN_LIMIT = 200;
        public static double ELEC_UNIT_UAE_EXPATS_VILLA_GREEN_TARIFF = 0.21;
        public static double ELEC_UNIT_UAE_EXPATS_VILLA_RED_TARIFF = 0.318;
        //=======================================================================
        public static double WATER_UNIT_UAE_NATIONAL_FLAT_GREEN_LIMIT_17 = 0.7;
        public static double WATER_UNIT_UAE_NATIONAL_FLAT_GREEN_TARIFF_17 = 2.09;
        public static double WATER_UNIT_UAE_NATIONAL_FLAT_RED_TARIFF_17 = 2.6;

        public static double WATER_UNIT_UAE_NATIONAL_VILLA_GREEN_LIMIT_17 = 7;
        public static double WATER_UNIT_UAE_NATIONAL_VILLA_GREEN_TARIFF_17 = 2.09;
        public static double WATER_UNIT_UAE_NATIONAL_VILLA_RED_TARIFF_17 = 2.6;

        public static double WATER_UNIT_UAE_EXPATS_FLAT_GREEN_LIMIT_17 = 0.7;
        public static double WATER_UNIT_UAE_EXPATS_FLAT_GREEN_TARIFF_17 = 7.84;
        public static double WATER_UNIT_UAE_EXPATS_FLAT_RED_TARIFF_17 = 10.41;//9.90;// changed

        public static double WATER_UNIT_UAE_EXPATS_VILLA_GREEN_LIMIT_17 = 5;
        public static double WATER_UNIT_UAE_EXPATS_VILLA_GREEN_TARIFF_17 = 7.84;
        public static double WATER_UNIT_UAE_EXPATS_VILLA_RED_TARIFF_17 = 10.41;//9.90;// changed here

        public static double ELEC_UNIT_UAE_NATIONAL_FLAT_GREEN_LIMIT_17 = 30;
        public static double ELEC_UNIT_UAE_NATIONAL_FLAT_GREEN_TARIFF_17 = 0.067;
        public static double ELEC_UNIT_UAE_NATIONAL_FLAT_RED_TARIFF_17 = 0.075;

        public static double ELEC_UNIT_UAE_NATIONAL_VILLA_GREEN_LIMIT_17 = 400;
        public static double ELEC_UNIT_UAE_NATIONAL_VILLA_GREEN_TARIFF_17 = 0.067;
        public static double ELEC_UNIT_UAE_NATIONAL_VILLA_RED_TARIFF_17 = 0.075;

        public static double ELEC_UNIT_UAE_EXPATS_FLAT_GREEN_LIMIT_17 = 20;
        public static double ELEC_UNIT_UAE_EXPATS_FLAT_GREEN_TARIFF_17 = 0.268;
        public static double ELEC_UNIT_UAE_EXPATS_FLAT_RED_TARIFF_17 = 0.305;

        public static double ELEC_UNIT_UAE_EXPATS_VILLA_GREEN_LIMIT_17 = 200;
        public static double ELEC_UNIT_UAE_EXPATS_VILLA_GREEN_TARIFF_17 = 0.268;
        public static double ELEC_UNIT_UAE_EXPATS_VILLA_RED_TARIFF_17 = 0.305;
        //=========================================================================
        public static double WATER_UNIT_UAE_NATIONAL_FLAT_GREEN_LIMIT_17_SC = 9.804;
        public static double WATER_UNIT_UAE_NATIONAL_FLAT_GREEN_TARIFF_17_SC = 0;
        public static double WATER_UNIT_UAE_NATIONAL_FLAT_RED_TARIFF_17_SC = 2.09;

        public static double WATER_UNIT_UAE_NATIONAL_VILLA_GREEN_LIMIT_17_SC = 9.804;
        public static double WATER_UNIT_UAE_NATIONAL_VILLA_GREEN_TARIFF_17_SC = 0;
        public static double WATER_UNIT_UAE_NATIONAL_VILLA_RED_TARIFF_17_SC = 2.09;

        public static double WATER_UNIT_UAE_EXPATS_FLAT_GREEN_LIMIT_17_SC = 2.801;
        public static double WATER_UNIT_UAE_EXPATS_FLAT_GREEN_TARIFF_17_SC = 0;
        public static double WATER_UNIT_UAE_EXPATS_FLAT_RED_TARIFF_17_SC = 7.84;//9.90;// changed

        public static double WATER_UNIT_UAE_EXPATS_VILLA_GREEN_LIMIT_17_SC = 2.801;
        public static double WATER_UNIT_UAE_EXPATS_VILLA_GREEN_TARIFF_17_SC = 0;
        public static double WATER_UNIT_UAE_EXPATS_VILLA_RED_TARIFF_17_SC = 7.84;//9.90;// changed here

        public static double ELEC_UNIT_UAE_NATIONAL_FLAT_GREEN_LIMIT_17_SC = 333;
        public static double ELEC_UNIT_UAE_NATIONAL_FLAT_GREEN_TARIFF_17_SC = 0;
        public static double ELEC_UNIT_UAE_NATIONAL_FLAT_RED_TARIFF_17_SC = 0.067;

        public static double ELEC_UNIT_UAE_NATIONAL_VILLA_GREEN_LIMIT_17_SC = 333;
        public static double ELEC_UNIT_UAE_NATIONAL_VILLA_GREEN_TARIFF_17_SC = 0;
        public static double ELEC_UNIT_UAE_NATIONAL_VILLA_RED_TARIFF_17_SC = 0.067;

        public static double ELEC_UNIT_UAE_EXPATS_FLAT_GREEN_LIMIT_17_SC = 79;
        public static double ELEC_UNIT_UAE_EXPATS_FLAT_GREEN_TARIFF_17_SC = 0;
        public static double ELEC_UNIT_UAE_EXPATS_FLAT_RED_TARIFF_17_SC = 0.268;

        public static double ELEC_UNIT_UAE_EXPATS_VILLA_GREEN_LIMIT_17_SC = 79;
        public static double ELEC_UNIT_UAE_EXPATS_VILLA_GREEN_TARIFF_17_SC = 0;
        public static double ELEC_UNIT_UAE_EXPATS_VILLA_RED_TARIFF_17_SC = 0.268;

        //============================================================================

        public static double WATER_UNIT_UAE_NATIONAL_FLAT_GREEN_LIMIT_16_SC = 9.804;
        public static double WATER_UNIT_UAE_NATIONAL_FLAT_GREEN_TARIFF_16_SC = 0;
        public static double WATER_UNIT_UAE_NATIONAL_FLAT_RED_TARIFF_16_SC = 1.7;

        public static double WATER_UNIT_UAE_NATIONAL_VILLA_GREEN_LIMIT_16_SC = 9.804;
        public static double WATER_UNIT_UAE_NATIONAL_VILLA_GREEN_TARIFF_16_SC = 0;
        public static double WATER_UNIT_UAE_NATIONAL_VILLA_RED_TARIFF_16_SC = 1.7;

        public static double WATER_UNIT_UAE_EXPATS_FLAT_GREEN_LIMIT_16_SC = 2.801;
        public static double WATER_UNIT_UAE_EXPATS_FLAT_GREEN_TARIFF_16_SC = 0;
        public static double WATER_UNIT_UAE_EXPATS_FLAT_RED_TARIFF_16_SC = 5.95;//9.90;// changed

        public static double WATER_UNIT_UAE_EXPATS_VILLA_GREEN_LIMIT_16_SC = 2.801;
        public static double WATER_UNIT_UAE_EXPATS_VILLA_GREEN_TARIFF_16_SC = 0;
        public static double WATER_UNIT_UAE_EXPATS_VILLA_RED_TARIFF_16_SC = 5.95;//9.90;// changed here

        public static double ELEC_UNIT_UAE_NATIONAL_FLAT_GREEN_LIMIT_16_SC = 333;
        public static double ELEC_UNIT_UAE_NATIONAL_FLAT_GREEN_TARIFF_16_SC = 0;
        public static double ELEC_UNIT_UAE_NATIONAL_FLAT_RED_TARIFF_16_SC = 0.05;

        public static double ELEC_UNIT_UAE_NATIONAL_VILLA_GREEN_LIMIT_16_SC = 333;
        public static double ELEC_UNIT_UAE_NATIONAL_VILLA_GREEN_TARIFF_16_SC = 0;
        public static double ELEC_UNIT_UAE_NATIONAL_VILLA_RED_TARIFF_16_SC = 0.05;

        public static double ELEC_UNIT_UAE_EXPATS_FLAT_GREEN_LIMIT_16_SC = 79;
        public static double ELEC_UNIT_UAE_EXPATS_FLAT_GREEN_TARIFF_16_SC = 0;
        public static double ELEC_UNIT_UAE_EXPATS_FLAT_RED_TARIFF_16_SC = 0.21;

        public static double ELEC_UNIT_UAE_EXPATS_VILLA_GREEN_LIMIT_16_SC = 79;
        public static double ELEC_UNIT_UAE_EXPATS_VILLA_GREEN_TARIFF_16_SC = 0;
        public static double ELEC_UNIT_UAE_EXPATS_VILLA_RED_TARIFF_16_SC = 0.21;
    }
}

