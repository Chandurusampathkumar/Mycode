using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using Theranos.Automation.ME.Android.Android;
using Theranos.Automation.ME.Android.DataInput;
using Theranos.Automation.ME.Android.DataInput.Inputpro;
using Theranos.Automation.ME.Android.Model;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;

namespace Theranos.Automation.ME.Android.TestScripts.BasicInfo
{

    public class BasicInfoScripts : MEAccountModel
    {
        ActionLib Wib = new ActionLib();

        public void BasicInfoPage(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, Account_ByName, AndroStack.ImplicitTimeout);
            var IsPresent = driver.FindElements(By.Name(BasicInfo_ByName)).Count > 0;
            if (IsPresent == true)
            {
                Wib.WaitForElementLoad_ByName(driver, BasicInfo_ByName, AndroStack.ImplicitTimeout);
                Wib.clickButton_ByName(driver, BasicInfo_ByName);
                Wib.WaitForElementLoad_ByName(driver, BasicInfo_ByName, AndroStack.ImplicitTimeout);
                var CheckCondition = Wib.getText_byName(driver, BasicInfo_ByName);
                Assert.AreEqual(BasicInfo_ByName, CheckCondition);
            }
            else
            {
                Assert.Fail(".ME account not yet linked with PSC!");
            }
        }
        public void BasicInfoToDashBoard(AndroidDriver<AndroidElement> driver)
        {

            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_ByName(driver, MELoginModel.LogOut_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.clickButton_ByName(driver, DashBoard_ByName);
            Wib.WaitForElementLoad_ByName(driver, MELoginModel.BrowseTest_ByName, AndroStack.ImplicitTimeout);

        }
        public void BasicinfoUserName(AndroidDriver<AndroidElement> driver)
        {
            //var UserName = Basic.FirstName +" "+ Basic.LastName;
            Wib.WaitForElementLoad_ByName(driver, BasicInfo_ByName, AndroStack.ImplicitTimeout);
            var IsUserNamePresent = driver.FindElements(By.ClassName(Textview_ByClass));
            if (IsUserNamePresent[2].Text != null)
            {
                Assert.IsTrue(true, "Username is present");
            }
            else
            {
                Assert.Fail("Username is empty");
            }

        }
        public void BasicInfoDateOfBirth(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, BasicInfo_ByName, AndroStack.ImplicitTimeout);
            var IsDateOfBirthPresent = driver.FindElements(By.ClassName(Textview_ByClass));
            if (IsDateOfBirthPresent[4].Text != null)
            {
                Assert.IsTrue(true, "Date of birth is present");
            }
            else
            {
                Assert.Fail("Date of birth is empty");
            }

        }
        public void BasicInfoGender(AndroidDriver<AndroidElement> driver)
        {
          
            Wib.WaitForElementLoad_ByName(driver, BasicInfo_ByName, AndroStack.ImplicitTimeout);
            var IsGenderPresent = driver.FindElements(By.ClassName(Textview_ByClass));
            if (IsGenderPresent[6].Text != null)
            {
                Assert.IsTrue(true, "Gender is present");
            }
            else
            {
                Assert.Fail("Gender is present");
            }


        }
        public void LinkedAccountMailingAddress(AndroidDriver<AndroidElement> driver)
        {
            //,AddressModel add
            Wib.WaitForElementLoad_ByName(driver, BasicInfo_ByName, AndroStack.ImplicitTimeout);
            var IsAddressPresent = driver.FindElements(By.ClassName(Textview_ByClass));
            if (IsAddressPresent[8].Text != NoMailingAddress_ByName)
            {
                
                Assert.IsTrue(true, "Address is present");
            }
            else
            {
                Assert.Fail("Address is not present");
            }

        }
        public void ProvisionalAccountMailingAddress(AndroidDriver<AndroidElement> driver)
        {
            BasicInfoMailingAddressPage(driver);
            AddBasicInfoMailingAddress(driver);

        }
        public void LinkedAccountBasicInfoPage(AndroidDriver<AndroidElement> driver)
        {
            BasicinfoUserName(driver);
            BasicInfoDateOfBirth(driver);
            BasicInfoGender(driver);
            LinkedAccountMailingAddress(driver);

        }
        public void BasicInfoMailingAddressPage(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, BasicInfoMailingAdd_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, BasicInfoMailingAdd_ById);
            Wib.WaitForElementLoad_ByName(driver, EditAddress_ByName, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byName(driver, EditAddress_ByName);
            Assert.AreEqual(EditAddress_ByName, CheckCondition);
        }
        public void AddBasicInfoMailingAddress(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, EditAddress_ByName, AndroStack.ImplicitTimeout);
            //var items = CSVReader.GetRecords<UserInfo>(CsvModel.UserInfo);
            //foreach (var re in items)
            //{
            //if (Auto_ByName == re.FirstName)
            //{
            if (ExcelValues.Linkusername == string.Empty)
            {
                ExcelValues.Excelindexvalue();
            }
            var SetText = driver.FindElementsByClassName(editEmail_byclassname);
            int j = 0;
            foreach (var updatetext in SetText)
            {
                if (j == 0)
                {
                    SetText[0].Click();
                    SetText[0].Clear();
                    SetText[0].SendKeys(ExcelValues.StreetLine1);
                }
                else if (j == 1)
                {
                    SetText[1].Click();
                    SetText[1].Clear();
                    SetText[1].SendKeys(ExcelValues.StreetLine2);

                }
                else if (j == 2)
                {
                    SetText[2].Click();
                    SetText[2].Clear();
                    SetText[2].SendKeys(ExcelValues.City);

                }
                else if (j == 3)
                {
                    driver.Navigate().Back();
                    SetText[3].Click();
                    driver.FindElement(By.Name(ExcelValues.City)).Click();
                }
                else if (j == 4)
                {
                    var zipcode = driver.FindElementById(zipcodeupdate);
                    zipcode.Click();
                    zipcode.SendKeys(Keys.Control + "a");
                    zipcode.SendKeys(Keys.Delete);
                    zipcode.Clear();
                    zipcode.SendKeys(ExcelValues.ZipCode);

                } j++;
                //}

                //}
            }
            driver.Navigate().Back();

