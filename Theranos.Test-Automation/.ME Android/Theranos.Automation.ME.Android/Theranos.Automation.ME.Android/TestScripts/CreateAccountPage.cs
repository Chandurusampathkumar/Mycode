using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;
using Theranos.Automation.ME.Android.Android;
using Theranos.Automation.ME.Android.DataInput;
using Theranos.Automation.ME.Android.DataInput.Inputpro;
using Theranos.Automation.ME.Android.Model;

namespace Theranos.Automation.ME.Android.TestScripts
{
    public class CreateAccountPage : MELoginModel
    {
        public static IWebDriver Driver;
        ActionLib Wib = new ActionLib();
        CSVReader csv = new CSVReader();

        public void CreateAccount(AndroidDriver<AndroidElement> Driver)
        {
            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            foreach (var re in items)
            {
                if (Valid_ByName == re.Login)
                {
                    if (ExcelValues.NewUserName == string.Empty)
                    {
                        ExcelValues.Excelindexvalue();
                    }
                    Wib.clickButton_Byid(Driver, CreateAccount_ById);
                    Wib.SetText_ByName(Driver, Email_ByName, ExcelValues.NewUserName+"@yopmail.com");
                    Driver.Navigate().Back();
                    Wib.SetText_ByName(Driver, NewUsername_ByName, ExcelValues.NewUserName);
                    Driver.Navigate().Back();
                    Wib.SetText_ByName(Driver, Password_ByName, re.NewPassword);
                    Driver.Navigate().Back();
                    Wib.clickButton_Byid(Driver, CheckBox_ById);
                    Wib.clickButton_Byid(Driver, ContinueBtn_ById);
                    Wib.WaitForElementLoad_Byid(Driver, Securityone_ById, AndroStack.ImplicitTimeout);
                    Wib.SetTextAND_ById(Driver, Securityone_ById, Ans_byName, re.Ansone);
                    Driver.Navigate().Back();
                    Wib.SetTextAND_ById(Driver, Securitytwo_ById, Ans_byName, re.Anstwo);
                    Driver.Navigate().Back();
                    Wib.SetTextAND_ById(Driver, Securitythree_ById, Ans_byName, re.Ansthree);
                    Wib.clickButton_Byid(Driver, ContinueBtn_ById);
                    Wib.WaitForElementLoad_Byid(Driver, NeedHelp_ById, AndroStack.ImplicitTimeout);
                    var CheckCondition = Wib.getText_byID(Driver, NeedHelp_ById);
                    Assert.AreEqual(NeedHelp_ByName, CheckCondition);

                }
            }
        }
        public void AlreadyCreatedAccount(AndroidDriver<AndroidElement> Driver)
        {
            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            foreach (var re in items)
            {
                if (Valid_ByName == re.Login)
                {
                    Wib.clickButton_Byid(Driver, CreateAccount_ById);
                    Wib.SetText_ByName(Driver, Email_ByName, re.Email);
                    Driver.Navigate().Back();
                    Wib.SetText_ByName(Driver, NewUsername_ByName, ExcelValues.NewUserName);
                    Driver.Navigate().Back();
                    Wib.clickButton_Byid(Driver, CheckBox_ById);
                    Wib.WaitForElementLoad_ByName(Driver, UserNameMess_byName, AndroStack.ImplicitTimeout);
                    var name = Wib.getText_byName(Driver, UserNameMess_byName);
                    Wib.clickButton_ByName(Driver, VerifyAcc_OkBtn_ByName);
                    Assert.AreEqual(UserNameMess_byName, name);
                    Wib.clickButton_Byclass(Driver, Orders.MenuButton_ByClass);
                    Wib.WaitForElementLoad_ByName(Driver, NeedHelp_ByName, AndroStack.ImplicitTimeout);
                    var ActualResult = Wib.getText_byID(Driver, NeedHelp_ById);
                    Assert.AreEqual(NeedHelp_ByName, ActualResult);
                }
            }
        }
        public void CreatedAccount_InvalidEmail(AndroidDriver<AndroidElement> Driver)
        {
            var CheckCondition = Wib.getText_byID(Driver, NeedHelp_ById);
            Assert.AreEqual(NeedHelp_ByName, CheckCondition);
            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            foreach (var re in items)
            {
                if (InValidEmail_ByName == re.Login)
                {
                    Wib.clickButton_Byid(Driver, CreateAccount_ById);
                    Wib.SetText_ByName(Driver, Email_ByName, re.Email);
                    Driver.Navigate().Back();
                    Wib.clickButton_Byid(Driver, CheckBox_ById);
                    var Aemail = Driver.FindElement(By.Id(Email_errmsg_ById)).Text;
                    Wib.SetText_ByName(Driver, NewUsername_ByName, re.NewUserName);
                    Driver.Navigate().Back();
                    Wib.clickButton_Byid(Driver, CheckBox_ById);
                    Assert.AreEqual(EmailErrMsg, Aemail);
                    Wib.clickButton_Byclass(Driver, Orders.MenuButton_ByClass);
                }
            }
        }
        public void CreatedAccount_InvalidUsername(AndroidDriver<AndroidElement> Driver)
        {
            var CheckCondition = Wib.getText_byID(Driver, NeedHelp_ById);
            Assert.AreEqual(NeedHelp_ByName, CheckCondition);
            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            foreach (var re in items)
            {
                if (InValidUserName_ByName == re.Login)
                {
                    Wib.clickButton_Byid(Driver, CreateAccount_ById);
                    Wib.SetText_ByName(Driver, Email_ByName, re.Email);
                    Driver.Navigate().Back();
                    Wib.clickButton_Byid(Driver, CheckBox_ById);
                    Wib.SetText_ByName(Driver, NewUsername_ByName, re.NewUserName);
                    Driver.Navigate().Back();
                    Wib.SetText_ByName(Driver, Password_ByName, re.NewPassword);
                    Driver.Navigate().Back();
                    var AUsername = Driver.FindElement(By.Id(Email_errmsg_ById)).Text;
                    Wib.clickButton_Byid(Driver, CheckBox_ById);
                    Assert.AreEqual(UsernameSpecialChac, AUsername);
                    Wib.clickButton_Byclass(Driver, Orders.MenuButton_ByClass);
                }
            }
        }
        public void AgeValidation(AndroidDriver<AndroidElement> Driver)
        {
            var CheckCondition = Wib.getText_byID(Driver, NeedHelp_ById);
            Assert.AreEqual(NeedHelp_ByName, CheckCondition);

            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            foreach (var re in items)
            {
                if (AgeValid_ByName == re.Login)
                {
                    Wib.clickButton_Byid(Driver, CreateAccount_ById);
                    Wib.SetText_ByName(Driver, Email_ByName, re.Email);
                    Driver.Navigate().Back();
                    Wib.SetText_ByName(Driver, NewUsername_ByName, re.NewUserName);
                    Driver.Navigate().Back();
                    Wib.SetText_ByName(Driver, Password_ByName, re.NewPassword);
                    Driver.Navigate().Back();
                    var Actual = Driver.FindElement(By.Id(ContinueBtn_ById)).Enabled;
                    Assert.IsFalse(Actual);
                    Wib.clickButton_Byclass(Driver, Orders.MenuButton_ByClass);

                }
            }
        }
        public void InvalidPasswordSevenChar(AndroidDriver<AndroidElement> Driver)
        {
            var CheckCondition = Wib.getText_byID(Driver, NeedHelp_ById);
            Assert.AreEqual(NeedHelp_ByName, CheckCondition);
            // var Expected = false;
            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            foreach (var re in items)
            {
                if (AgeValid_ByName == re.Login)
                {
                    Wib.clickButton_Byid(Driver, CreateAccount_ById);
                    Wib.SetText_ByName(Driver, Email_ByName, re.Email);
                    Driver.Navigate().Back();
                    Wib.SetText_ByName(Driver, NewUsername_ByName, re.NewUserName);
                    Driver.Navigate().Back();
                    Wib.SetText_ByName(Driver, Password_ByName, SevenCharPsdByName);
                    Driver.Navigate().Back();
                    Wib.clickButton_Byid(Driver, CheckBox_ById);
                    var Actual = Driver.FindElement(By.Id(ContinueBtn_ById)).Enabled;
                    // Assert.AreEqual(Expected, Actual);
                    Assert.IsFalse(Actual);
                    Wib.clickButton_Byclass(Driver, Orders.MenuButton_ByClass);

                }
            }
        }
        public void InvalidPasswordNoUpperChar(AndroidDriver<AndroidElement> Driver)
        {
            var CheckCondition = Wib.getText_byID(Driver, NeedHelp_ById);
            Assert.AreEqual(NeedHelp_ByName, CheckCondition);
            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            foreach (var re in items)
            {
                if (AgeValid_ByName == re.Login)
                {
                    Wib.clickButton_Byid(Driver, CreateAccount_ById);
                    Wib.SetText_ByName(Driver, Email_ByName, re.Email);
                    Driver.Navigate().Back();
                    Wib.SetText_ByName(Driver, NewUsername_ByName, re.NewUserName);
                    Driver.Navigate().Back();
                    Wib.SetText_ByName(Driver, Password_ByName, NoUpperr_ByName);
                    Driver.Navigate().Back();
                    Wib.clickButton_Byid(Driver, CheckBox_ById);
                    var Actual = Driver.FindElement(By.Id(ContinueBtn_ById)).Enabled;
                    Assert.IsFalse(Actual);
                    Wib.clickButton_Byclass(Driver, Orders.MenuButton_ByClass);

                }
            }
        }
        public void InvalidPasswordNoLowerChar(AndroidDriver<AndroidElement> Driver)
        {
            var CheckCondition = Wib.getText_byID(Driver, NeedHelp_ById);
            Assert.AreEqual(NeedHelp_ByName, CheckCondition);
            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            foreach (var re in items)
            {
                if (AgeValid_ByName == re.Login)
                {
                    Wib.clickButton_Byid(Driver, CreateAccount_ById);
                    Wib.SetText_ByName(Driver, Email_ByName, re.Email);
                    Driver.Navigate().Back();
                    Wib.SetText_ByName(Driver, NewUsername_ByName, re.NewUserName);
                    Driver.Navigate().Back();
                    Wib.SetText_ByName(Driver, Password_ByName, NoLowerChar_ByName);
                    Driver.Navigate().Back();
                    Wib.clickButton_Byid(Driver, CheckBox_ById);
                    var Actual = Driver.FindElement(By.Id(ContinueBtn_ById)).Enabled;
                    Assert.IsFalse(Actual);
                    Wib.clickButton_Byclass(Driver, Orders.MenuButton_ByClass);

                }
            }
        }
        public void InvalidPasswordNoNumeric(AndroidDriver<AndroidElement> Driver)
        {
            var CheckCondition = Wib.getText_byID(Driver, NeedHelp_ById);
            Assert.AreEqual(NeedHelp_ByName, CheckCondition);
            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            foreach (var re in items)
            {
                if (AgeValid_ByName == re.Login)
                {
                    Wib.clickButton_Byid(Driver, CreateAccount_ById);
                    Wib.SetText_ByName(Driver, Email_ByName, re.Email);
                    Driver.Navigate().Back();
                    Wib.SetText_ByName(Driver, NewUsername_ByName, re.NewUserName);
                    Driver.Navigate().Back();
                    Wib.SetText_ByName(Driver, Password_ByName, NoNumeric_ByName);
                    Driver.Navigate().Back();
                    Wib.clickButton_Byid(Driver, CheckBox_ById);
                    var Actual = Driver.FindElement(By.Id(ContinueBtn_ById)).Enabled;
                    Assert.IsFalse(Actual);
                    Wib.clickButton_Byclass(Driver, Orders.MenuButton_ByClass);

                }
            }
        }
        public void OnesecurityAns(AndroidDriver<AndroidElement> Driver)
        {
            var CheckCondition = Wib.getText_byID(Driver, NeedHelp_ById);
            Assert.AreEqual(NeedHelp_ByName, CheckCondition);
            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            foreach (var re in items)
            {
                if (AgeValid_ByName == re.Login)
                {
                    Wib.clickButton_Byid(Driver, CreateAccount_ById);
                    Wib.SetText_ByName(Driver, Email_ByName, re.Email);
                    Driver.Navigate().Back();
                    Wib.SetText_ByName(Driver, NewUsername_ByName, re.NewUserName);
                    Driver.Navigate().Back();
                    Wib.SetText_ByName(Driver, Password_ByName, re.NewPassword);
                    Driver.Navigate().Back();
                    Wib.clickButton_Byid(Driver, CheckBox_ById);
                    Wib.clickButton_Byid(Driver, ContinueBtn_ById);
                    Wib.WaitForElementLoad_Byid(Driver, Securityone_ById, AndroStack.ImplicitTimeout);
                    Wib.SetTextAND_ById(Driver, Securityone_ById, Ans_byName, re.Ansone);
                    Driver.Navigate().Back();
                    var Actual = Driver.FindElement(By.Id(ContinueBtn_ById)).Enabled;
                    Assert.IsFalse(Actual);
                    Wib.clickButton_Byclass(Driver, Orders.MenuButton_ByClass);
                    Wib.WaitForElementLoad_ByName(Driver, SignUp_ByName, AndroStack.ImplicitTimeout);
                    Wib.clickButton_Byclass(Driver, Orders.MenuButton_ByClass);
                }
            }

        }
        public void twosecurityAns(AndroidDriver<AndroidElement> Driver)
        {
            var CheckCondition = Wib.getText_byID(Driver, NeedHelp_ById);
            Assert.AreEqual(NeedHelp_ByName, CheckCondition);
            var items = CSVReader.GetRecords<CSVLoginInput>("NewAccount.csv");
            foreach (var re in items)
            {
                if (AgeValid_ByName == re.Login)
                {
                    Wib.clickButton_Byid(Driver, CreateAccount_ById);
                    Wib.SetText_ByName(Driver, Email_ByName, re.Email);
                    Driver.Navigate().Back();
                    Wib.SetText_ByName(Driver, NewUsername_ByName, re.NewUserName);
                    Driver.Navigate().Back();
                    Wib.SetText_ByName(Driver, Password_ByName, re.NewPassword);
                    Driver.Navigate().Back();
                    Wib.clickButton_Byid(Driver, CheckBox_ById);
                    Wib.clickButton_Byid(Driver, ContinueBtn_ById);
                    Wib.WaitForElementLoad_Byid(Driver, Securityone_ById, AndroStack.ImplicitTimeout);
                    Wib.SetTextAND_ById(Driver, Securityone_ById, Ans_byName, re.Ansone);
                    Driver.Navigate().Back();
                    Wib.SetTextAND_ById(Driver, Securitytwo_ById, Ans_byName, re.Anstwo);
                    Driver.Navigate().Back();
                    var Actual = Driver.FindElement(By.Id(ContinueBtn_ById)).Enabled;
                    Assert.IsFalse(Actual);
                    Wib.clickButton_Byclass(Driver, Orders.MenuButton_ByClass);
                    Wib.clickButton_Byclass(Driver, Orders.MenuButton_ByClass);
                }
            }
        }
        public static void waitelement(IWebDriver Driver, string Locators)
        {
            try
            {
                Console.WriteLine("waiting for element");
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(Locators)));
                Console.WriteLine("system executed the script successful ");

            }
            catch (Exception e)
            {
                String sMessage = e.Message;
                throw new Exception(" Unable to execute - " + sMessage);
            }
        }

    }
}

