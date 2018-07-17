using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADDC_MVVM.Models;
using Xamarin.Forms;

namespace ADDC_MVVM.Views
{
    public partial class OAGeneratePinView : ContentPage
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

        public OAGeneratePinView(GetGuestUserDetailsRes getGuestUserDetailsRes)
        {
            demo ola = new demo();
            ola.pkrEmiratesId = getGuestUserDetailsRes.PersonID;
            ola.pkrName1 = getGuestUserDetailsRes.Resident.Person.Name[0].Name1;
            //ola.Name = data;
            //this.getGuestUserDetailsRes = getGuestUserDetailsRes;
            InitializeComponent();
            BindingContext = ola;
        }
        /// <summary>
        /// ////////////////////////////////
        /// </summary>
       

      
    }
}
