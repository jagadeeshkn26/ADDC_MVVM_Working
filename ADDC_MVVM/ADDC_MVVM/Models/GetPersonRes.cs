using Newtonsoft.Json;

namespace ADDC_MVVM.Models
{
    internal class GetPersonRes
    {
        [JsonProperty("PersonID")]
        public string PID { get; set; }
    }
}