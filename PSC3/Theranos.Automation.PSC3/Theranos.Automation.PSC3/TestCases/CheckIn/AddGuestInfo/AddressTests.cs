
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
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;
using Theranos.Automation.AutoStack.Utility;
using TestStack.White.UIItems.ListBoxItems;
using Theranos.Automation.AutoStack;

namespace Theranos.Automation.PSC3.TestCases.CheckIn.AddGuestInfo
{
    [TestClass]
    public class AddressTests:AddressModel
    {

        /// <summary>
        /// CTC-23: Verify user is able to enter mailing address.
        /// </summary>
        [TestMethod]
        public void AddMailingAddress()
        {
            List<DateTime> time = new List<DateTime>();
            time.Add(DateTime.Now);

           //bool wait = false;
            string inputData = "";
            int index;
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //var guestInfoHost = AutoElement.GetElementById(appWin,GuestInfoScreen_ByID);
            //AutomationElementCollection busyBox = guestInfoHost.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, BusyBox_ByClass));

            var records = CSVHelper.GetRecords<AddressModel>(InputFileName);
            index = UtilityClass.GetRandomNumber(0, records.Count);

            time.Add(DateTime.Now);
            var mailingAddress = records[index];
            time.Add(DateTime.Now);
            AutoAction.SetTextById(appWin,MailingStreet1_ByID,mailingAddress.Street1);
            time.Add(DateTime.Now);
            time.Add(DateTime.Now); 
            AutoAction.SetTextById(appWin, MailingStreet2_ByID, mailingAddress.Street1);
            time.Add(DateTime.Now); 
            AutoAction.SetTextById(appWin, MailingZipcode_ByID, mailingAddress.Zipcode);
            time.Add(DateTime.Now); 
            AutoAction.SendTabKey();
            time.Add(DateTime.Now); 
            AutoAction.SendTabKey();

            time.Add(DateTime.Now); 
            AutoAction.SendTabKey();
            time.Add(DateTime.Now); 
            AutoAction.SendTabKey();
            var city = AutoElement.GetTextBoxValueById(appWin,MailingCity_ByID);
            var state = AutoElement.GetTextBoxValueById(appWin,MailingState_ByID);
            //var count = state.Length;
            Assert.IsTrue(state.Length == 2, "state name exceeds 2 characters");

            inputData = "Street1: " + mailingAddress.Street1 + ", Street2: " + mailingAddress.Street2 + ", Zipcode: " + mailingAddress.Zipcode;
            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
            time.Add(DateTime.Now);
            //do
            //{
            //    Thread.Sleep(1000);
            //    foreach (AutomationElement item in busyBox)
            //    {
            //        wait = false;
            //        Thread.Sleep(WaitTime);
            //        if (!item.Current.IsOffscreen)
            //        {
            //            wait = true;
            //            break;
            //        }
            //    }
            //} while (wait);

         //   //Assert.IsFalse(AutoElement.VisibleByIdNoWait(appWin,MailingStreet1Error_ByID));
         //   //Assert.IsTrue(AutoElement.ExistsById(appWin, MailingStreet1Error_ByID));
         //   var street1Error = appWin.GetElement(SearchCriteria.ByAutomationId(MailingStreet1Error_ByID));
         //   Assert.IsTrue(street1Error.Current.IsOffscreen, "Error message is shown for street1");

         //// Assert.IsFalse(AutoElement.VisibleByIdNoWait(appWin, MailingStreet2Error_ByID));
         //   //Assert.IsTrue(AutoElement.ExistsById(appWin, MailingStreet2Error_ByID));
         //   var street2Error = appWin.GetElement(SearchCriteria.ByAutomationId(MailingStreet2Error_ByID));
         //   Assert.IsTrue(street2Error.Current.IsOffscreen, "Error message is shown for street2");

         ////   Assert.IsFalse(AutoElement.VisibleByIdNoWait(appWin, MailingZipcodeError_ByID));
         //   //Assert.IsTrue(AutoElement.ExistsById(appWin, MailingZipcodeError_ByID));
         //   var zipCodeError = appWin.GetElement(SearchCriteria.ByAutomationId(MailingZipcodeError_ByID));
         //   Assert.IsTrue(zipCodeError.Current.IsOffscreen, "Error message is shown for zipcode");

         //  // Assert.IsFalse(AutoElement.VisibleByIdNoWait(appWin, MailingCityError_ByID));
         //   //Assert.IsTrue(AutoElement.ExistsById(appWin, MailingCityError_ByID));
         //   var cityError = appWin.GetElement(SearchCriteria.ByAutomationId(MailingCityError_ByID));
         //   Assert.IsTrue(cityError.Current.IsOffscreen, "Error message is shown for city");

         // //  Assert.IsFalse(AutoElement.VisibleByIdNoWait(appWin, MailingStateError_ByID));
         //   //Assert.IsTrue(AutoElement.ExistsById(appWin, MailingStateError_ByID));
         //   var stateError = appWin.GetElement(SearchCriteria.ByAutomationId(MailingStateError_ByID));
         //   Assert.IsTrue(stateError.Current.IsOffscreen, "Error message is shown for state");

         //  // Assert.IsFalse(AutoElement.VisibleByIdNoWait(appWin, CountryError_ByID));
         //   //Assert.IsTrue(AutoElement.ExistsById(appWin, CountryError_ByID));
         //   var countryError = appWin.GetElement(SearchCriteria.ByAutomationId(CountryError_ByID));
         //   Assert.IsTrue(countryError.Current.IsOffscreen, "Error message is shown for country");
            time.Add(DateTime.Now);

            //Validate by checking no error messages are not displayed
        }

