
namespace ADDC_MVVM.ViewModels
{
    public class OAGeneratePinViewModel : ViewModelBase
    {
        public OAGeneratePinViewModel()
        {
             ResponseStatus = "Test";
        }
        private string _responseStatus;
        public string ResponseStatus
        {
            get { return _responseStatus; }
            set { SetProperty(ref _responseStatus, value); }
        }
    }
}