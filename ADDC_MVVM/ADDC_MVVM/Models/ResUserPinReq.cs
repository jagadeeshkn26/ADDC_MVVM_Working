using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
    class ResUserPinReq
    {

        public string EmiratesID { get; set; }
        public string ActivationRequest { get; set; }
    }

    class ActivationRequest
    {
        public string AccountNumber { get; set; }

    }
}
