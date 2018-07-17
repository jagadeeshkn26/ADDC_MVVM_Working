using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{




    public class CLBillFilter
    {
        public AccountRequested AccountRequest { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public bool PayByDateDesc { get; set; }
        public PageSettings PageSettings { get; set; }
        public BillFetchConfiguration BillFetchConfiguration { get; set; }

    }

    public class BillHistoryReq
    {
        public string token { get; set; }
        public CLBillFilter CL_BillFilter { get; set; }
    }
}
