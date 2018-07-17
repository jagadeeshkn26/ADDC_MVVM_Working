using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Models
{
   public class WebResp
    {
        private string pos;

        public WebResp(string pos)
        {
            this.pos = pos;
        }

        public string WebValue { get; set; }
    }
}
