using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
    public class ChangePasswordReq
    {
        public Authentication userreq { get; set; }
        public string token { get; set; }
    }
}


//*******....{"token":"JLUKSdS31LI2vI0Z66bHyrRniE0Z4l7DDDsXDwBiCD4=","userreq":{"UserID":"msk111","Pwd":"qwe-1234"}}