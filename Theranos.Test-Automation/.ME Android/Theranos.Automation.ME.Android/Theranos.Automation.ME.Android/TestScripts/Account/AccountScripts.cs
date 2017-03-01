using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Threading;
using Theranos.Automation.ME.Android.Android;
using Theranos.Automation.ME.Android.DataInput;
using Theranos.Automation.ME.Android.DataInput.Inputpro;
using Theranos.Automation.ME.Android.Model;
using Theranos.Automation.ME.Android.Utility;
using Theranos.Automation.PSC3.Models.CheckIn.AddGuestInfo;

namespace Theranos.Automation.ME.Android.TestScripts.Account
{
    [TestClass]
    public class AccountScripts : MEAccountModel
    {
        ActionLib Wib = new ActionLib();
        LoginValidation LV = new LoginValidation();
        public List<string> ExcelCollection = new List<string>();

        public void AccountToDashBoard(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, MELoginModel.LogOut_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.clickButton_ByName(driver, DashBoard_ByName);
            Wib.WaitForElementLoad_ByName(driver, MELoginModel.BrowseTest_ByName, AndroStack.ImplicitTimeout);
        }
        public void AccountPage(AndroidDriver<AndroidElement> driver)
        {
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.clickButton_Byid(driver, MELoginModel.MenuUsername_ById);//trying click username
            Wib.WaitForElementLoad_ByName(driver, Account_ByName, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byName(driver, Account_ByName);
            Assert.AreEqual(Account_ByName, CheckCondition);

        }
        public void AccountUserName(AndroidDriver<AndroidElement> driver)
        {

            Wib.WaitForElementLoad_ByName(driver, Account_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Account_ByName);
            Wib.WaitForElementLoad_ByName(driver, Account_ByName, AndroStack.ImplicitTimeout);
            var Checkcondition = LoginValidation.usernamelinkacc;
            Boolean IsUsernamePresent = driver.FindElements(By.Name(Checkcondition)).Count > 0;
            if (IsUsernamePresent == true)
            {
                Assert.IsTrue(true, "Username is present");
            }
            else
            {
                Assert.Fail("Username is not present");
            }
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
        }
        public void AccountPasswordUpdate(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, Account_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, Account_ById);
            Wib.WaitForElementLoad_ByName(driver, Password_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Password_ByName);
            Wib.WaitForElementLoad_ByName(driver, CurrentPassword_ByName, AndroStack.ImplicitTimeout);
            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            foreach (var re in items)
            {
                if (MELoginModel.Valid_ByName == re.Login)
                {
                    Wib.SetText_ByName(driver, CurrentPassword_ByName, re.NewPassword);
                    Wib.SetText_ByName(driver, CreateNewPassword_ByName, re.Password);
                }
            }
            Wib.clickButton_Byid(driver, SubmitBtn_ById);
            Wib.WaitForElementLoad_Byid(driver, ValidMsg_ById, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byID(driver, ValidMsg_ById);
            Assert.AreEqual(ValidMsg_ByName, CheckCondition);
            Wib.clickButton_Byid(driver, ValidMsg_ById);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
        }
        public void AccountEmailUpdate(AndroidDriver<AndroidElement> driver)
        {
            String UpdatedEmail;
            Wib.WaitForElementLoad_ByName(driver, Account_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, Account_ById);
            Wib.WaitForElementLoad_ByName(driver, Email_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Email_ByName);
            Wib.WaitForElementLoad_ByName(driver, EditEmail_ByName, AndroStack.ImplicitTimeout);
            driver.FindElement(By.Id(UpdateEmail_ById)).Clear();
            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            foreach (var re in items)
            {
                if (MELoginModel.Valid_ByName == re.Login)
                {
                    Wib.SetText_ById(driver, UpdateEmail_ById, re.UpdateEmail);
                    UpdatedEmail = re.UpdateEmail;
                    Wib.clickButton_ByName(driver, SaveBtn_ByName);
                    Wib.WaitForElementLoad_ByName(driver, Email_ByName, AndroStack.ImplicitTimeout);
                    Boolean CheckCondition = driver.FindElements(By.Name(UpdatedEmail)).Count > 0;
                    Assert.IsTrue(CheckCondition);
                }
            }
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
        }
        public void CheckAccountEmailAddress(AndroidDriver<AndroidElement> driver, BasicInfoModel basic)
        {
            var Email = basic.FirstName + basic.LastName + "@yopmail.com";
            Wib.WaitForElementLoad_ByName(driver, Account_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, Account_ById);
            Wib.WaitForElementLoad_ByName(driver, Email_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Email_ByName);
            Wib.WaitForElementLoad_ByName(driver, EditEmail_ByName, AndroStack.ImplicitTimeout);
            var MeEmail = driver.FindElement(By.Id(UpdateEmail_ById)).Text;
            Assert.AreEqual(Email, MeEmail);          
            Wib.clickButton_ByName(driver, SaveBtn_ByName);
            //Wib.WaitForElementLoad_ByName(driver, Email_ByName, AndroStack.ImplicitTimeout);
            //Boolean CheckCondition = driver.FindElements(By.Name(UpdatedEmail)).Count > 0;
            //Assert.IsTrue(CheckCondition);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_ByName(driver, Account_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
        }
        public void AccountInvalidEmail(AndroidDriver<AndroidElement> driver)
        {
            String InvalidEmail;
            Wib.WaitForElementLoad_ByName(driver, Account_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, Account_ById);
            Wib.WaitForElementLoad_ByName(driver, Email_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Email_ByName);
            Wib.WaitForElementLoad_ByName(driver, EditEmail_ByName, AndroStack.ImplicitTimeout);
            driver.FindElement(By.Id(UpdateEmail_ById)).Clear();
            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            foreach (var re in items)
            {
                if (MELoginModel.InValidEmail_ByName == re.Login)
                {
                    Wib.SetText_ById(driver, UpdateEmail_ById, re.Email);
                    InvalidEmail = re.Email;
                    Wib.clickButton_ByName(driver, SaveBtn_ByName);
                    Wib.WaitForElementLoad_ByName(driver, EmailErrorMsg_ByName, AndroStack.ImplicitTimeout);
                    var CheckCondition = Wib.getText_byID(driver, (EmailErrorMsg_ById));
                    Assert.AreEqual(EmailErrorMsg_ByName, CheckCondition);
                }
            }
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_ByName(driver, Discard_byName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Discard_byName);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
        }
        public void AccountPasscodeReset(AndroidDriver<AndroidElement> driver)
        {
            Wib.clickButton_Byid(driver, Account_ById);
            Wib.WaitForElementLoad_ByName(driver, Passcode_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Passcode_ByName);
            Wib.WaitForElementLoad_ByName(driver, PasscodeReset_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, PasscodeReset_ByName);
            Wib.WaitForElementLoad_ByName(driver, ResetPasscodeBtn_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, ResetPasscodeBtn_ByName);
            var CheckCondition = Wib.getText_byID(driver, MELoginModel.NeedHelp_ById);
            Assert.AreEqual(MELoginModel.NeedHelp_ByName, CheckCondition);
        }
        public void PasscodeValidation(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, Account_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, Account_ById);
            Wib.WaitForElementLoad_ByName(driver, Passcode_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Passcode_ByName);
            Wib.WaitForElementLoad_ByName(driver, PasscodeReset_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, PasscodeReset_ByName);
            Wib.WaitForElementLoad_ByName(driver, ResetPasscodeBtn_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, ResetPasscodeBtn_ByName);
            Wib.WaitForElementLoad_Byid(driver, MELoginModel.NeedHelp_ById, AndroStack.ImplicitTimeout);
            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            String passCode = string.Empty;
            foreach (var re in items)
            {
                if (MELoginModel.Valid_ByName == re.Login)
                {
                    driver.FindElement(By.Id(MELoginModel.UserName_ById)).Click();
                    driver.FindElement(By.Id(MELoginModel.UserName_ById)).Clear();
                    Wib.SetText_ById(driver, MELoginModel.UserName_ById, LoginValidation.usernamelinkacc);
                    Wib.SetText_ById(driver, MELoginModel.Password_ById, AndroStack.Password);
                }
            }

            Wib.clickButton_Byid(driver, MELoginModel.LoginButton_ById);
            Wib.wait(driver);
            Boolean CheckContion = driver.FindElements(By.Name(MELoginModel.PasscodePage_ByName)).Count > 0;

            if (CheckContion == true)
            {
                passCode = UtilityClass.GetRandomNumber(1000, 9999).ToString();
                foreach (char item in passCode.ToCharArray())
                {
                    var passCodeDigit = driver.FindElementByName(item.ToString());
                    passCodeDigit.Click();
                }
                string Invalidcode = MELoginModel.Code;
                foreach (char item in Invalidcode.ToCharArray())
                {
                    var passCodeDigit = driver.FindElementByName(item.ToString());
                    passCodeDigit.Click();
                }
                Wib.WaitForElementLoad_Byid(driver, MELoginModel.Title_Id, AndroStack.ImplicitTimeout);
                var CheckCondition = Wib.getText_byID(driver, MELoginModel.Title_Id);
                Assert.AreEqual(MELoginModel.WrongPasscode_ByName, CheckCondition);
                killapp();


            }
        }

