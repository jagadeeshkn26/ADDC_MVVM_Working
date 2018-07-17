
namespace ADDC_MVVM.Models
{

    public class EnquiryType
    {
        public string Code { get; set; }
    }

    public class EnquirySubmitReq
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string RelatedToPremise { get; set; }
        public string EmailID { get; set; }
        public string AccountNumber { get; set; }
        public string PersonID { get; set; }
        public EnquiryType EnquiryType { get; set; }
        public string AuthenticationToken { get; set; }
    }
   
}
