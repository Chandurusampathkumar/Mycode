
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;
using Theranos.Automation.AutoStack.Utility;
using Theranos.Automation.AutoStack;
using Theranos.Automation.PSC3.Models.CheckIn;

namespace Theranos.Automation.PSC3.TestCases.CheckIn.AddGuestInfo
{
    [TestClass]
    public class ContactTests:ContactModel
    {

        public static string[] relationItem = {};
        
        /// <summary>
        /// Verify user is able to add an emergency contact details.
        /// </summary>
        [TestMethod]
        public void AddEmergencyContact()
        {
            AddAndReturnEmergencyContact();
        }



        public ContactModel AddAndReturnEmergencyContact()
        {
            
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var contactHost = AutoElement.GetElementById(appWin,ContactsHost_ByID);
            var contactCount = AutoElement.GetElementCollectionByNameNoWait(contactHost,ContactListItem_ByName).Count;
            ContactModel contactInfo = null;
            AutoAction.ClickButtonById(appWin,AddContacts_ByID);
            
            var records = CSVHelper.GetRecords<ContactModel>(InputFileName);
            AutoAction.ClickCheckBoxById(appWin,EmergencyContact_ByID);
            
            int index= UtilityClass.GetRandomNumber(0, records.Count); 

            var contact=records[index];

            AutoAction.SetTextById(appWin, FirstName_ByID, contact.FirstName.Trim());
            AutoAction.SetTextById(appWin, LastName_ByID, contact.LastName.Trim());
            var relationship = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Relationship_ByID));
            relationship.Select(contact.Relationship.Trim());
            AutoAction.SetTextById(appWin, PhoneNumer_ByID, contact.PhoneNumber.Trim());
            //AutoAction.SetTextById(appWin, Email_ByID, contact.EmailID.Trim());
            
            AutoAction.ClickButtonById(appWin,Save_ByID);
            
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
            
