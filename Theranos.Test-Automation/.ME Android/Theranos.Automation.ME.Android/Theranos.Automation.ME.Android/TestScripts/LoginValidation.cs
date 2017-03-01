using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using Theranos.Automation.ME.Android.Android;
using Theranos.Automation.ME.Android.DataInput;
using Theranos.Automation.ME.Android.DataInput.Inputpro;
using Theranos.Automation.ME.Android.Model;
using Theranos.Automation.ME.Android.Utility;

namespace Theranos.Automation.ME.Android.TestScripts
{

    public class LoginValidation : MELoginModel
    {
        ActionLib Wib = new ActionLib();
        Scenario apps = new Scenario();
        private static string App_password = AndroStack.Password;
        public static string usernamelinkacc = string.Empty;
        public static string unlinkacc = string.Empty;

        public string LoginLinkedAcc(AndroidDriver<AndroidElement> driver)
        {

            if (ExcelValues.Linkusername == string.Empty)
            {
                ExcelValues.Excelindexvalue();
            }

            String passCode = string.Empty;

            Wib.WaitForElementLoad_ByName(driver, NeedHelp_ByName, AndroStack.ImplicitTimeout);
            driver.FindElement(By.Id(UserName_ById)).Click();
            driver.FindElement(By.Id(UserName_ById)).Clear();
            Wib.SetText_ById(driver, UserName_ById, ExcelValues.Linkusername);
            usernamelinkacc = ExcelValues.Linkusername;
            Wib.SetText_ById(driver, Password_ById, App_password);
            Wib.clickButton_Byid(driver, LoginButton_ById);
            Wib.wait(driver);
            Boolean CheckContion = driver.FindElements(By.Name(PasscodePage_ByName)).Count > 0;

            if (CheckContion == true)
            {
                passCode = UtilityClass.GetRandomNumber(1000, 9999).ToString();
                SetPasscode(driver, passCode);
                Wib.WaitForElementLoad_ByName(driver, BrowseTest_ByName, AndroStack.ImplicitTimeout);
                var CheckCondition = Wib.getText_byName(driver, BrowseTest_ByName);
                Assert.AreEqual(BrowseTest_ByName, CheckCondition);
                return passCode;
            }
            else
            {
                Wib.WaitForElementLoad_ByName(driver, BrowseTest_ByName, AndroStack.ImplicitTimeout);
                var CheckCondition = Wib.getText_byName(driver, BrowseTest_ByName);
                Assert.AreEqual(BrowseTest_ByName, CheckCondition);

            }
            return passCode;

        }
        public string LoginUnLinkedAcc(AndroidDriver<AndroidElement> driver)
        {

            if (ExcelValues.Linkusername == string.Empty)
            {
                ExcelValues.Excelindexvalue();
            }

            String passCode = string.Empty;

            Wib.WaitForElementLoad_ByName(driver, NeedHelp_ByName, AndroStack.ImplicitTimeout);
            driver.FindElement(By.Id(UserName_ById)).Click();
            driver.FindElement(By.Id(UserName_ById)).Clear();
            Wib.SetText_ById(driver, UserName_ById, UnLinkAccount_ByName);
            unlinkacc = UnLinkAccount_ByName;
            Wib.SetText_ById(driver, Password_ById, App_password);
            Wib.clickButton_Byid(driver, LoginButton_ById);
            Wib.wait(driver);
            Boolean CheckContion = driver.FindElements(By.Name(PasscodePage_ByName)).Count > 0;

            if (CheckContion == true)
            {
                passCode = UtilityClass.GetRandomNumber(1000, 9999).ToString();
                SetPasscode(driver, passCode);
                Wib.WaitForElementLoad_ByName(driver, BrowseTest_ByName, AndroStack.ImplicitTimeout);
                var CheckCondition = Wib.getText_byName(driver, BrowseTest_ByName);
                Assert.AreEqual(BrowseTest_ByName, CheckCondition);
                return passCode;
            }
            else
            {
                Wib.WaitForElementLoad_ByName(driver, BrowseTest_ByName, AndroStack.ImplicitTimeout);
                var CheckCondition = Wib.getText_byName(driver, BrowseTest_ByName);
                Assert.AreEqual(BrowseTest_ByName, CheckCondition);

            }
            return passCode;

        }
        public void ResendEmailActivate(AndroidDriver<AndroidElement> driver)
        {

            if (ExcelValues.Linkusername == string.Empty)
            {
                ExcelValues.Excelindexvalue();
            }
            Wib.WaitForElementLoad_Byid(driver, NeedHelp_ById, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byID(driver, NeedHelp_ById);
            Assert.AreEqual(NeedHelp_ByName, CheckCondition);
            Wib.SetText_ById(driver, UserName_ById, ExcelValues.NewUserName);
            Wib.SetText_ById(driver, Password_ById, App_password);
            Wib.clickButton_Byid(driver, LoginButton_ById);
            Wib.WaitForElementLoad_ByName(driver, VerifyAcc_ResendBtn_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, VerifyAcc_ResendBtn_ByName);
         

        }
        public MELoginModel LoginSignUpUserProvisional(AndroidDriver<AndroidElement> driver)
        {
            ExcelValues.Excelindexvalue();
            MELoginModel _collect = new MELoginModel
            {
                FirstName = ExcelValues.FirstName,
                LastName = ExcelValues.LastName,

            };
            String passCode = string.Empty;

            Wib.WaitForElementLoad_ByName(driver, NeedHelp_ByName, AndroStack.ImplicitTimeout);
            driver.FindElement(By.Id(UserName_ById)).Click();
            driver.FindElement(By.Id(UserName_ById)).Clear();
            Wib.SetText_ById(driver, UserName_ById, ExcelValues.NewUserName);
            Wib.SetText_ById(driver, Password_ById, App_password);
            Wib.clickButton_Byid(driver, LoginButton_ById);
            Wib.wait(driver);
            Boolean CheckContion = driver.FindElements(By.Name(PasscodePage_ByName)).Count > 0;

            if (CheckContion == true)
            {
                passCode = UtilityClass.GetRandomNumber(1000, 9999).ToString();
                SetPasscode(driver, passCode);
                Wib.WaitForElementLoad_ByName(driver, BrowseTest_ByName, AndroStack.ImplicitTimeout);
                var CheckCondition = Wib.getText_byName(driver, BrowseTest_ByName);
                Assert.AreEqual(BrowseTest_ByName, CheckCondition);

            }
            else
            {
                Wib.WaitForElementLoad_ByName(driver, BrowseTest_ByName, AndroStack.ImplicitTimeout);
                var CheckCondition = Wib.getText_byName(driver, BrowseTest_ByName);
                Assert.AreEqual(BrowseTest_ByName, CheckCondition);

            }
            return _collect;
        }
        public void LogOut(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, BrowseTest_ByName, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byName(driver, BrowseTest_ByName);
            Assert.AreEqual(BrowseTest_ByName, CheckCondition);
            Wib.clickButton_Byclass(driver, Orders.MenuButton_ByClass);
            Wib.WaitForElementLoad_Byid(driver, MenuUsername_ById, AndroStack.ImplicitTimeout);
            Wib.clickButton_Byid(driver, MenuUsername_ById);
            Wib.WaitForElementLoad_ByName(driver, LogOut_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, LogOut_ByName);
            Wib.WaitForElementLoad_ByName(driver, NeedHelp_ByName, 20);
            var ActualResult = Wib.getText_byName(driver, NeedHelp_ByName);
            Assert.AreEqual(NeedHelp_ByName, ActualResult);

        }
        public void DirectLogOut(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_ByName(driver, LogOut_ByName, AndroStack.ImplicitTimeout);
            Wib.clickButton_ByName(driver, LogOut_ByName);
            Wib.WaitForElementLoad_ByName(driver, NeedHelp_ByName, 20);
            var ActualResult = Wib.getText_byName(driver, NeedHelp_ByName);
            Assert.AreEqual(NeedHelp_ByName, ActualResult);
        }
        public void SetPasscode(AndroidDriver<AndroidElement> driver, string passCode)
        {
            foreach (char item in passCode.ToCharArray())
            {
                var passCodeDigit = driver.FindElementByName(item.ToString());
                passCodeDigit.Click();
            }

            foreach (char item in passCode.ToCharArray())
            {
                var passCodeDigit = driver.FindElementByName(item.ToString());
                passCodeDigit.Click();
            }
        }
        public void InvalidUserName(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, NeedHelp_ById, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byID(driver, NeedHelp_ById);
            Assert.AreEqual(NeedHelp_ByName, CheckCondition);
            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            foreach (var re in items)
            {
                if (InValidUserName_ByName == re.Login)
                {
                    Wib.SetText_ById(driver, UserName_ById, re.NewUserName);
                    Wib.SetText_ById(driver, Password_ById, re.NewPassword);
                    Wib.clickButton_Byid(driver, LoginButton_ById);
                    Wib.WaitForElementLoad_ByName(driver, InValidMSg_ByName, AndroStack.ImplicitTimeout);
                    var ActualResult = Wib.getText_byID(driver, InValidMSg_ById);
                    Wib.clickButton_Byid(driver, InValidMSg_ById);
                    Assert.AreEqual(InValidMSg_ByName, ActualResult);
                }
            }
        }
        public void InvalidPassWord(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, NeedHelp_ById, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byID(driver, NeedHelp_ById);
            Assert.AreEqual(NeedHelp_ByName, CheckCondition);
            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            foreach (var re in items)
            {
                if (InValidPassword_ByName == re.Login)
                {
                    Wib.SetText_ById(driver, UserName_ById, re.NewUserName);
                    Wib.SetText_ById(driver, Password_ById, re.NewPassword);
                    Wib.clickButton_Byid(driver, LoginButton_ById);
                    Wib.WaitForElementLoad_ByName(driver, InValidMSg_ByName, AndroStack.ImplicitTimeout);
                    var ActualResult = Wib.getText_byID(driver, InValidMSg_ById);
                    Wib.clickButton_Byid(driver, InValidMSg_ById);
                    Assert.AreEqual(InValidMSg_ByName, ActualResult);
                }
            }
        }
        public void InvalidCredentials(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, NeedHelp_ById, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byID(driver, NeedHelp_ById);
            Assert.AreEqual(NeedHelp_ByName, CheckCondition);
            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            foreach (var re in items)
            {
                if (InValidCredentials_ByName == re.Login)
                {
                    String ExpectedResult = InValidMSg_ByName;
                    Wib.SetText_ById(driver, UserName_ById, re.NewUserName);
                    Wib.SetText_ById(driver, Password_ById, re.NewPassword);
                    Wib.clickButton_Byid(driver, LoginButton_ById);
                    Wib.WaitForElementLoad_ByName(driver, InValidMSg_ByName, AndroStack.ImplicitTimeout);
                    var ActualResult = Wib.getText_byID(driver, InValidMSg_ById);
                    Wib.clickButton_Byid(driver, InValidMSg_ById);
                    Assert.AreEqual(InValidMSg_ByName, ActualResult);
                }
            }
        }
        public void InActivateAccount(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, NeedHelp_ById, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byID(driver, NeedHelp_ById);
            Assert.AreEqual(NeedHelp_ByName, CheckCondition);
            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            foreach (var re in items)
            {
                if (InActivateAccount_ByName == re.Login)
                {
                    String ExpectedResult = VerifyAcc_ByName;
                    Wib.SetText_ById(driver, UserName_ById, re.NewUserName);
                    Wib.SetText_ById(driver, Password_ById, re.NewPassword);
                    Wib.clickButton_Byid(driver, LoginButton_ById);
                    Wib.WaitForElementLoad_ByName(driver, VerifyAcc_ByName, AndroStack.ImplicitTimeout);
                    var ActualResult = Wib.getText_byID(driver, VerifyAcc_ById);
                    Wib.clickButton_ByName(driver, VerifyAcc_OkBtn_ByName);
                    Assert.AreEqual(VerifyAcc_ByName, ActualResult);
                }
            }
        }
        public void BlockedAccount(AndroidDriver<AndroidElement> driver)
        {
            Wib.WaitForElementLoad_Byid(driver, NeedHelp_ById, AndroStack.ImplicitTimeout);
            var CheckCondition = Wib.getText_byID(driver, NeedHelp_ById);
            Assert.AreEqual(NeedHelp_ByName, CheckCondition);
            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            foreach (var re in items)
            {
                if (BlockedAccount_ByName == re.Login)
                {
                    Wib.SetText_ById(driver, UserName_ById, re.NewUserName);
                    Wib.SetText_ById(driver, Password_ById, re.NewPassword);
                    Wib.clickButton_Byid(driver, LoginButton_ById);
                    Wib.WaitForElementLoad_ByName(driver, AccountBlock_ByName, AndroStack.ImplicitTimeout);
                    var ActualResult = Wib.getText_byID(driver, VerifyAcc_ById);
                    Wib.clickButton_ByName(driver, VerifyAcc_OkBtn_ByName);
                    Assert.AreEqual(AccountBlock_ByName, ActualResult);
                }
            }
        }
    }
}
