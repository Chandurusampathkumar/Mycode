using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo
{
    public class BasicInfoModel:AddGuestModel
    {
        public const string InputFileName = "BasicInfoDataSet.csv";

        public const string GuestInfoHost_ByID = "GuestInfoScreen.Screen";
        public const string BasicInfoHost_ByID = "BasicInfoScreen";
        public const string MailingAddressHost_ByID = "MailingAddressScreen.Screen";
        public const string BillingAddressHost_ByID = "BillingAddressScreen.Screen";
        public const string InsuranceHost_ByID = "InsuranceScreen.Screen";
        public const string ContactHost_ByID = "PersonalContactsScreen";

        public const string SameAsMailing_ByID = "BillingAddressScreen.SameAsMailingAddress.Checkbox";
        public const string AddContacts_ByID = "PersonalContactsScreen.AddContacts.Button";
        public const string AddCard_ByID = "GuestInfoScreen.AddCard.Button";

        public const string GuestInfoFirst_ByAutoID = "GuestInfo.BasicInfo.FirstName.TextBox.Text";
        public const string GuestInfoFirstError_ByID = "GuestInfo.BasicInfo.FirstName.TextBox.ErrorMessage.Text";

        public const string GuestInfoLast_ByAutoID = "GuestInfo.BasicInfo.LastName.TextBox.Text";
        public const string GuestInfoLastError_ByID = "GuestInfo.BasicInfo.LastName.TextBox.ErrorMessage.Text";

        public const string GuestInfoMI_ByAutoID = "GuestInfo.BasicInfo.MiddleInitial.TextBox.Text";
        public const string GuestInfoMIError_ByID = "GuestInfo.BasicInfo.MiddleInitial.TextBox.ErrorMessage.Text";

        public const string GuestInfoDOB_ByAutoID = "NasicInfoScreen.DOB";
        public const string GenderMale_ByAutoID = "GuestInfo.BasicInfo.GenderRadioButtonGroup.Male";
        public const string GenderFemale_ByAutoID = "GuestInfo.BasicInfo.GenderRadioButtonGroup.Female";

        public const string PhoneNo_ByAutoID = "GuestInfo.BasicInfo.PhoneNumber.TextBox.Text";
        public const string PhoneNoError_ByID = "GuestInfo.BasicInfo.PhoneNumber.TextBox.ErrorMessage.Text";

        public const string EmailID_ByID = "GuestInfo.BasicInfo.Email.TextBox.Text";
        public const string EmailIDError_ByID = "GuestInfo.BasicInfo.Email.TextBox.ErrorMessage.Text";

        public const string Street_ByName = "Street 1 *"; //TODO: AutomationId Available 
        public const string Zip_ByName = "Zip *"; //TODO: AutomationId Available 
        public const string SameAsMailingAdd_ByAutoId = "SameAsMailingAddressCheckBox";
        public const string VerifyID_ByAutoID = "GuestInfo.BasicInfo.VerifyGuestId.CheckBox";
        public const string ScrollViewer_ByClassName = "ScrollViewer";      

        public const string Next_ByID = "GuestInfo.ActiveLabOrders.Next.Button";
        public const string Back_ByID = "GuestInfo.ActiveLabOrders.Back.Button";

        public const string DOB_ByID = "CheckinStepsControl.DateOfBirth.TextBlock";
        public const string Gender_ByID = "CheckinStepsControl.Gender.TextBlock";
        public const string Email_ByID = "CheckinStepsControl.Email.TextBlock";
        public const string EmailCheckbox_ById = "GuestInfo.BasicInfo.NoEmail.CheckBox";
        public const string MaleGender = "Male";
        public const string FemaleGender="Female";

        public const string GuardianPopup_ByID = "PopupGuestArrivedWithGuardian.Screen";
        public const string GuardianYes_ByID = "PopupGuestArrivedWithGuardian.Yes.RadioButton";
        public const string GuardianNo_ByID = "PopupGuestArrivedWithGuardian.No.RadioButton";
        public const string GuardianFirstName_ByID = "PopupGuestArrivedWithGuardian.AddGuardian.FirstName.TextBox.Text";
        public const string GuardianLastName_ByID = "PopupGuestArrivedWithGuardian.AddGuardian.LastName.TextBox.Text";
        public const string GuardianRelationship_ById = "PopupGuestArrivedWithGuardian.AddGuardian.Relationships.ComboBox.Combo";
        public const string GuardianPhone_ByID = "PopupGuestArrivedWithGuardian.AddGuardian.Phone.TextBox.Text";
        public const string GuardianDOB_ByID = "PopupGuestArrivedWithGuardian.AddGuardian.DateOfBirth.TextBox";
        public const string GuardianOkButton_ByID = "PopupGuestArrivedWithGuardian.Submit.Button";

        public const string ExistingGuest = "OLD";
        public const string NewGuest = "NEW";
        public const string Male = "M";
        public const string Female = "F";
        public const string Major = "Major";
        public const string Minor = "Minor";


        //Basic Info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MI { get; set; }
        public string DOB { get; set; }
        public string Gender { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNo { get; set; }
        //public string Email { get; set; }
        public string Status { get; set; }
        public string AgeGroup { get; set; }
    }
}
