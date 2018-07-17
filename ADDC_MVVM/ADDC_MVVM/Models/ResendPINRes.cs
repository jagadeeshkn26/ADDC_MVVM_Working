using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
    public class ResendPINRes
    {

        [JsonProperty("Status")]
        public string status { get; set; }

        [JsonProperty("Code")]
        public string code { get; set; }

        [JsonProperty("Description")]
        public string description { get; set; }
    }
}

//{"StatusResponse":{"Status":true,"Code":"100","Description":"Method Call Successful","AuthResponce":null},"EmailID":"sandeep.nitchenametla@wipro.com","AuthResponce":null}