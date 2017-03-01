using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo
{
    public class ContactModel:AddGuestModel
    {
        public const string InputFileName = "ContactDataSet.csv";

        public const string AddContacts_ByName = "+ ADD CONTACTS";
        public const string AddContacts_ByID = "PersonalContactsScreen.AddContacts.Button";

        public const string ContactsHost_ByID = "PersonalContactsScreen";
        public const string ContactListItem_ByName = "Theranos.PSC.UX.Model.Guest.ContactInfoEx";
        public const string AddContactPopup_ByID = "PopupAddEditContactScreen.Screen";
        
        public const string FirstName_ByID = "PopupAddEditContactScreen.FirstName.TextBox.Text";
        public const string Text_ByClass = "TextBlock";
        public const string FirstNameErrorMessage_ByID = "PopupAddEditContactScreen.FirstName.TextBox.ErrorMessage.Text";

        public const string LastName_ByID = "PopupAddEditContactScreen.LastName.TextBox.Text";
        public const string LastNameErrorMessage_ByID = "PopupAddEditContactScreen.LastName.TextBox.ErrorMessage.Text";

        public const string Relationship_ByID = "PopupAddEditContactScreen.Relationship.ComboBox.Combo";
        public const string RelationshipErrorMessage_ByID = "ErrorMessageBlock";

        public static string[] ExpectedRelationships = { "Associate", "Brother", "Care giver", "Child", "Handicapped Dependent", "Life Partner", "Emergency Contact", "Employee", "Employer", "Extended Family", "Foster Child", "Friend", "Father", "Grandchild", "Guardian", "GrandParent", "Manager", "Mother", "Natural Child", "None", "Other Adult", "Other", "Owner", "Parent", "Stepchild", "Self", "Sibling", "Sister", "Spouse", "Trainer", "Unknown", "Ward of Court" };

        public const string PhoneNumer_ByID = "PopupAddEditContactScreen.Phone.TextBox.Text";
        public const string PhoneNumberErrorMessage_ByID = "PopupAddEditContactScreen.Phone.TextBox.ErrorMessage.Text";

        public const string Email_ByID = "PopupAddEditContactScreen.Email.TextBox.Text";
        public const string EmailErrorMessage_ByID = "PopupAddEditContactScreen.Email.TextBox.ErrorMessage.Text";

        public const string DOB_ByID = "PopupAddEditContactScreen.DOB.TextBox";
        public const string DOBErrorMessage_ByID = "PopupAddEditContactScreen.DOB.TextBox.ErrorMessage.Text";

        public const string EmergencyContact_ByID = "PopupAddEditContactScreen.EmergencyContact.CheckBox";
        public const string Guardian_ByID = "PopupAddEditContactScreen.Guardian.CheckBox";

        public const string Delete_ByID = "PopupAddEditContactScreen.Delete.Button";
        public const string Cancel_ByID = "PopupAddEditContactScreen.Cancel.Button";
        public const string Save_ByID = "PopupAddEditContactScreen.Save.Button";
        public const string GuardianContactError_ByName = "A guardian must be 18 years or older";

        public const string NewContact = "NEW";
        public const string OldContact = "OLD";
        public const string Major = "Major";
        public const string Minor = "Minor";

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Relationship { get; set; }
        public string DOB { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailID { get; set; }


    }
}
