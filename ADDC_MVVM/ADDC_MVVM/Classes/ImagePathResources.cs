
using Xamarin.Forms;

namespace ADDC_MVVM
{
    public static class ImagePathResources
    {
        public static readonly string BackgroundImagePath = Device.OnPlatform("landing_content_bg.png", "landing_content_bg.png", "landing_content_bg.png");
        public static readonly string HeaderBackgroundImagePath = Device.OnPlatform("header.png", "border_design_top_ar.png", "landing_content_bg.png");
        public static readonly string MenuBackgroundImagePath = Device.OnPlatform(" menu_bg.png", "menu_bg.png", "landing_content_bg.png");
       
    }
}
