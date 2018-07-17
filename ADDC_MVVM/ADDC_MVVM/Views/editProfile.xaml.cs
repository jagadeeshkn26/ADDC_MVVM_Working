using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADDC_MVVM.Models;
using Xamarin.Forms;
using System.Net.Http;
using ModernHttpClient;
using System.Diagnostics;
using Newtonsoft.Json;
using ADDC_MVVM.ViewModels;

namespace ADDC_MVVM.Views
{
    public class CardTemplateModel
    {
        public string phoneNumber { get; set; }
        public string phoneNumbertype { get; set; }

        public int index { get; set; }
    }
    public partial class editProfile : ContentPage
    {
        public static int btnCtr = 0;
        public int phonetype;
        private ResidentRq resident;
        private PhoneRq phone = new PhoneRq();
        private List<PhoneRq> phonelst = new List<PhoneRq>();
        public GetGuestUserDetailsRes userDetails;
        private Profile Profile;

        public ObservableCollection<PhoneRq> card { get; set; }
        public editProfile()
        {
          
          
        }

	//	 [JsonProperty("Number")]
	//	public string Number { get; set; }


		public editProfile(GetGuestUserDetailsRes userDetail)
        {
            InitializeComponent();
            userDetails = new GetGuestUserDetailsRes();
            userDetails = userDetail;
            Profile = userDetail.Profile;
            resident = new ResidentRq();
            resident.Person = new PersonRq();
            card = new ObservableCollection<PhoneRq>();
            resident.Person.PersonID = userDetails.Resident.Person.PersonID;
            resident.Person.LanguagePreference = userDetails.Resident.Person.LanguagePreference;
            resident.Person.EmailID = userDetails.Resident.Person.EmailID;
            resident.Person.BillRoute = new BillRoute();
            resident.Person.BillRoute.BillPreference = userDetails.Resident.Person.BillRoute.BillPreference;
            resident.Person.Phone = new List<object>();
	
			customerID.Text = userDetails.PersonID;
			userName.Text = userDetails.UserID;//Resident.Person.Name[0].Name1;
			eMailID.Text = userDetails.Resident.Person.EmailID;
			customerName.Text = userDetails.Resident.Person.Name[0].Name1;
			//LangPicker.Items.Add
			if (resident.Person.BillRoute.BillPreference == 0)
			{
				ArabicBtn.BackgroundColor = Color.White;
				EnglishBtn.BackgroundColor = Color.FromHex("#D0E766");			
			}
			else
			{
				ArabicBtn.BackgroundColor = Color.FromHex("#D0E766");
				EnglishBtn.BackgroundColor = Color.White;
			}
            foreach (var item in userDetails.Resident.Person.Phone)
            {
                phone.Number = item.Number;
                phone.RowAction = "Upadd";
                phone.Sequence = item.Sequence;
                phone.Type = item.Type;
                phone.Version = item.Version;
               // phonelst.Add(phone);
                //resident.Person.Phone.Add(phone);
               // card.Add(phone);
            }
            for(int i = 0; i < userDetails.Resident.Person.Phone.Count; i++)
            {
                PhoneRq phone1 = new PhoneRq(); ;
                if (phone1 != null)
                {
                    phone1 = null;
                   phone1 = new PhoneRq();
                }
                
                phone1.Number = userDetails.Resident.Person.Phone[i].Number;
                phone1.RowAction = "Upadd";
                phone1.Sequence = userDetails.Resident.Person.Phone[i].Sequence;
                phone1.Type = userDetails.Resident.Person.Phone[i].Type;
                phone1.Version = userDetails.Resident.Person.Phone[i].Version;
                phonelst.Add(phone1);
                //resident.Person.Phone.Add(phone);
                card.Add(phone1);

            }
           

            //PhoneRq card_0 = new PhoneRq();

			//card.Add(card_0);

            listView.ItemsSource = card;
        }

void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			int index = card.IndexOf((PhoneRq)((Entry)sender).BindingContext);
			// ((PhoneRq)((Entry)sender).BindingContext)
			if (card[index].Number.Length == 3)
			{
				card[index].Number = card[index].Number + "-";

				card[index].Number.Insert(index, card[index].Number + "-");
				}
			listView.ItemsSource = card;
		}

		void English_Clicked(object sender, System.EventArgs e)
		{
			resident.Person.BillRoute.BillPreference = 0;
			ArabicBtn.BackgroundColor = Color.White;
			EnglishBtn.BackgroundColor = Color.FromHex("#D0E766");
		}

		async void OnTapMenu(object sender, System.EventArgs e)
		{
			await Navigation.PopModalAsync();
		}

		void Arabic_Clicked(object sender, System.EventArgs e)
		{
			resident.Person.BillRoute.BillPreference = 1;
			ArabicBtn.BackgroundColor = Color.FromHex("#D0E766");
			EnglishBtn.BackgroundColor = Color.White;
		}

