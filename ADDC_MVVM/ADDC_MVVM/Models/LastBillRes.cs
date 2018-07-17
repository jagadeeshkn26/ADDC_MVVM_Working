using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{


    public class LastBillRes
    {
        public DateTime Date { get; set; }
        public int PreviousCharges { get; set; }
        public int PaymentsReceived { get; set; }
        public double CurrentCycleCharges { get; set; }
        public int OtherCharges { get; set; }
        public int AdjustmentsAndCorrection { get; set; }
        public int TotalDue { get; set; }
        public ElectricityConsumption ElectricityConsumption { get; set; }
        public WaterConsumption WaterConsumption { get; set; }
        public object BillInfo { get; set; }
        public DateTime DueDate { get; set; }
        public string BillID { get; set; }
        public AuthResponce AuthResponce { get; set; }
    }

    public class LastBillResp
    {
       
        public object Date { get; set; }
        public double PreviousCharges { get; set; }
        public double PaymentsReceived { get; set; }
        public double CurrentCycleCharges { get; set; }
        public int OtherCharges { get; set; }
        public int AdjustmentsAndCorrection { get; set; }
		public string MunicipalBalanceAmt { get; set; }
        public double TotalDue { get; set; }
        public ElectricityConsumption ElectricityConsumption { get; set; }
        public WaterConsumption WaterConsumption { get; set; }
        public object BillInfo { get; set; }
        public object DueDate { get; set; }
        public object BillID { get; set; }
        public AuthResponce AuthResponce { get; set; }
    
}
    public class ElectricityConsumption
    {
        public double TotalCharges { get; set; }
        public double GreenTariff { get; set; }
        public int GreenCosumption { get; set; }
        public double GreenCharges { get; set; }
        public double RedTariff { get; set; }
        public double RedConsumption { get; set; }
        public double RedCharges { get; set; }
    }

    public class WaterConsumption
    {
        public double TotalCharges { get; set; }
        public double GreenTariff { get; set; }
        public double GreenCosumption { get; set; }
        public double GreenCharges { get; set; }
        public double RedTariff { get; set; }
        public double RedConsumption { get; set; }
        public double RedCharges { get; set; }
    }


   
}
