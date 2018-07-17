using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{

    public class MyAccountDetails
    {
        public List<AccountDetailsRes> AccountDetails { get; set; }
        public PageSettings PageSettings { get; set; }
        public string PositiveBalAccountsCount { get; set; }
        public AuthResponce AuthResponce { get; set; }
    }
}
