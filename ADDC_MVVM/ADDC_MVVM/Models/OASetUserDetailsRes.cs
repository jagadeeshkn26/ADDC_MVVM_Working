using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
   public class OASetUserDetailsRes
    {
        [JsonProperty("AuthResponce")]
        public AuthResponce AuthResponce { get; set; } //AuthResponce

        [JsonProperty("Status")]
        public string status { get; set; }

        [JsonProperty("Code")]
        public string code { get; set; }

        [JsonProperty("Description")]
        public string description { get; set; }
    }
}
