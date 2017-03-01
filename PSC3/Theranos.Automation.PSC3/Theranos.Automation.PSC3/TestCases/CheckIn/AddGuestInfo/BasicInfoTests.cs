
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.UIItems.Finders;
using Theranos.Automation.PSC3.Models;
using Theranos.Automation.AutoStack.Utility;
using Theranos.Automation.PSC3.Models.CheckIn;
using Theranos.Automation.PSC3.Models.CheckIn.AddLabOrder;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;
using TestStack.White.UIItems;
using Theranos.Automation.AutoStack;
using TestStack.White.UIItems.ListBoxItems;
using Theranos.Automation.ME.Android.Model;
using System.Collections.Generic;

namespace Theranos.Automation.PSC3.TestCases.CheckIn.AddGuestInfo
{
    [TestClass]
    public class BasicInfoTests:BasicInfoModel
    {

        [TestMethod]
        public void BasicInfoMandatory()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var setBillingAsMailing = appWin.Get<CheckBox>(SearchCriteria.ByAutomationId(SameAsMailing_ByID));
            var contact = appWin.Get<Button>(SearchCriteria.ByAutomationId(AddContacts_ByID));
            var insurance = appWin.Get<Button>(SearchCriteria.ByAutomationId(AddCard_ByID));
            var next = appWin.Get<Button>(SearchCriteria.ByAutomationId(Next_ByID));

            if ((setBillingAsMailing.Enabled)||(contact.Enabled)||(insurance.Enabled)||(next.Enabled))
            {
                Assert.Fail("Set Billing As Mailing or Add Contact or Add Insurance or Next Button are enabled");
            }
        }

