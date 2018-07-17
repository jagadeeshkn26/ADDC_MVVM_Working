using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{


    public class Premis
    {
        public string ID { get; set; }
        public string Type { get; set; }
        public object TariffType { get; set; }
        public object Description { get; set; }
        public Address Address { get; set; }
        public object ElectricityMeter { get; set; }
        public object WaterMeter { get; set; }
        public object ServiceAgreement { get; set; }
    }

    

    public class MasterData
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }

    public class BillCycle
    {
        public MasterData MasterData { get; set; }
    }

   

    public class ServiceAgreement
    {
        public string ID { get; set; }
        public string TariffType { get; set; }
    }

    public class ElectricityMeter
    {
        public string BadgeNumber { get; set; }
        public string ID { get; set; }
        public string LastReadOn { get; set; }
        public object Type { get; set; }
        public ServiceAgreement ServiceAgreement { get; set; }
    }

    public class ElectricityMeterCollection
    {
        public List<ElectricityMeter> ElectricityMeter { get; set; }
    }

    public class ServiceAgreement2
    {
        public string ID { get; set; }
        public string TariffType { get; set; }
    }

    public class WaterMeter
    {
        public string BadgeNumber { get; set; }
        public string ID { get; set; }
        public string LastReadOn { get; set; }
        public object Type { get; set; }
        public ServiceAgreement2 ServiceAgreement { get; set; }
    }

    public class WaterMeterCollection
    {
        public List<WaterMeter> WaterMeter { get; set; }
    }

    public class AccountDetailsRes
    {
        public string AccountID { get; set; }
        public string NickName { get; set; }
        public List<Premis> Premises { get; set; }
        public AuthResponce AuthResponce { get; set; }
        public string OutstandingBalance { get; set; }
        public BillCycle BillCycle { get; set; }
        public BillRoute BillRoute { get; set; }
        public ElectricityMeterCollection ElectricityMeterCollection { get; set; }
        public WaterMeterCollection WaterMeterCollection { get; set; }
        public bool IsMovedOut { get; set; }
        public bool IsActive { get; set; }
    }
    
}
