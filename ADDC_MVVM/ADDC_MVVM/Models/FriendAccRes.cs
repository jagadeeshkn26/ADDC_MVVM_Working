using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
    class FriendAccRes
    {
        public object AccountID { get; set; }
        public string NickName { get; set; }
        public List<Premis> Premises { get; set; }
        public AuthResponce AuthResponce { get; set; }
        public double OutstandingBalance { get; set; }
        public object BillCycle { get; set; }
        public object BillRoute { get; set; }
        public object ElectricityMeterCollection { get; set; }
        public object WaterMeterCollection { get; set; }
        public bool IsMovedOut { get; set; }
        public bool IsActive { get; set; }
    }

    //public class Address
    //{
    //    public object Country { get; set; }
    //    public object AreaCode { get; set; }
    //    public string Address1 { get; set; }
    //    public string Address2 { get; set; }
    //    public string Address3 { get; set; }
    //    public string POBox { get; set; }
    //    public object Area { get; set; }
    //    public object City { get; set; }
    //    public int Emirate { get; set; }
    //}

    //public class Premis
    //{
    //    public object ID { get; set; }
    //    public string Type { get; set; }
    //    public object TariffType { get; set; }
    //    public object Description { get; set; }
    //    public Address Address { get; set; }
    //    public object ElectricityMeter { get; set; }
    //    public object WaterMeter { get; set; }
    //    public object ServiceAgreement { get; set; }
    //}

    //public class AuthResponce
    //{
    //    public string TokenID { get; set; }
    //    public string Code { get; set; }
    //    public string Description { get; set; }
    //}
}
