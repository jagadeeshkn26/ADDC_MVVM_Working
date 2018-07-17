using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
    public class StatusResponse
    {
        [JsonProperty("Status")]
        public string ResponseStatus { get; set; }

        [JsonProperty("Code")]
        public string ResponseCode { get; set; }

        [JsonProperty("Description")]
        public string ResponseDescription { get; set; }
              
    }
     
}
