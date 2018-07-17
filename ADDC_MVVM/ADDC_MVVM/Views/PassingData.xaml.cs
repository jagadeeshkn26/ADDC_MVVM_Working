using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADDC_MVVM.Models;
using ADDC_MVVM.ViewModels;
using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
    public partial class PassingData : ContentPage
    {
        private GetGuestUserDetailsRes getGuestUserDetailsRes;

        public class demo
        {
            public string pkrPersonID { get; set; }
            public string pkrUserID { get; set; }
            public string pkrProfile { get; set; }
            public string pkrEmiratesId { get; set; }
            public string pkrPrimaryName { get; set; }
            public string pkrName1 { get; set; }
            public string pkrEmailID { get; set; }
            public string pkrPHNumber { get; set; }

        }
        
  

        public PassingData(GetGuestUserDetailsRes getGuestUserDetailsRes)
        {
            this.getGuestUserDetailsRes = getGuestUserDetailsRes;
            demo ola = new demo ();
            ola.pkrEmailID = getGuestUserDetailsRes.Resident.Person.EmailID;
            ola.pkrEmiratesId = getGuestUserDetailsRes.Resident.Person.EmiratesID;
            ola.pkrName1 = getGuestUserDetailsRes.Resident.Person.PrimaryName;
            ola.pkrPersonID = getGuestUserDetailsRes.Resident.Person.PersonID;
            ola.pkrPHNumber = getGuestUserDetailsRes.Profile.PersonID;
            ola.pkrPrimaryName = getGuestUserDetailsRes.Resident.Person.PrimaryName;
            ola.pkrProfile = getGuestUserDetailsRes.Profile.PersonID;
            ola.pkrUserID = getGuestUserDetailsRes.UserID;
            InitializeComponent();
            BindingContext = ola;
        }
    }
}
