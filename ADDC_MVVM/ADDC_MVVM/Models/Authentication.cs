namespace ADDC_MVVM.Models
{
   public class Authentication
    {
        public string Pwd { get; set; }
        public string UserID { get; set; }        
    }

	public class JsonRes
	{
		public bool Status { get; set; }
		public string Code { get; set; }
		public string Description { get; set; }
		public AuthResponce AuthResponce { get; set; }
	}
}