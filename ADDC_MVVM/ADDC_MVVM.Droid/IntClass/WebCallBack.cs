using System;
using Android.Content;
using ADDC_MVVM.Models;
using Xamarin.Forms;
using ADDC_MVVM.Interfaces;
using ADDC_MVVM.Views;

namespace ADDC_MVVM.Droid.IntClass
{
   public class webCallBackAnd : webCallBack

    {
        public event EventHandler<WebResp> positionChanged;
        public  webCallBack mySelf;
        public void start()
        {
          //  mySelf = this;
            Forms.Context.StartService(new Intent(Forms.Context, typeof(HybridWebViewRenderer)));

        }
        public void receivedNewPosition(string pos)
        {
            positionChanged(this, new WebResp(pos));
        }
    }
}