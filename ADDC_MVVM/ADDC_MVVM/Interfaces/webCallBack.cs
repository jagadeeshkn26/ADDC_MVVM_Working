using ADDC_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADDC_MVVM.Interfaces
{
   public interface webCallBack
    {
        void start();

        event EventHandler<WebResp> positionChanged;
    }

}