        [TestMethod]
        public void NextButtonMandatory()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var next = appWin.Get<Button>(SearchCriteria.ByAutomationId(Next_ByID));
            if (next.Enabled)
            {
                Assert.Fail("Next button is enabled");
            }
        }

        //CTC-94: Check whether mobile number and home phone number can be able to enter
        [TestMethod]
        public void CheckPhoneFields()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //verify "No mobile phone?" button and Text box to enter mobile number is present when entering into basicinfo page
            if (AutoElement.ExistsByName(appWin, "No mobile phone?"))
            {
                Assert.IsTrue(AutoElement.ExistsById(appWin, PhoneNo_ByAutoID), "Text box to enter mobile phone number is not present");
                AutoAction.ClickButtonByName(appWin, "No mobile phone?");
                //verify "Does the guest have a mobile phone?" button and text box to enter home phone is present when clicking "No mobile phone?" button
                if (AutoElement.ExistsByName(appWin, "Does the guest have a mobile phone?"))
                {
                    Assert.IsTrue(AutoElement.ExistsById(appWin, PhoneNo_ByAutoID), "Text box to enter home phone number is not present");                                 
                    AutoAction.ClickButtonByName(appWin, "Does the guest have a mobile phone?");
                    Assert.IsTrue(AutoElement.ExistsById(appWin, PhoneNo_ByAutoID), "Text box to enter mobile phone number is not present when clicking Does the guest has a mobile phone? button");
                    
                }
                else
                {
                    Assert.Fail("Does the guest have a mobile phone? Button is Not present when clicking No mobile phone? button");
                }
            }
            else
            {
                Assert.Fail("No mobile phone? button is not present when entering into basicinfo");
            }

        }

        /// <summary>
        ///CTC-26: Verify user is able to enter basic information.
        /// </summary>
        [TestMethod]
        public void AddGuestInfo()
        {
            AddAndReturnGuestInfo();
            //AddAndReturnBasicInfo();
        }

        //CTC-93:First Name, Last Name, Date of Birth, Gender, Zip Code and at least one phone number are required in order to create a new patient ID.  
        public BasicInfoModel AddAndReturnGuestInfo()
        {
          //  bool wait = false;
            string inputData = "";
            string firstName = "";
            string lastName = "";
            int index = 0;
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //var guestInfoHost = AutoElement.GetElementById(appWin,GuestInfoScreen_ByID);
            //AutomationElementCollection busyBox = guestInfoHost.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, BusyBox_ByClass));
            string dob=null;
            var records = CSVHelper.GetRecords<BasicInfoModel>(InputFileName);
            BasicInfoModel basic = null;

            foreach (var basicInfo in records)
            {
                if (basicInfo.Status==NewGuest && basicInfo.AgeGroup==Major)
                {
                    AutoAction.SetTextById(appWin,GuestInfoFirst_ByAutoID,basicInfo.FirstName);
                    AutoAction.SetTextById(appWin,GuestInfoLast_ByAutoID,basicInfo.LastName);
                    AutoAction.SetTextById(appWin,GuestInfoMI_ByAutoID,basicInfo.MI);
                    AutoAction.SetTextById(appWin,GuestInfoDOB_ByAutoID,basicInfo.DOB.Substring(1));                   
                    dob = basicInfo.DOB.Substring(1);
                    
                    if (basicInfo.Gender == BasicInfoModel.Male)
                    {
                        AutoAction.ClickRadioButtonById(appWin,GenderMale_ByAutoID);
                        //Actions.ClickElementByAutomationID(appWin, GenderMale_ByAutoID);
                    }
                    else if (basicInfo.Gender == BasicInfoModel.Female)
                    {
                        AutoAction.ClickRadioButtonById(appWin, GenderFemale_ByAutoID);
                    }
                  
                    AutoAction.SetTextById(appWin, PhoneNo_ByAutoID, basicInfo.PhoneNo);
                    AutoAction.SendTabKey();
                    //Assert.IsTrue(!AutoElement.GetCheckBoxStateById(appWin, EmailCheckbox_ById), "EmailID checkbox is checked by default");
                    //var emailId = basicInfo.FirstName + basicInfo.LastName + "@yopmail.com";
                    //AutoAction.SetTextById(appWin, EmailID_ByID, emailId);
                    AutoAction.ClickCheckBoxById(appWin, EmailCheckbox_ById);
                    AutoAction.SendTabKey();
                   
                    Thread.Sleep(WaitTime);
                    AutoAction.SendTabKey();
                   
                    inputData = "FirstName: " + basicInfo.FirstName + ", LastName: " + basicInfo.LastName + ", DOB: " + basicInfo.DOB.Substring(1) + ", Gender: " + basicInfo.Gender + ", PhoneNo: " + basicInfo.PhoneNo;
                    firstName = basicInfo.FirstName;
                    lastName = basicInfo.LastName;
                    
                    CSVHelper.UpdateRecords<BasicInfoModel>(BasicInfoModel.NewGuest, BasicInfoModel.ExistingGuest, index, InputFileName);
                    basic = basicInfo;
                    break;

                    
                }
                index++;

            }

            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);

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

            var name = appWin.Get<Label>(SearchCriteria.ByText(firstName + " " + lastName));
            var patientName = firstName + " " + lastName;
            var guestName = AutoElement.GetElementNameById(appWin,CheckInModel.GuestName_ByID);
            Assert.AreEqual(patientName, guestName, "Guest is not displayed correctly");
            Assert.IsNotNull(name,"Unable to save basic guest info for the data, "+inputData);
            var guestDOB = appWin.Get<Label>(SearchCriteria.ByAutomationId(DOB_ByID)).Name.ToString();
            var date = guestDOB.Substring(15);
            if (date==dob)
            {
                Assert.Fail();
            }
            var male = AutoElement.GetRadioButtonById(appWin,GenderMale_ByAutoID);
            var female = AutoElement.GetRadioButtonById(appWin,GenderFemale_ByAutoID);
            var guestGender = AutoElement.GetElementNameById(appWin,Gender_ByID).Substring(8);
            if (male.IsSelected)
            {
                Assert.AreEqual(guestGender,MaleGender,"Guest Gender is not displayed properly");
            }
            else
            {
                Assert.AreEqual(guestGender, FemaleGender, "Guest Gender is not displayed properly");
            }


            return basic;
        }

        public SampleBasicInfoModel AddAndReturnBasicInfo()
        {
            //  bool wait = false;
            string inputData = "";
            string firstName = "";
            string lastName = "";
            int index = 0;
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //var guestInfoHost = AutoElement.GetElementById(appWin,GuestInfoScreen_ByID);
            //AutomationElementCollection busyBox = guestInfoHost.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, BusyBox_ByClass));
            string dob = null;
            var records = CSVHelper.GetRecords<BasicInfoModel>(InputFileName);
            //BasicInfoModel basic = null;
            //List<SampleBasicInfoModel> sample = new List<SampleBasicInfoModel>();
            SampleBasicInfoModel sample1 = new SampleBasicInfoModel();
            sample1.basic = new List<BasicInfoModel>();
            foreach (var basicInfo in records)
            {
                BasicInfoModel basicInfo1 = new BasicInfoModel();  
                if (basicInfo.Status == NewGuest && basicInfo.AgeGroup == Major)
                {
                    AutoAction.SetTextById(appWin, GuestInfoFirst_ByAutoID, basicInfo.FirstName);
                    AutoAction.SetTextById(appWin, GuestInfoLast_ByAutoID, basicInfo.LastName);
                    AutoAction.SetTextById(appWin, GuestInfoMI_ByAutoID, basicInfo.MI);
                    AutoAction.SetTextById(appWin, GuestInfoDOB_ByAutoID, basicInfo.DOB.Substring(1));
                    dob = basicInfo.DOB.Substring(1);

                    if (basicInfo.Gender == BasicInfoModel.Male)
                    {
                        AutoAction.ClickRadioButtonById(appWin, GenderMale_ByAutoID);
                        //Actions.ClickElementByAutomationID(appWin, GenderMale_ByAutoID);
                    }
                    else if (basicInfo.Gender == BasicInfoModel.Female)
                    {
                        AutoAction.ClickRadioButtonById(appWin, GenderFemale_ByAutoID);
                    }

                    AutoAction.SetTextById(appWin, PhoneNo_ByAutoID, basicInfo.PhoneNo);
                    AutoAction.SendTabKey();
                    //Assert.IsTrue(!AutoElement.GetCheckBoxStateById(appWin, EmailCheckbox_ById), "EmailID checkbox is checked by default");
                    //var emailId = basicInfo.FirstName + basicInfo.LastName + "@yopmail.com";
                    //AutoAction.SetTextById(appWin, EmailID_ByID, emailId);
                    AutoAction.ClickCheckBoxById(appWin, EmailCheckbox_ById);
                    AutoAction.SendTabKey();

                    Thread.Sleep(WaitTime);
                    AutoAction.SendTabKey();

                    inputData = "FirstName: " + basicInfo.FirstName + ", LastName: " + basicInfo.LastName + ", DOB: " + basicInfo.DOB.Substring(1) + ", Gender: " + basicInfo.Gender + ", PhoneNo: " + basicInfo.PhoneNo;
                    firstName = basicInfo.FirstName;
                    lastName = basicInfo.LastName;


                    //Adding the items in list
                    //basicInfo1.FirstName = basicInfo.FirstName;
                    //basicInfo1.LastName = basicInfo.LastName;
                    //basicInfo1.DOB = basicInfo.DOB;
                    //basicInfo1.Gender = basicInfo.Gender;
                    //basicInfo1.PhoneNo = basicInfo.PhoneNo;
                    //sample1.basic.Add(basicInfo1);
                    sample1.name = basicInfo.FirstName + " " + basicInfo.LastName;
                    CSVHelper.UpdateRecords<BasicInfoModel>(BasicInfoModel.NewGuest, BasicInfoModel.ExistingGuest, index, InputFileName);
                    //basic = basicInfo;
                    break;


                }
                index++;
            }
            //sample.Add(sample1);

            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);
            return sample1;
        }


        [TestMethod]
        public void Email()
        {
            BasicInfoModel basic=new BasicInfoModel();
            basic.FirstName = "ad";
            basic.LastName = "ool";
            EnterEmailID(basic);
        }

     
        public string EnterEmailID(BasicInfoModel basicInfo)
        {
            
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var emailId = basicInfo.FirstName + basicInfo.LastName + "@yopmail.com";
            if (!AutoElement.GetCheckBoxStateById(appWin,EmailCheckbox_ById))
            {
                
                    AutoAction.SetTextById(appWin, EmailID_ByID, emailId);
                    AutoAction.SendTabKey();
            }

            return emailId;
        }


        public void EnterEmailForME(MELoginModel userInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var emailId = userInfo.FirstName + userInfo.LastName + "@yopmail.com";          
            AutoAction.SetTextById(appWin, EmailID_ByID, emailId);
            AutoAction.SendTabKey();           
        }

        [TestMethod]
        public void EnterPhoneNumber()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var phoneNo = UtilityClass.GetRandomNumber(11111, 99999).ToString() + UtilityClass.GetRandomNumber(11111, 99999).ToString();
            AutoAction.SetTextById(appWin, PhoneNo_ByAutoID, phoneNo);
        }

        [TestMethod]
        public void AddGuestInfoMale()
        {
            //bool wait = false;
            string inputData = "";
            string firstName = "";
            string lastName = "";
            int index = 0;
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var guestInfoHost = AutoElement.GetElementById(appWin,GuestInfoScreen_ByID);
            //var guestInfoHost = appWin.GetElement(SearchCriteria.ByAutomationId(GuestInfoScreen_ByID));
            AutomationElementCollection busyBox = guestInfoHost.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, BusyBox_ByClass));

            var records = CSVHelper.GetRecords<BasicInfoModel>(InputFileName);

            foreach (var basicInfo in records)
            {
                if (basicInfo.Status == NewGuest && basicInfo.Gender==Male && basicInfo.AgeGroup==Major)
                {
                    AutoAction.SetTextById(appWin, GuestInfoFirst_ByAutoID, basicInfo.FirstName);
                    AutoAction.SetTextById(appWin, GuestInfoLast_ByAutoID, basicInfo.LastName);
                    AutoAction.SetTextById(appWin, GuestInfoMI_ByAutoID, basicInfo.MI);
                    AutoAction.SetTextById(appWin, GuestInfoDOB_ByAutoID, basicInfo.DOB.Substring(1));                   

                    if (basicInfo.Gender == BasicInfoModel.Male)
                    {
                        AutoAction.ClickRadioButtonById(appWin, GenderMale_ByAutoID);
                    }
                    else if (basicInfo.Gender == BasicInfoModel.Female)
                    {
                        AutoAction.ClickRadioButtonById(appWin, GenderFemale_ByAutoID);
                    }
                    Assert.IsTrue(!AutoElement.GetCheckBoxStateById(appWin, EmailCheckbox_ById), "EmailID checkbox is checked by default");
                    var emailId = basicInfo.FirstName + basicInfo.LastName + "@yopmail.com";
                    AutoAction.SetTextById(appWin, EmailID_ByID, emailId);
                    //AutoAction.ClickCheckBoxById(appWin, EmailCheckbox_ById); 
                    AutoAction.SetTextById(appWin, PhoneNo_ByAutoID, basicInfo.PhoneNo);
                    AutoAction.SendTabKey();
                    inputData = "FirstName: " + basicInfo.FirstName + ", LastName: " + basicInfo.LastName + ", DOB: " + basicInfo.DOB.Substring(1) + ", Gender: " + basicInfo.Gender + ", PhoneNo: " + basicInfo.PhoneNo;
                    firstName = basicInfo.FirstName;
                    lastName = basicInfo.LastName;
                    CSVHelper.UpdateRecords<BasicInfoModel>(BasicInfoModel.NewGuest, BasicInfoModel.ExistingGuest, index, InputFileName);

                    break;

                }
                index++;

            }

            AutoAction.WaitForBusyBoxByClassName(guestInfoHost, BusyBox_ByClass);
            
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

            var name = appWin.Get<Label>(SearchCriteria.ByText(firstName + " " + lastName));
            Assert.IsNotNull(name, "Unable to save basic guest info for the data, " + inputData);
        }

        [TestMethod]
        public void AddGuestInfoFemale()
        {
            AddAndReturnGuestInfoFemale();
        }

        
        public BasicInfoModel AddAndReturnGuestInfoFemale()
        {
            //bool wait = false;
            string inputData = "";
            string firstName = "";
            string lastName = "";
            int index = 0;
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var guestInfoHost = AutoElement.GetElementById(appWin, GuestInfoScreen_ByID);
            BasicInfoModel basic = null;
            //AutomationElementCollection busyBox = guestInfoHost.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, BusyBox_ByClass));

            var records = CSVHelper.GetRecords<BasicInfoModel>(InputFileName);

            foreach (var basicInfo in records)
            {
                if (basicInfo.Status == NewGuest && basicInfo.Gender == Female && basicInfo.AgeGroup==Major)
                {
                    AutoAction.SetTextById(appWin, GuestInfoFirst_ByAutoID, basicInfo.FirstName);
                    AutoAction.SetTextById(appWin, GuestInfoLast_ByAutoID, basicInfo.LastName);
                    AutoAction.SetTextById(appWin, GuestInfoMI_ByAutoID, basicInfo.MI);
                    AutoAction.SetTextById(appWin, GuestInfoDOB_ByAutoID, basicInfo.DOB.Substring(1));                   

                    if (basicInfo.Gender == BasicInfoModel.Male)
                    {
                        AutoAction.ClickRadioButtonById(appWin, GenderMale_ByAutoID);
                    }
                    else if (basicInfo.Gender == BasicInfoModel.Female)
                    {
                        AutoAction.ClickRadioButtonById(appWin, GenderFemale_ByAutoID);
                    }
                    Assert.IsTrue(!AutoElement.GetCheckBoxStateById(appWin, EmailCheckbox_ById), "EmailID checkbox is checked by default");
                    var emailId = basicInfo.FirstName + basicInfo.LastName + "@yopmail.com";
                    AutoAction.SetTextById(appWin, EmailID_ByID, emailId);
                    //AutoAction.ClickCheckBoxById(appWin, EmailCheckbox_ById); 
                    AutoAction.SetTextById(appWin, PhoneNo_ByAutoID, basicInfo.PhoneNo);
                    AutoAction.SendTabKey();
                    inputData = "FirstName: " + basicInfo.FirstName + ", LastName: " + basicInfo.LastName + ", DOB: " + basicInfo.DOB.Substring(1) + ", Gender: " + basicInfo.Gender + ", PhoneNo: " + basicInfo.PhoneNo;
                    firstName = basicInfo.FirstName;
                    lastName = basicInfo.LastName;
                    CSVHelper.UpdateRecords<BasicInfoModel>(BasicInfoModel.NewGuest, BasicInfoModel.ExistingGuest, index, InputFileName);
                    basic = basicInfo;
                    break;

                }
                index++;

            }

            AutoAction.WaitForBusyBoxByClassName(guestInfoHost, BusyBox_ByClass);
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

            var name = appWin.Get<Label>(SearchCriteria.ByText(firstName + " " + lastName));
            Assert.IsNotNull(name, "Unable to save basic guest info for the data, " + inputData);
            return basic;
        }

        [TestMethod]
        public void AddGuestInfoAgeLessThan18()
        {
               AddAndReturnGuestInfoAgeLessThan18();
        }


        public BasicInfoModel AddAndReturnGuestInfoAgeLessThan18()
        {
            string inputData = "";
            string firstName = "";
            string lastName = "";
            int index = 0;
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            //var guestInfoHost = AutoElement.GetElementById(appWin,GuestInfoScreen_ByID);
            //AutomationElementCollection busyBox = guestInfoHost.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, BusyBox_ByClass));
            string dob=null;
            var records = CSVHelper.GetRecords<BasicInfoModel>(InputFileName);
            BasicInfoModel basic = null;

            foreach (var basicInfo in records)
            {
                if (basicInfo.Status==NewGuest && basicInfo.AgeGroup==Minor)
                {
                    AutoAction.SetTextById(appWin,GuestInfoFirst_ByAutoID,basicInfo.FirstName);
                    AutoAction.SetTextById(appWin,GuestInfoLast_ByAutoID,basicInfo.LastName);
                    AutoAction.SetTextById(appWin,GuestInfoMI_ByAutoID,basicInfo.MI);
                    AutoAction.SetTextById(appWin,GuestInfoDOB_ByAutoID,basicInfo.DOB.Substring(1));                   
                    dob = basicInfo.DOB.Substring(1);
                    
                    if (basicInfo.Gender == BasicInfoModel.Male)
                    {
                        AutoAction.ClickRadioButtonById(appWin,GenderMale_ByAutoID);
                        //Actions.ClickElementByAutomationID(appWin, GenderMale_ByAutoID);
                    }
                    else if (basicInfo.Gender == BasicInfoModel.Female)
                    {
                        AutoAction.ClickRadioButtonById(appWin, GenderFemale_ByAutoID);
                    }
                    Assert.IsTrue(!AutoElement.GetCheckBoxStateById(appWin, EmailCheckbox_ById), "EmailID checkbox is checked by default");
                    var emailId = basicInfo.FirstName + basicInfo.LastName + "@yopmail.com";
                    AutoAction.SetTextById(appWin, EmailID_ByID, emailId);
                    //AutoAction.ClickCheckBoxById(appWin, EmailCheckbox_ById); 
                    AutoAction.SetTextById(appWin, PhoneNo_ByAutoID, basicInfo.PhoneNo);
                   
                    Thread.Sleep(WaitTime);
                    AutoAction.SendTabKey();

                    inputData = "FirstName: " + basicInfo.FirstName + ", LastName: " + basicInfo.LastName + ", DOB: " + basicInfo.DOB.Substring(1) + ", Gender: " + basicInfo.Gender + ", PhoneNo: " + basicInfo.PhoneNo;
                    firstName = basicInfo.FirstName;
                    lastName = basicInfo.LastName;
                    CSVHelper.UpdateRecords<BasicInfoModel>(BasicInfoModel.NewGuest, BasicInfoModel.ExistingGuest, index, InputFileName);
                    basic = basicInfo;
                    break;

                    
                }
                index++;

            }

            AutoAction.WaitForBusyBoxByClassName(appWin.AutomationElement, BusyBox_ByClass);

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

            var name = appWin.Get<Label>(SearchCriteria.ByText(firstName + " " + lastName));
            Assert.IsNotNull(name,"Unable to save basic guest info for the data, "+inputData);
            var guestDOB = appWin.Get<Label>(SearchCriteria.ByAutomationId(DOB_ByID)).Name.ToString();
            var date = guestDOB.Substring(15);
            if (date==dob)
            {
                Assert.Fail();
            }
            return basic;
        }
        

        /// <summary>
        /// Verify user is able to complete verification of the guest ID.
        /// </summary>
        [TestMethod]
        public void VerifyGuestID()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickCheckBoxById(appWin,VerifyID_ByAutoID);
            AutoAction.ClickButtonById(appWin,Next_ByID);

            Assert.IsTrue(AutoElement.ExistsByName(appWin,GuestFormsTests.RequiredForms_ByName));
            //var signCheck = appWin.GetElement(SearchCriteria.ByText(GuestFormsTests.RequiredForms_ByName));
            //Assert.IsNotNull(signCheck);
        }

        /// <summary>
        /// CTC-74: Verifying the verify GuestID checkbox is checked
        /// </summary>
        [TestMethod]
        public void CheckStatusOfVerifyGuestIDCheckBox()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            var checkBox = AutoElement.GetCheckBoxStateById(appWin,VerifyID_ByAutoID);
            Assert.IsTrue(checkBox,"CheckBox is not checked by default");
            Assert.IsTrue(AutoElement.EnabledById(appWin,Next_ByID));
        }

        /// <summary>
        /// CTC-27: Check the Verify GuestId checkbox and Verifying Next button is enabled
        /// </summary>
        [TestMethod]
        public void CheckVerifyGuestIDCheckBox()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickCheckBoxById(appWin, VerifyID_ByAutoID);
            Assert.IsTrue(AutoElement.EnabledById(appWin,Next_ByID));
        }

        /// <summary>
        /// PSC3-TS-111	MoveToGuestForms
        /// </summary>
        [TestMethod()]
        public void ClickNextButton()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);
            AutoAction.ClickButtonById(appWin, Next_ByID);
            Assert.IsTrue(AutoElement.ExistsById(appWin,GuestFormsModel.GuestFormsHost_ByID));
        }


        public void AddGuestInfo(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            AutoAction.SetTextById(appWin, GuestInfoFirst_ByAutoID, basicInfo.FirstName);
            AutoAction.SetTextById(appWin, GuestInfoLast_ByAutoID, basicInfo.LastName);
            AutoAction.SetTextById(appWin, GuestInfoMI_ByAutoID, basicInfo.MI);
            AutoAction.SetTextValuePatternById(appWin, PhoneNo_ByAutoID, basicInfo.PhoneNo);
            AutoAction.SetTextById(appWin, GuestInfoDOB_ByAutoID, basicInfo.DOB.Substring(1));            
        }

        public void VerifyGuestDetails(BasicInfoModel basicInfo)
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            var fname = AutoElement.GetTextBoxValueById(appWin,GuestInfoFirst_ByAutoID);
            Assert.AreEqual(basicInfo.FirstName.Trim(),fname,"First name is not edited");

            var lname = AutoElement.GetTextBoxValueById(appWin,GuestInfoLast_ByAutoID);
            Assert.AreEqual(basicInfo.LastName.Trim(), lname, "Last name is not edited");

            var mname = AutoElement.GetTextBoxValueById(appWin,GuestInfoMI_ByAutoID);
            Assert.AreEqual(basicInfo.MI.Trim(), mname, "Middle name is not edited");

            var phoneNo = AutoElement.GetTextBoxValueById(appWin,PhoneNo_ByAutoID);
            Assert.AreEqual(basicInfo.PhoneNo.Trim(), phoneNo, "Phone number is not edited");

            var dob = AutoElement.GetTextBoxValueById(appWin, GuestInfoDOB_ByAutoID) ;
            
            Assert.AreEqual(basicInfo.DOB.Substring(1), dob.Replace("/", ""), "dob not edited");
        }

        [TestMethod]
        public void BackToAddLabOrder()
        {
            var appWin = AutoElement.GetWindowByName(AppWindowName);

            AutoAction.ClickButtonById(appWin,Back_ByID);
            Assert.IsTrue(AutoElement.VisibleById(appWin,AddLabOrderModel.NewOrder_ByID));
        }



        //[TestMethod]
        //public void GuardianContactMandatory()
        //{
        //    var appWin = AutoElement.GetWindowByName(AppWindowName);
        //    AutoAction.ClickButtonById(appWin, Next_ByID);
        //    Assert.IsTrue(AutoElement.VisibleById(appWin,GuardianPopup_ByID));
        //    AutoAction.ClickRadioButtonById(appWin,GuardianYes_ByID);

        //    var records = CSVHelper.GetRecords<ContactModel>(InputFileName);          
        //    int index = UtilityClass.GetRandomNumber(0, records.Count);

        //    var contact = records[index];

        //    AutoAction.SetTextById(appWin, GuardianFirstName_ByID, contact.FirstName.Trim());
        //    AutoAction.SetTextById(appWin, GuardianLastName_ByID, contact.LastName.Trim());
        //    var relationship = appWin.Get<ComboBox>(SearchCriteria.ByAutomationId(GuardianRelationship_ById));
        //    relationship.Select(contact.Relationship.Trim());
        //    AutoAction.SetTextById(appWin, GuardianDOB_ByID, contact.DOB.Trim());
        //    AutoAction.SetTextById(appWin, GuardianPhone_ByID, contact.PhoneNumber.Trim());

        //    AutoAction.ClickButtonById(appWin, GuardianOkButton_ByID);
        //    Assert.IsTrue(AutoElement.VisibleById(appWin,GuestFormsModel.GuestFormsHost_ByID));
        //}

        
    }
}
