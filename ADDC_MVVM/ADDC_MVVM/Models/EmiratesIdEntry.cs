using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
    public class EmiratesIdEntry
    {
        //[JsonProperty("ResidentialActivationResponse")]
        //public JsonObjectAttribute ResidentialActivationResponse { get; set; }
        [JsonProperty("ResidentialActivationResponse")]
        public ResidentialActivationResponse residentialActivationResponse { get; set; }

        
        public class ResidentialActivationResponse
        {
            [JsonProperty("PersonID")]
            public string PersonID { get; set; }

            [JsonProperty("StatusResponse")]
            public StatusResponse statusResp { get; set; }

        }
    }
}
