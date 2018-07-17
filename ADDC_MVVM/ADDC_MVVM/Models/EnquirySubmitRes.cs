using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{

    public class Enquiry
    {
        public string RequestNumber { get; set; }
        public bool IsAuthenticated { get; set; }
        public object PersonID { get; set; }
        public object EnquiryType { get; set; }
        public object ProblemType { get; set; }
        public object EmailID { get; set; }
        public object AccountNumber { get; set; }
        public object Description { get; set; }
        public int RelatedToPremise { get; set; }
        public object PremiseID { get; set; }
        public object MobileNumber { get; set; }
        public object DocumentURL { get; set; }
	}

    public class EnquirySubmitRes
    {
        public StatusResponse StatusResponse { get; set; }
        public Enquiry Enquiry { get; set; }
    }

}
