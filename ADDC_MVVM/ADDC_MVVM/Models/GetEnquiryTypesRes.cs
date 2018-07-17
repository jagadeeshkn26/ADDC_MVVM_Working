using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
    public class MasterDataEnqTpy
    {
        public string ID { get; set; }
        public object Value { get; set; }
    }

    public class GetEnquiryTypesRes
    {
        public string EnquiryTypeArabic { get; set; }
        public string EnquiryTypeEnglish { get; set; }
        public MasterDataEnqTpy MasterDataEnqTpy { get; set; }
    }
  
}
