using Newtonsoft.Json;
using System.Collections.Generic;

namespace ADDC_MVVM.Models
{
    public class MyAccount
    {
        [JsonProperty("AccountID")]
        public string AccountID { get; set; }

        [JsonProperty("NickName")]
        public string NickName { get; set; }

        [JsonProperty("Premises")]
        public List<Premis> Premises { get; set; }

        [JsonProperty("AuthResponce")]
        public object AuthResponce { get; set; }

        [JsonProperty("OutstandingBalance")]
        public double OutstandingBalance { get; set; }

        [JsonProperty("BillCycle")]
        public object BillCycle { get; set; }

        [JsonProperty("BillRoute")]
        public object BillRoute { get; set; }

        [JsonProperty("ElectricityMeterCollection")]
        public object ElectricityMeterCollection { get; set; }

        [JsonProperty("WaterMeterCollection")]
        public object WaterMeterCollection { get; set; }

        [JsonProperty("IsMovedOut")]
        public bool IsMovedOut { get; set; }

        [JsonProperty("IsActive")]
        public bool IsActive { get; set; }
    }
}