        /// <summary>
        ///CTC-24: Verify user is able to enter billing address.
        /// </summary>
        [TestMethod]
        public void AddBillingAddress()
        {
            
            string inputData = "";
            int index;
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var guestInfoHost = AutoElement.GetElementById(appWin.AutomationElement, GuestInfoScreen_ByID);
            

            var records = CSVHelper.GetRecords<AddressModel>(InputFileName);
            index = UtilityClass.GetRandomNumber(0, records.Count);


            var billingAddress = records[index];
            AutoAction.SetTextById(appWin, BillingStreet1_ByID, billingAddress.Street1);
            AutoAction.SetTextById(appWin, BillingStreet2_ByID, billingAddress.Street1);
            AutoAction.SetTextById(appWin, BillingZipcode_ByID, billingAddress.Zipcode);

            inputData = "Street1: " + billingAddress.Street1 + ", Street2: " + billingAddress.Street2 + ", Zipcode: " + billingAddress.Zipcode;
            AutoAction.WaitForBusyBoxByClassName(guestInfoHost, BusyBox_ByClass);
           

            //var street1Error = appWin.GetElement(SearchCriteria.ByAutomationId(BillingStreet1Error_ByID));
            //Assert.IsTrue(street1Error.Current.IsOffscreen, "Error message is shown for street1");

            //var street2Error = appWin.GetElement(SearchCriteria.ByAutomationId(BillingStreet2Error_ByID));
            //Assert.IsTrue(street2Error.Current.IsOffscreen, "Error message is shown for street2");

            //var zipCodeError = appWin.GetElement(SearchCriteria.ByAutomationId(BillingZipcodeError_ByID));
            //Assert.IsTrue(zipCodeError.Current.IsOffscreen, "Error message is shown for zipcode");

            //var cityError = appWin.GetElement(SearchCriteria.ByAutomationId(BillingCityError_ByID));
            //Assert.IsTrue(cityError.Current.IsOffscreen, "Error message is shown for city");

            //var stateError = appWin.GetElement(SearchCriteria.ByAutomationId(BillingStateError_ByID));
            //Assert.IsTrue(stateError.Current.IsOffscreen, "Error message is shown for state");

            //var countryError = appWin.GetElement(SearchCriteria.ByAutomationId(CountryError_ByID));
            //Assert.IsTrue(countryError.Current.IsOffscreen, "Error message is shown for country");
            
            ////Validate by checking no error messages are not displayed
        }

        [TestMethod]
        public void SetMailingAddressAsBillingAddress()
        {
            List<DateTime> time = new List<DateTime>();
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            time.Add(DateTime.Now);
            AutoAction.ClickCheckBoxById(appWin, SameAsMailing_ByID);
            time.Add(DateTime.Now);
            //var sameAsMailing = appWin.Get<CheckBox>(SearchCriteria.ByAutomationId(SameAsMailing_ByID));
            //sameAsMailing.SetValue(true);
                        
            var billingStreet1 = appWin.GetElement(SearchCriteria.ByAutomationId(BillingStreet1_ByID));
            var billingStreet2 = appWin.GetElement(SearchCriteria.ByAutomationId(BillingStreet2_ByID));
            var billingZipcode = appWin.GetElement(SearchCriteria.ByAutomationId(BillingZipcode_ByID));
            time.Add(DateTime.Now);
            if (!(billingStreet1.Current.IsOffscreen)||!(billingStreet2.Current.IsOffscreen)||!(billingZipcode.Current.IsOffscreen))
            {
                 Assert.Fail("Billing address is not same as mailing address");
            }
            time.Add(DateTime.Now);
        }

        [TestMethod]
        public void ChangeState()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var state = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(State_ByID));
            state.Select(UtilityClass.GetRandomNumber(0,84));
        }

        [TestMethod]
        public void CheckMailingAndBillingAddress()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var mailingStreet1 = AutoElement.GetTextBoxValueById(appWin, MailingStreet1_ByID);
            var mailingZipCode = AutoElement.GetTextBoxValueById(appWin, MailingZipcode_ByID);
            var billingStreet1 = AutoElement.GetTextBoxValueById(appWin,BillingStreet1_ByID);
            var billingZipCode = AutoElement.GetTextBoxValueById(appWin,BillingZipcode_ByID);
            Assert.IsNotNull(mailingStreet1,"street 1 address is empty");
            Assert.IsNotNull(mailingZipCode,"Zipcode is empty");
            Assert.IsNotNull(billingStreet1, "street 1 address is empty");
            Assert.IsNotNull(billingZipCode, "Zipcode is empty");
        }
    }
}