            Wib.WaitForElementLoad_ByName(driver, SaveBtn_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, SaveBtn_ByName);
            Wib.WaitForElementLoad_ByName(driver, BasicInfo_ByName, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byName(driver, BasicInfo_ByName);
            Assert.AreEqual(BasicInfo_ByName, CheckCondition);
        }
        public void BasicInfoMobile(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, BasicInfo_ByName, AndroStack.ImplicitTimeout);
            driver.ScrollTo(Gender_ByName);
            Wib.WaitForElementLoad_ByName(driver, Mobile_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Mobile_ByName);
            Wib.WaitForElementLoad_ByName(driver, EditPhoneNumber_ByName, AndroStack.ImplicitTimeout);
            //var items = CSVReader.GetRecords<UserInfo>(CsvModel.UserInfo);
            //foreach (var re in items)
            //{
            //    if (Auto_ByName == re.FirstName)
            //    {
            if (ExcelValues.Linkusername == string.Empty)
            {
                ExcelValues.Excelindexvalue();
            }
            var SetNumber = driver.FindElements(By.ClassName(Edit_ByClass));
            SetNumber[0].SendKeys(ExcelValues.MobileNumber);
            SetNumber[1].SendKeys(ExcelValues.HomeNumber);
            //}
            //}
            Wib.clickButton_ByName(driver, SaveBtn_ByName);
            Wib.WaitForElementLoad_ByName(driver, BasicInfo_ByName, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byName(driver, BasicInfo_ByName);
            Assert.AreEqual(BasicInfo_ByName, CheckCondition);
            //Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);

        }
        public void EmergencyContactsPage(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, EmergencyContact_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, EmergencyContact_ByName);
            Wib.WaitForElementLoad_Byid(driver, AddContact_ById, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byName(driver, EmergencyContact_ByName);
            Assert.AreEqual(EmergencyContact_ByName, CheckCondition);


        }
        public void AddEmergencyContactspage(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, AddContact_ById, AndroStack.ImplicitTimeout);
            Boolean IsFirstContact = driver.FindElements(By.Id(InsuranceIcon_ById)).Count > 0;
            if (IsFirstContact == true)
            {
                var CountBeforeAdd = driver.FindElements(By.ClassName(ContactsList_Byclass));
                Wib.clickButton_Byid(driver, AddContact_ById);
                Wib.WaitForElementLoad_ByName(driver, AddEmergencyContact_ByName, AndroStack.ImplicitTimeout);
                Wib.clickButton_ByName(driver, AddEmergencyContact_ByName);

                Wib.WaitForElementLoad_ByName(driver, FirstName_ByName, AndroStack.ImplicitTimeout);
                var items = CSVReader.GetRecords<UserInfo>(CsvModel.UserInfo);
                foreach (var re in items)
                {
                    if (Auto_ByName == re.FirstName)
                    {
                        Wib.SetText_ByName(driver, FirstName_ByName, re.FirstName);
                        Wib.SetText_ByName(driver, LastName_ByName, re.LastName);
                        Wib.clickButton_ByName(driver, Relationship_ByName);
                        Wib.WaitForElementLoad_Byid(driver, ListView_ById, AndroStack.ImplicitTimeout);
                        driver.FindElement(By.Name("Friend")).Click();
                        Wib.SetText_ByName(driver, Phone_ByName, re.MobileNumber);
                        driver.ScrollTo(Email_ByName);
                        Wib.SetText_ByName(driver, Email_ByName, re.Email);
                    }
                }
                Wib.clickButton_ByName(driver, SaveBtn_ByName);
                Wib.WaitForElementLoad_ByName(driver, EmergencyContact_ByName, AndroStack.ImplicitTimeout);
                var CountAfterAdd = driver.FindElements(By.ClassName(ContactsList_Byclass));

                if (CountAfterAdd.Count > CountBeforeAdd.Count)
                {
                    Assert.IsTrue(true, "Contact added successfully");

                }
            }
            else
            {
                var CountBeforeAdd = driver.FindElements(By.ClassName(ContactsList_Byclass));
                Wib.clickButton_Byid(driver, AddContact_ById);
                Wib.WaitForElementLoad_ByName(driver, AddEmergencyContact_ByName, AndroStack.ImplicitTimeout);
                Wib.clickButton_ByName(driver, AddEmergencyContact_ByName);

                Wib.WaitForElementLoad_ByName(driver, FirstName_ByName, AndroStack.ImplicitTimeout);
                var items = CSVReader.GetRecords<UserInfo>(CsvModel.UserInfo);
                foreach (var re in items)
                {
                    if (Auto_ByName == re.FirstName)
                    {
                        Wib.SetText_ByName(driver, FirstName_ByName, re.FirstName);
                        Wib.SetText_ByName(driver, LastName_ByName, re.LastName);
                        Wib.clickButton_ByName(driver, Relationship_ByName);
                        Wib.WaitForElementLoad_Byid(driver, ListView_ById, AndroStack.ImplicitTimeout);
                        driver.FindElement(By.Name("Friend")).Click();
                        Wib.SetText_ByName(driver, Phone_ByName, re.MobileNumber);
                        driver.ScrollTo(Email_ByName);
                        Wib.SetText_ByName(driver, Email_ByName, re.Email);
                    }
                }
                Wib.clickButton_ByName(driver, SaveBtn_ByName);
                Wib.WaitForElementLoad_ByName(driver, EmergencyContact_ByName, AndroStack.ImplicitTimeout);
                var CountAfterAdd = driver.FindElements(By.ClassName(ContactsList_Byclass));
                if (CountAfterAdd.Count > CountBeforeAdd.Count)
                {
                    Assert.IsTrue(true, "Contact added successfully");

                }

            }

        }
        public void RemoveEmergencyContact(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, EmergencyContact_ByName, AndroStack.ImplicitTimeout);
            var CountBeforeRemove = driver.FindElements(By.ClassName(ContactsList_Byclass));
            Boolean Contact = driver.FindElements(By.ClassName(ContactsList_Byclass)).Count > 4;

            if (Contact == true)
            {
                var Lists = driver.FindElements(By.ClassName(ContactsList_Byclass));
                Lists[4].Click();
                driver.ScrollTo("Remove contact");
                Wib.ElementClickable_Byid(driver, RemoveContact_ById, AndroStack.ImplicitTimeout);
                Wib.clickButton_Byid(driver, RemoveContact_ById);
                Wib.WaitForElementLoad_ByName(driver, RemoveBtn_ByName, AndroStack.ImplicitTimeout);
                Wib.clickButton_ByName(driver, RemoveBtn_ByName);

            }
            else
            {
                Assert.Fail("No Emergency Contacts to remove");
            }
            Wib.WaitForElementLoad_ByName(driver, EmergencyContact_ByName, AndroStack.ImplicitTimeout);
            var CountAfterRemove = driver.FindElements(By.ClassName(ContactsList_Byclass));
            if (CountBeforeRemove.Count > CountAfterRemove.Count)
            {
                Assert.IsTrue(true, "Emergency Contact is removed !");

            }
            else
            {
                Assert.Fail();
            }
        }
        public void EditEmergencyContact(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, EmergencyContact_ByName, AndroStack.ImplicitTimeout);
            var CountBeforeRemove = driver.FindElements(By.ClassName(ContactsList_Byclass));
            Boolean Contact = driver.FindElements(By.ClassName(ContactsList_Byclass)).Count > 4;
            if (Contact == true)
            {
                var Lists = driver.FindElements(By.ClassName(ContactsList_Byclass));
                Lists[4].Click();
                Wib.WaitForElementLoad_ByName(driver, EditContact_ByName, AndroStack.ImplicitTimeout);
                var items = CSVReader.GetRecords<UserInfo>(CsvModel.UserInfo);
                foreach (var re in items)
                {
                    if (Edit_ByName == re.CheckCondition)
                    {
                        var InPut = driver.FindElements(By.Id("com.theranos.me:id/cv_inputbase_inputfield"));
                        InPut[0].SendKeys(re.FirstName);
                        InPut[1].SendKeys(re.LastName);
                        InPut[2].Click();
                        Wib.WaitForElementLoad_Byid(driver, ListView_ById, AndroStack.ImplicitTimeout);
                        driver.FindElement(By.Name("Friend")).Click();
                        //InPut[3].SendKeys(re.MobileNumber);
                        //driver.Navigate().Back();
                        //driver.ScrollTo(re.Email);
                        //   InPut[4].SendKeys(re.Email);

                    }
                }
            }
            else
            {
                Assert.Fail("No Contact to edit.");
            }
            Wib.clickButton_ByName(driver, SaveBtn_ByName);
            Wib.WaitForElementLoad_ByName(driver, EmergencyContact_ByName, AndroStack.ImplicitTimeout);
            var Checkcondition = Wib.getText_byName(driver, EmergencyContact_ByName);
            Assert.AreEqual(EmergencyContact_ByName, Checkcondition);

        }
        public void RemoveEmergencyValidation(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, EmergencyContact_ByName, AndroStack.ImplicitTimeout);
            Boolean Contact = driver.FindElements(By.ClassName(ContactsList_Byclass)).Count > 4;

            if (Contact == true)
            {
                var Lists = driver.FindElements(By.ClassName(ContactsList_Byclass));
                Lists[4].Click();
                driver.ScrollTo("Remove contact");
                Wib.ElementClickable_Byid(driver, RemoveContact_ById, AndroStack.ImplicitTimeout);
                Wib.clickButton_Byid(driver, RemoveContact_ById);
                Wib.WaitForElementLoad_ByName(driver, RemoveBtn_ByName, AndroStack.ImplicitTimeout);
                Wib.clickButton_ByName(driver, CancelBtn_ByName);

            }
            else
            {
                Assert.Fail("No Emergency Contacts to remove");
            }
            Wib.WaitForElementLoad_ByName(driver, EditContact_ByName, AndroStack.ImplicitTimeout);
            Assert.IsTrue(true, "Inside Edit Emergency contact page");
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_ByName(driver, EmergencyContact_ByName, AndroStack.ImplicitTimeout);

        }
    }
}
