using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo
{
    public class AddressModel:AddGuestModel
    {
        public const string InputFileName = "AddressDataSet.csv";

        public const string MailingStreet1_ByID = "MailingAddressScreen.Street1.TextBox.Text";
        public const string MailingStreet1Error_ByID = "MailingAddressScreen.Street1.TextBox.ErrorMessage.Text";

        public const string MailingStreet2_ByID = "MailingAddressScreen.Street2.TextBox.Text";
        public const string MailingStreet2Error_ByID = "MailingAddressScreen.Street2.TextBox.ErrorMessage.Text";

        public const string MailingZipcode_ByID = "MailingAddressScreen.Zip.TextBox.Text";
        public const string MailingZipcodeError_ByID = "MailingAddressScreen.Zip.TextBox.ErrorMessage.Text";

        public const string MailingCity_ByID = "MailingAddressScreen.City.TextBox.Text";
        public const string MailingCityError_ByID = "MailingAddressScreen.City.TextBox.ErrorMessage.Text";

        public const string MailingState_ByID = "MailingAddressScreen.State.TextBox.Text";
        public const string MailingStateError_ByID = "MailingAddressScreen.State.TextBox.ErrorMessage.Text";

        public const string MailingCountry_ByID = "MailingAddressScreen.Country.ComboBox.Combo";
        
        public const string CountryError_ByID = "ErrorMessageBlock"; //Same ID for both Mailing and Billing Address

        public const string SameAsMailing_ByID = "BillingAddressScreen.SameAsMailingAddress.Checkbox";

        public const string BillingStreet1_ByID = "BillingAddressScreen.Street1.TextBox.Text";
        public const string BillingStreet1Error_ByID = "BillingAddressScreen.Street1.TextBox.ErrorMessage.Text";

        public const string BillingStreet2_ByID = "BillingAddressScreen.Street2.TextBox.Text";
        public const string BillingStreet2Error_ByID = "BillingAddressScreen.Street2.TextBox.ErrorMessage.Text";

        public const string BillingZipcode_ByID = "BillingAddressScreen.Zip.TextBox.Text";
        public const string BillingZipcodeError_ByID = "BillingAddressScreen.Zip.TextBox.ErrorMessage.Text";

        public const string BillingCity_ByID = "BillingAddressScreen.City.TextBox.Text";
        public const string BillingCityError_ByID = "BillingAddressScreen.City.TextBox.ErrorMessage.Text";

        public const string BillingState_ByID = "BillingAddressScreen.State.TextBox.Text";
        public const string BillingStateError_ByID = "BillingAddressScreen.State.TextBox.ErrorMessage.Text";

        public const string BillingCountry_ByID="BillingAddressScreen.Country.ComboBox.Combo";

        public const string MailingAddressHost_ByID = "MailingAddressScreen.Screen";
        public const string State_ByID = "MailingAddressScreen.Country.ComboBox.Combo";
    
      

        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Zipcode { get; set; }
        // City, State, Country

    }
}
