using System.Collections.Generic;

namespace ADDC_MVVM.Models
{
        public class Dictionary
        {
            public string Key { get; set; }
            public string Value { get; set; }


        }

        public class ForgotPwdQA
        {
            public int NotificationType { get; set; }
            public int Template { get; set; }
            public List<Dictionary> Dictionary { get; set; }
        }

    
}