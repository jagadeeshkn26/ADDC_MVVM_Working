using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
    public class GetSavedCardRes
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Number")]
        public string Number { get; set; }

        [JsonProperty("Brand")]
        public string Brand { get; set; }
    }
}

