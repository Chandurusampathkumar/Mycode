using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;

using Theranos.Automation.ME.Web.ExcelReader;
namespace Theranos.Automation.ME.Web.WebTestScripts.SignIn
{
    // TC - 024
    [TestClass]
    public class Multiple_Login_Attempts_Warning_Message : WebActionLib
    {
        WebActionLib ti = new WebActionLib();
        String errorMsg;

        public void multipleLoginAttemptsWarningMessage()
        {
           ti.waitForElementByNameTo_Clickable(Ele_SignIn_UsernameFileld_Name, 20);
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            for (int i = 0; i < 3; i++)
            {
                ti.sendTextByName(Ele_SignIn_UsernameFileld_Name, TD_Validusername);
                ti.sendTextByName(Ele_SignIn_PasswordField_Name, TD_InvalidPassword);
                ti.clickElementByXpath(Ele_SignIn_SignIn_ByXpath);
               // Thread.Sleep(2000);
                waitForElement("xpath", Ele_SignIn_InvalidCredentials_ErrorCard_Xpath, 50);
                errorMsg = ti.getTextByXpath(Ele_SignIn_InvalidCredentials_ErrorCard_Xpath);
                Console.WriteLine("Attempt Number : " + i + " Error message is : " + errorMsg);
                System.Diagnostics.Debug.WriteLine("Attempt Number : " + i + " Error message is : " + errorMsg);

            }
            string assertMessage = (" Alert displayed was not as expected ");
           /// Assert.IsTrue(errorMsg == TD_SignIn_AccountLockAlert_BeforeFinalAttempt, assertMessage);
        }
        [TestMethod]
        public void multipleLoginAttemptsWarningMessage_Scenario()
        {
            ti.launchBrowserWithUrl("Firefox", TD_SignIn_Page_Url);
            multipleLoginAttemptsWarningMessage();
            ti.quitWebDriver();
        }
    }
}