		private void OnAddCardButtonClicked(object sender, EventArgs e)
        {
            btnCtr++;

            if (btnCtr > 9)
            {
                btnCtr--;
                DisplayAlert("Alert", "You cannot save more than 10 Cards", "Ok");

            }

            else
            {
                PhoneRq card_temp = new PhoneRq();
                card_temp.RowAction = "add";
                card_temp.Type = 3;
                phonelst.Add(card_temp);
                card.Add(card_temp);
              // card_temp.Number = phoneNumberEntry.Text;
              

                //if (card_temp.Type == "Home")
                //{
                //    card_temp.index = 0;
                //}

                //else if (card_temp.phoneNumbertype == "Work")
                //{
                //    card_temp.index = 1;
                //}

                //else if (card_temp.phoneNumbertype == "Mobile")
                //{
                //    card_temp.index = 1;
                //}


                //else
                //{
                //    card_temp.index = -1;
                //}

            }
        }

		private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (IsBusy)
                return;

            Exception error = null;
            try
            {
                resident.Person.Phone.Clear();
                foreach (var item in phonelst)
                {

                   
                    
                    if (item.RowAction == "Delete" || item.RowAction == "Upadd")
                    {
                        PhoneRq add = new PhoneRq();

                        add.Number = item.Number;
                        add.RowAction = item.RowAction;
                        add.Type = item.Type;
                        add.Sequence = item.Sequence;
                        add.Version = item.Version;

                        resident.Person.Phone.Add(add);
                    }
                    else
                    {
                        PhoneRqAdd phoneRqAdd = new PhoneRqAdd();

                        phoneRqAdd.Number = item.Number;
                        phoneRqAdd.RowAction = item.RowAction;
                        phoneRqAdd.Type = item.Type;
                        resident.Person.Phone.Add(phoneRqAdd);
                    }
                   
                  

                }
                IsBusy = true;
                string tokenID = Application.Current.Properties["TokenID"].ToString();
                string PersonID = Application.Current.Properties["PersonID"].ToString();
                using (var client = new HttpClient(new NativeMessageHandler()))
                {
                    MasterDataPropRq masterDataProp = new MasterDataPropRq() { ID = userDetails.Profile.SecretQuestion._MasterDataProp.ID};
                    SecretQuestionRq SecretQuestion = new SecretQuestionRq() {QuestionArabic = userDetails.Profile.SecretQuestion.QuestionArabic, QuestionEnglish = userDetails.Profile.SecretQuestion.QuestionEnglish, _MasterDataProp = masterDataProp };
                    ContactPreferenceRq contactPreference = new ContactPreferenceRq() { ContactMode = userDetails.Profile.ContactPreference.ContactMode };
                    ProfileRq profile = new ProfileRq() { ContactPreference = contactPreference, PersonID = userDetails.PersonID, SecretQuestion = SecretQuestion, SecretAnswer = userDetails.Profile.SecretAnswer };
                    Userdetails userdetailsRq = new Userdetails() { PersonID = PersonID, UserID = userDetails.UserID, Profile = profile, Resident = resident, isMigrated = userDetails.isMigrated };
                    EditProfileReq parameter2 = new EditProfileReq() {token = tokenID , userdetails = userdetailsRq };

                    var jsonParameter = JsonConvert.SerializeObject(parameter2);
                    var requestUrl = Constants.BaseAddressUrl + "/UserService.svc/SetUserDetails";

                    client.BaseAddress = new Uri(Constants.BaseAddressUrl);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.PostAsync(requestUrl, new StringContent(jsonParameter, Encoding.UTF8, "application/json"));
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    Debug.WriteLine(json.ToString());
                    userDetails = JsonConvert.DeserializeObject<GetGuestUserDetailsRes>(json);
                    if (userDetails!= null || userDetails.AuthResponce != null)
                    {
                        Application.Current.Properties["TokenID"] = userDetails.AuthResponce.TokenID;
                        Application.Current.Properties["UserID"] = userDetails.UserID;

                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex); //to show Network error...
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");

        
    }
            
        private void btnDeleteRowClicked(Object sender, EventArgs EventArgs)
        {
           
            var temp = ((Button)sender).Id;
            if (btnCtr > 0)
            {
                btnCtr--;
            }
             int index =card.IndexOf((PhoneRq)((Button)sender).CommandParameter);

			if (index == 0)
			{
			}
			else
			{
				phonelst[index].RowAction = "Delete";
				card.Remove((PhoneRq)((Button)sender).CommandParameter);
				//  resident.Person.Phone[index].RowAction = "Delete";
			}
        }

        private void OnSelectingPhoneNumberType(Object sender, EventArgs e)
        {
			int index = card.IndexOf((PhoneRq)((Picker)sender).BindingContext);
			/// var index = card.IndexOf((PhoneRq)((Picker)sender).Items.);
			if (index >= 0)
			{
				phonetype = ((Picker)sender).SelectedIndex;
				card[index].Type = phonetype;
			}

        }

        private void OnPasswordButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ChangePassword() { BindingContext = new ChangePasswordViewModel() });
        }
    }
}
