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

namespace Theranos.Automation.ME.Android.TestScripts.Account
{
    [TestClass]
    public class UnLinkAccScripts : MEAccountModel
    {
        ActionLib Wib = new ActionLib();
        LoginValidation LV = new LoginValidation();
        public List<string> ExcelCollection = new List<string>();


        public void UnLinkAccountToDashBoard(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, MELoginModel.LogOut_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.clickButton_ByName(driver, DashBoard_ByName);
            Wib.WaitForElementLoad_ByName(driver, MELoginModel.BrowseTest_ByName, AndroStack.ImplicitTimeout);
        }
        public void UnLinkAccountPage(AndroidDriver<AndroidElement> driver)
        {
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.clickButton_Byid(driver, MELoginModel.MenuUsername_ById);//trying click username
            Wib.WaitForElementLoad_ByName(driver, Account_ByName, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byName(driver, Account_ByName);
            Assert.AreEqual(Account_ByName, CheckCondition);

        }
        public void UnLinkAccountUserName(AndroidDriver<AndroidElement> driver)
        {

            Wib.WaitForElementLoad_ByName(driver, Account_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Account_ByName);
            Wib.WaitForElementLoad_ByName(driver, Account_ByName, AndroStack.ImplicitTimeout);
            var Checkcondition = LoginValidation.unlinkacc;
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
        public void UnLinkAccountPasswordUpdate(AndroidDriver<AndroidElement> driver)
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
       
      
        public void UnLinkAccountPasscodeReset(AndroidDriver<AndroidElement> driver)
        {
            // Wib.clickButton_Byid(driver, Account_ById);
            Wib.WaitForElementLoad_ByName(driver, Passcode_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, Passcode_ByName);
            Wib.WaitForElementLoad_ByName(driver, PasscodeReset_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, PasscodeReset_ByName);
            Wib.WaitForElementLoad_ByName(driver, ResetPasscodeBtn_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, ResetPasscodeBtn_ByName);
            var CheckCondition = Wib.getText_byID(driver, MELoginModel.NeedHelp_ById);
            Assert.AreEqual(MELoginModel.NeedHelp_ByName, CheckCondition);
        }
        public void UnLinkPasscodeValidation(AndroidDriver<AndroidElement> driver)
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
                    Wib.SetText_ById(driver, MELoginModel.UserName_ById, LoginValidation.unlinkacc);
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
        public static void killapp()
        {
            System.Diagnostics.Process.Start("C:\\Apkfile\\AppKill\\appkill.bat");
            Thread.Sleep(8000);
        }
    }
}
