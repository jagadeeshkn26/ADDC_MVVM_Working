using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ADDC_MVVM.Models
{
    public class ChangePasswordRes 
    {
        //*******....{"TokenID":"JLUKSdS31LI2vI0Z66bHyhNrvoz2fNV0FEovdybc37A=","Code":"100","Description":"Password Changed"}
        [JsonProperty("TokenID")]
        public string tokenID { get; set; }

        [JsonProperty("Code")]
        public string code { get; set; }

        [JsonProperty("Description")]
        public string description { get; set; }

    }
}
