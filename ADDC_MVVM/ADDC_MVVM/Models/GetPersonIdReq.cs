using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
    public class GetPersonIdReq
    {
        public string ID { get; set; }
        public PersonFetchConfiguration PersonFetchConfiguration { get;  set; }
       

    }

   
}
