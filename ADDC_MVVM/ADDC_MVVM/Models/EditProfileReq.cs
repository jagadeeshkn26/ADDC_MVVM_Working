using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
    public class MasterDataPropRq
    {
        public string ID { get; set; }
    }

    public class SecretQuestionRq
    {
        public string QuestionArabic { get; set; }
        public string QuestionEnglish { get; set; }
        public MasterDataPropRq _MasterDataProp { get; set; }
    }

    public class ContactPreferenceRq
    {
        public int ContactMode { get; set; }
    }

    public class ProfileRq
    {
        public string PersonID { get; set; }
        public SecretQuestionRq SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public ContactPreferenceRq ContactPreference { get; set; }
    }

    public class PhoneRq
    {
        public int Type { get; set; }
        public string Number { get; set; }
        public int Version { get; set; }
        public int Sequence { get; set; }
        public string RowAction { get; set; }
    }
    public class PhoneRqAdd
    {
        public int Type { get; set; }
        public string Number { get; set; }
        public string RowAction { get; set; }
    }
    

    public class PersonRq
    {
        public string PersonID { get; set; }
        public string EmailID { get; set; }
        public List<object> Phone { get; set; }
        public BillRoute BillRoute { get; set; }
        public int LanguagePreference { get; set; }
        public Address Address { get; set; }
    }

    public class ResidentRq
    {
        public PersonRq Person { get; set; }
    }

    public class Userdetails
    {
        public string PersonID { get; set; }
        public string UserID { get; set; }
        public ProfileRq Profile { get; set; }
        public ResidentRq Resident { get; set; }
        public bool isMigrated { get; set; }
    }

    public class EditProfileReq
    {
        public string token { get; set; }
        public Userdetails userdetails { get; set; }
    }
   
}