        public void CheckPasswordCondition(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, Account_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, Account_ById);
            Wib.WaitForElementLoad_ByName(driver, Password_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Password_ByName);
            Wib.WaitForElementLoad_ByName(driver, CurrentPassword_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, CreateNewPassword_ByName);
            driver.Navigate().Back();
            Wib.WaitForElementLoad_Byid(driver, PasswordUpperLower_ById, 10);
            var MChar = Wib.getText_byID(driver, PasswordMiniChar_ById);
            var PUpperLower = Wib.getText_byID(driver, PasswordUpperLower_ById);
            var PNumeric = Wib.getText_byID(driver, PasswordNumeric_ById);
            Assert.AreEqual(PasswordMiniChar_ByName, MChar);
            Assert.AreEqual(PasswordUpperLower_ByName, PUpperLower);
            Assert.AreEqual(PasswordNumeric_ByName, PNumeric);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_ByName(driver, Account_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
        }
        public void CheckInvalidPasswordValidation(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, Account_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, Account_ById);
            Wib.WaitForElementLoad_ByName(driver, Password_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Password_ByName);
            Wib.WaitForElementLoad_ByName(driver, CurrentPassword_ByName, AndroStack.ImplicitTimeout);
            Wib.SetText_ByName(driver, CurrentPassword_ByName, InvalidPassword);
            Wib.SetText_ByName(driver, CreateNewPassword_ByName, "");
            Wib.WaitForElementLoad_Byid(driver, EmailErrorMsg_ById, 10);
            var ErrorMsg = Wib.getText_byID(driver, EmailErrorMsg_ById);
            Assert.AreEqual(PasswordErrorMsg_ByName, ErrorMsg);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_ByName(driver, Account_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);

        }
        public static void killapp()
        {
            System.Diagnostics.Process.Start("C:\\Apkfile\\AppKill\\appkill.bat");
            Thread.Sleep(8000);
        }

    }
}