            var currentContactCount = AutoElement.GetElementCollectionByNameNoWait(contactHost, ContactListItem_ByName).Count;
            if (currentContactCount != contactCount + 1)
            {
                Assert.Fail("Unable to add new guardian contact");
            }
            contactInfo = contact;
            return contactInfo;                    
        }
         //CTC-132:  Adding more emergency contacts... check the app behavior
        [TestMethod]
        public void AddMoreEmergencyContact()
        {
            int index = 0;
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var contactHost = AutoElement.GetElementById(appWin, ContactsHost_ByID);
            var contactCount = AutoElement.GetElementCollectionByNameNoWait(contactHost, ContactListItem_ByName).Count;
            //ContactModel contactInfo = null;
            AutoAction.ClickButtonById(appWin, AddContacts_ByID);

            var records = CSVHelper.GetRecords<AddMoreContactDetailsModel>(AddMoreContactDetailsModel.AddMoreContactsInputFileName);
            AutoAction.ClickCheckBoxById(appWin, EmergencyContact_ByID);

            foreach (var contactInfo in records)
            {
                if (contactInfo.Status==NewContact&&contactInfo.AgeGroup==Major)
                {
                    AutoAction.SetTextById(appWin, FirstName_ByID, contactInfo.FirstName.Trim());
                    AutoAction.SetTextById(appWin, LastName_ByID, contactInfo.LastName.Trim());
                    var relationship = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Relationship_ByID));
                    relationship.Select(contactInfo.Relationship.Trim());
                    AutoAction.SetTextById(appWin, PhoneNumer_ByID, contactInfo.PhoneNumber.Trim());
                    AutoAction.SetTextById(appWin, Email_ByID, contactInfo.EmailID.Trim());
                    AutoAction.ClickButtonById(appWin, Save_ByID);

                    CSVHelper.UpdateRecords<ContactModel>(ContactModel.NewContact, ContactModel.OldContact, index, AddMoreContactDetailsModel.AddMoreContactsInputFileName);
                    break;
                }
                index++;
            }
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);

            var currentContactCount = AutoElement.GetElementCollectionByNameNoWait(contactHost, ContactListItem_ByName).Count;
            if (currentContactCount != contactCount + 1)
            {
                Assert.Fail("Unable to add new guardian contact");
            }
        }

        //CTC-133: To Verify user is NOT able to add Duplicate emergency contact.
        public void CheckEmergencyContactDuplicate(ContactModel contact)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);            
            AutoAction.ClickButtonById(appWin, AddContacts_ByID);
            AutoAction.ClickCheckBoxById(appWin, EmergencyContact_ByID);

            AutoAction.SetTextById(appWin, FirstName_ByID, contact.FirstName.Trim());
            AutoAction.SetTextById(appWin, LastName_ByID, contact.LastName.Trim());
            var relationship = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Relationship_ByID));
            relationship.Select(contact.Relationship.Trim());
            AutoAction.SetTextById(appWin, PhoneNumer_ByID, contact.PhoneNumber.Trim());
            AutoAction.SetTextById(appWin, Email_ByID, contact.EmailID.Trim());

            AutoAction.ClickButtonById(appWin, Save_ByID);
            var msgid = AutoElement.GetElementById(appWin, "TbMessage");
            Assert.IsTrue(msgid.Current.Name.Contains("contact already exists"), "Application doesn't show warning, when dublicate contacts are added");

            AutoAction.ClickButtonById(appWin,InsuranceModel.Ok_ByID);
        }

        /// <summary>
        /// CTC-29: Verify user is able to add an Guardian contact details.
        /// </summary>
        [TestMethod]
        public void AddGuardianContact()
        {
            AddAndReturnGuardianContact();
        }
        public ContactModel AddAndReturnGuardianContact()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var contactHost = AutoElement.GetElementById(appWin, ContactsHost_ByID);
            var contactCount = contactHost.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, ContactListItem_ByName)).Count;
            ContactModel contactInfo = null;
            AutoAction.ClickButtonById(appWin, AddContacts_ByID);


            var records = CSVHelper.GetRecords<ContactModel>(InputFileName);
            AutoAction.ClickCheckBoxById(appWin, Guardian_ByID);
            int index = UtilityClass.GetRandomNumber(0, records.Count);

            var contact = records[index];


            AutoAction.SetTextById(appWin, FirstName_ByID, contact.FirstName.Trim());
            AutoAction.SetTextById(appWin, LastName_ByID, contact.LastName.Trim());
            var relationship = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Relationship_ByID));
            relationship.Select(contact.Relationship.Trim());
            AutoAction.SetTextById(appWin, DOB_ByID, contact.DOB.Trim());
            AutoAction.SetTextById(appWin, PhoneNumer_ByID, contact.PhoneNumber.Trim());
            //AutoAction.SetTextById(appWin, Email_ByID, contact.EmailID.Trim());

            AutoAction.ClickButtonById(appWin, Save_ByID);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, SmallSpinner_ByClass);

            var currentContactCount = contactHost.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, ContactListItem_ByName)).Count;
            if (currentContactCount != contactCount + 1)
            {
                Assert.Fail("Unable to add new guardian contact");
            }
            contactInfo = contact;
            return contactInfo;
        }


        //CTC-134: To Verify user is able to add more contact details as guardian.

        [TestMethod]
        public void AddMoreGuardianContact()
        {
            int index = 0;
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var contactHost = AutoElement.GetElementById(appWin, ContactsHost_ByID);
            var contactCount = contactHost.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, ContactListItem_ByName)).Count;
            //ContactModel contactInfo = null;
            AutoAction.ClickButtonById(appWin, AddContacts_ByID);


            var records = CSVHelper.GetRecords<AddMoreContactDetailsModel>(AddMoreContactDetailsModel.AddMoreContactsInputFileName);
            AutoAction.ClickCheckBoxById(appWin, Guardian_ByID);

            foreach (var contactInfo in records)
            {
                if (contactInfo.Status == NewContact && contactInfo.AgeGroup == Major)
                {
                    AutoAction.SetTextById(appWin, FirstName_ByID, contactInfo.FirstName.Trim());
                    AutoAction.SetTextById(appWin, LastName_ByID, contactInfo.LastName.Trim());
                    var relationship = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Relationship_ByID));
                    relationship.Select(contactInfo.Relationship.Trim());
                    AutoAction.SetTextById(appWin, PhoneNumer_ByID, contactInfo.PhoneNumber.Trim());
                    AutoAction.SetTextById(appWin, DOB_ByID, contactInfo.DOB.Trim());
                    AutoAction.SetTextById(appWin, Email_ByID, contactInfo.EmailID.Trim());
                    AutoAction.ClickButtonById(appWin, Save_ByID);

                    CSVHelper.UpdateRecords<ContactModel>(ContactModel.NewContact, ContactModel.OldContact, index, AddMoreContactDetailsModel.AddMoreContactsInputFileName);
                    break;
                }
                index++;
            }
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);

            //var currentContactCount = AutoElement.GetElementCollectionByNameNoWait(contactHost, ContactListItem_ByName).Count;
            //if (currentContactCount != contactCount + 1)
            //{
            //    Assert.Fail("Unable to add new guardian contact");
            //}
        }

        //CTC-95: To verify application does not accepts below 18 years as a guardian for the patient.
        [TestMethod]
        public void AddGuardianContactLessThan18()
        {
            int index = 0;
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var contactHost = AutoElement.GetElementById(appWin, ContactsHost_ByID);
            var contactCount = contactHost.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, ContactListItem_ByName)).Count;
            //ContactModel contactInfo = null;
            AutoAction.ClickButtonById(appWin, AddContacts_ByID);


            var records = CSVHelper.GetRecords<AddMoreContactDetailsModel>(AddMoreContactDetailsModel.AddMoreContactsInputFileName);
            AutoAction.ClickCheckBoxById(appWin, Guardian_ByID);

            foreach (var contactInfo in records)
            {
                if (contactInfo.Status == NewContact && contactInfo.AgeGroup == Minor)
                {
                    AutoAction.SetTextById(appWin, FirstName_ByID, contactInfo.FirstName.Trim());
                    AutoAction.SetTextById(appWin, LastName_ByID, contactInfo.LastName.Trim());
                    var relationship = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Relationship_ByID));
                    relationship.Select(contactInfo.Relationship.Trim());
                    AutoAction.SetTextById(appWin, PhoneNumer_ByID, contactInfo.PhoneNumber.Trim());
                    AutoAction.SetTextById(appWin, DOB_ByID, contactInfo.DOB.Trim());
                    AutoAction.SetTextById(appWin, Email_ByID, contactInfo.EmailID.Trim());
                    AutoAction.ClickButtonById(appWin, Save_ByID);
                    Assert.IsTrue(AutoElement.VisibleByName(appWin,GuardianContactError_ByName));
                    AutoAction.ClickButtonById(appWin,ConfirmOrdersModel.Ok_ByID);
                    AutoAction.ClickButtonById(appWin,Cancel_ByID);
                    break;
                }
                index++;
            }
        }

        //CTC-135: To Verify user is NOT able to add Duplicate Guardian contact.
        public void CheckGuardianContactDuplicate(ContactModel contact)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
        
            AutoAction.ClickButtonById(appWin, AddContacts_ByID);
            AutoAction.ClickCheckBoxById(appWin, Guardian_ByID);

            AutoAction.SetTextById(appWin, FirstName_ByID, contact.FirstName.Trim());
            AutoAction.SetTextById(appWin, LastName_ByID, contact.LastName.Trim());
            var relationship = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Relationship_ByID));
            relationship.Select(contact.Relationship.Trim());
            AutoAction.SetTextById(appWin, DOB_ByID, contact.DOB.Trim());
            AutoAction.SetTextById(appWin, PhoneNumer_ByID, contact.PhoneNumber.Trim());
            AutoAction.SetTextById(appWin, Email_ByID, contact.EmailID.Trim());

            AutoAction.ClickButtonById(appWin, Save_ByID);
            var msgid = AutoElement.GetElementById(appWin, "TbMessage");
            Assert.IsTrue(msgid.Current.Name.Contains("contact already exists"), "Application doesn't show warning, when dublicate contacts are added");
            AutoAction.ClickButtonById(appWin, InsuranceModel.Ok_ByID);

        }

        //Update assertion based on contact no
        /// <summary>
        /// CTC-31: Verify user is able to delete an contact card.
        /// </summary>
        [TestMethod]
        public void DeleteContact()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var contactHost = AutoElement.GetElementById(appWin,ContactsHost_ByID);
            //var contactHost = appWin.GetElement(SearchCriteria.ByAutomationId(ContactsHost_ByID));

             var contactCount = contactHost.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, ContactListItem_ByName)).Count;
             if (contactCount==0)
             {
                 Assert.Fail("No Contacts are available to delete");
             }

             //var contactList = AutoElement.GetElementByName(appWin,ContactListItem_ByName);
             //UIAutoHelper.performSelectionItemPattern(contactList);
             AutoAction.ClickUIItemByName(appWin, ContactListItem_ByName);
             AutoAction.ClickUIItemById(appWin, Delete_ByID);
             AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
             var currentContactCount = contactHost.FindAll(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, ContactListItem_ByName)).Count;
             if (currentContactCount!=contactCount-1)
             {
                 Assert.Fail("Unable to delete contact");
             }


        }

        /// <summary>
        /// CTC-30: Verify user is able to edit an contact details.
        /// </summary>
        [TestMethod]
        public void EditContact()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var records = CSVHelper.GetRecords<ContactModel>(InputFileName);
            int index;

            AutoAction.ClickUIItemByName(appWin, ContactListItem_ByName);
            var fname = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(FirstName_ByID)).Text;
            var lname = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(LastName_ByID)).Text;
            var relationship = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Relationship_ByID)).Items.SelectedItemText;
            var number = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(PhoneNumer_ByID)).Text;
            var mailId = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(Email_ByID)).Text;

            do
            {

             index = UtilityClass.GetRandomNumber(0, records.Count);   

            } while (fname.Equals(records[index].FirstName)&&lname.Equals(records[index].LastName)&&relationship.Equals(records[index].Relationship)&&number.Equals(records[index].PhoneNumber)&&mailId.Equals(records[index].EmailID));

            var contact = records[index];  

            AutoAction.SetTextById(appWin, FirstName_ByID, contact.FirstName.Trim());
            AutoAction.SetTextById(appWin, LastName_ByID, contact.LastName.Trim());
            var relationshipCombo = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Relationship_ByID));
            relationshipCombo.Select(contact.Relationship.Trim());
            AutoAction.SetTextValuePatternById(appWin, PhoneNumer_ByID, contact.PhoneNumber.Trim());
            AutoAction.SetTextById(appWin, DOB_ByID, contact.DOB.Trim());
            AutoAction.SetTextById(appWin, Email_ByID, contact.EmailID.Trim());

            AutoAction.ClickButtonById(appWin, Save_ByID);
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);

            //var contactList = AutoElement.GetElementByName(appWin, ContactListItem_ByName);
            //UIAutoHelper.performSelectionItemPattern(contactList);
            AutoAction.ClickUIItemByName(appWin, ContactListItem_ByName);

            fname = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(FirstName_ByID)).Text;
            Assert.AreEqual(contact.FirstName.Trim(),fname,"First name is not edited");

            lname = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(LastName_ByID)).Text;
            Assert.AreEqual(contact.LastName.Trim(),lname,"Last name is not edited");

            relationship = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Relationship_ByID)).Items.SelectedItemText;
            Assert.AreEqual(contact.Relationship.Trim(),relationship,"Relationship is not edited");

            number = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(PhoneNumer_ByID)).Text;
            Assert.AreEqual(contact.PhoneNumber.Trim(),number,"Phone number is not edited");

            mailId = appWin.Get<TextBox>(SearchCriteria.ByAutomationId(Email_ByID)).Text;
            Assert.AreEqual(contact.EmailID.Trim(), mailId, "EmailID is not edited");
            AutoAction.ClickButtonById(appWin, Cancel_ByID);       

        }

        [TestMethod]
        public void RelationshipValidation()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin,AddContacts_ByID);
            var expectedCount = ExpectedRelationships.Length;
            //HashSet<string> presentRelations = new HashSet<string>(Relationships);               
            
            var relationshipCombo = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(Relationship_ByID));
            var presentRelationshipItems = relationshipCombo.Items;
            var presentCount=presentRelationshipItems.Count;
            
            if (expectedCount!=presentCount)
            {
                Assert.Fail("Relationship count is not equal by default");
            }
            List<String> presentRelations = new List<string>();

            foreach (var item in presentRelationshipItems)
            {
                presentRelations.Add(item.Name);
            }
         
            if (!ExpectedRelationships.SequenceEqual(presentRelations.ToArray()))
            {
                Assert.Fail("Expected and present relationships doesn't match by default");
            }

            //For Emergency Contact
            AutoAction.ClickCheckBoxById(appWin,EmergencyContact_ByID);
            presentRelationshipItems = relationshipCombo.Items;
            presentCount = presentRelationshipItems.Count;

            if (expectedCount != presentCount)
            {
                Assert.Fail("Relationship count is not equal for Emergency contact");
            }

            presentRelations.Clear();
            foreach (var item in presentRelationshipItems)
            {
                 presentRelations.Add(item.Name);
            }
            if (!ExpectedRelationships.SequenceEqual(presentRelations.ToArray()))
            {
                Assert.Fail("Expected and present relationships doesn't match for Emergency Contact");
            }

            //For Guardian Contact
            AutoAction.ClickCheckBoxById(appWin,Guardian_ByID);
            presentRelationshipItems = relationshipCombo.Items;
            presentCount = presentRelationshipItems.Count;

            if (expectedCount != presentCount)
            {
                Assert.Fail("Relationship count is not equal for Guardian contact");
            }

            presentRelations.Clear();
            foreach (var item in presentRelationshipItems)
            {
                presentRelations.Add(item.Name);
            }
            if (!ExpectedRelationships.SequenceEqual(presentRelations.ToArray()))
            {
                Assert.Fail("Expected and present relationships doesn't match for Guardian");
            }
            AutoAction.ClickButtonById(appWin,Cancel_ByID);
        }

        //CTC-22
        [TestMethod]
        public void GuardianContactMandatory()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickCheckBoxById(appWin,BasicInfoModel.VerifyID_ByAutoID);
            AutoAction.ClickButtonById(appWin, BasicInfoModel.Next_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin, BasicInfoModel.GuardianPopup_ByID));
            AutoAction.ClickRadioButtonById(appWin, BasicInfoModel.GuardianYes_ByID);

            var records = CSVHelper.GetRecords<ContactModel>(InputFileName);
            int index = UtilityClass.GetRandomNumber(0, records.Count);

            var contact = records[index];

            AutoAction.SetTextById(appWin, BasicInfoModel.GuardianFirstName_ByID, contact.FirstName.Trim());
            AutoAction.SetTextById(appWin, BasicInfoModel.GuardianLastName_ByID, contact.LastName.Trim());
            var relationship = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(BasicInfoModel.GuardianRelationship_ById));
            relationship.Select(contact.Relationship.Trim());
            AutoAction.SetTextById(appWin, BasicInfoModel.GuardianDOB_ByID, contact.DOB.Trim());
            AutoAction.SetTextById(appWin, BasicInfoModel.GuardianPhone_ByID, contact.PhoneNumber.Trim());

            AutoAction.ClickButtonById(appWin, BasicInfoModel.GuardianOkButton_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin, GuestFormsModel.GuestFormsHost_ByID));
        }


        //CTC-22:If patient is under the age of 18, the system must ask if the patient is with a guardian. Adding guardian information is not required for patients under 18. 
        [TestMethod]
        public void CheckNoGuardianContact()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickCheckBoxById(appWin, BasicInfoModel.VerifyID_ByAutoID);
            AutoAction.ClickButtonById(appWin, BasicInfoModel.Next_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin, BasicInfoModel.GuardianPopup_ByID));
            AutoAction.ClickRadioButtonById(appWin, BasicInfoModel.GuardianNo_ByID);
            AutoAction.ClickButtonById(appWin, BasicInfoModel.GuardianOkButton_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin,GuestFormsModel.GuestFormsHost_ByID));
        }
    }
}
