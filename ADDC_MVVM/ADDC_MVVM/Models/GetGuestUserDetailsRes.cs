using System.Collections.Generic;

namespace ADDC_MVVM.Models
{
    public class MasterDataProp
    {
        public string ID { get; set; }
        public object Value { get; set; }
    }

    public class SecretQuestion
    {
        public string QuestionArabic { get; set; }
        public string QuestionEnglish { get; set; }
        public MasterDataProp _MasterDataProp { get; set; }
    }

    public class ContactPreference
    {
        public int ContactMode { get; set; }
        public bool SubscribedToNewsLetters { get; set; }
    }

    public class Profile
    {
        public string PersonID { get; set; }
        public SecretQuestion SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public ContactPreference ContactPreference { get; set; }
    }

    public class Name
    {
        public string Type { get; set; }
        public string Name1 { get; set; }
        public bool IsPrimary { get; set; }
    }

	 public class PhoneBind
	{
		public int Type { get; set; }

		public string Number { get; set; }
		public string Extension { get; set; }
		public string Mask { get; set; }
		public int Version { get; set; }
		public int Sequence { get; set; }
		public string RowAction { get; set; }
	}

    public class Phone
    {
        public int Type { get; set; }
        public string InternationalPrefix { get; set; }
        public string Number { get; set; }
        public string Extension { get; set; }
        public string Mask { get; set; }
        public int Version { get; set; }
        public int Sequence { get; set; }
        public string RowAction { get; set; }
    }

    public class BillRoute
    {
        public int BillPreference { get; set; }
    }

    public class Address
    {
        public string Country { get; set; }
        public string AreaCode { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string POBox { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public int Emirate { get; set; }
    }

    public class Person
    {
        public string PersonID { get; set; }
        public string PrimaryName { get; set; }
        public List<Name> Name { get; set; }
        public string EmailID { get; set; }
        public List<Phone> Phone { get; set; }
        public BillRoute BillRoute { get; set; }
        public int LanguagePreference { get; set; }
        public string Nationality { get; set; }
        public object NickName { get; set; }
        public Address Address { get; set; }
        public object DateOfBirth { get; set; }
        public string EmiratesID { get; set; }
        public string PassportNumber { get; set; }
        public int Gender { get; set; }
    }

    public class Resident
    {
        public object EmiratesId { get; set; }
        public Person Person { get; set; }
    }

    public class GetGuestUserDetailsRes
    {
        public string PersonID { get; set; }
        public string UserID { get; set; }
        public Profile Profile { get; set; }
        public Resident Resident { get; set; }
        public bool isMigrated { get; set; }
        public object DocumentLink { get; set; }
        public AuthResponce AuthResponce { get; set; }
    }

    public class AuthResponce
    {
        public string TokenID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
