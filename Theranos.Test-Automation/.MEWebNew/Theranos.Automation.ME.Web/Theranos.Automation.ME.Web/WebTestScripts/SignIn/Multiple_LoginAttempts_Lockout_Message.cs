using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;

namespace Theranos.Automation.ME.Web.WebTestScripts.SignIn
{
    // TC-025
    [TestClass]
    public class Multiple_LoginAttempts_Lockout_Message : WebActionLib
    {
        WebActionLib ct = new WebActionLib();
        String errorMsg;
       
        public void MultipleLoginAttemptsLockedOutMessage()
        {
            ct.waitForElementByNameTo_Clickable(Ele_SignIn_UsernameFileld_Name, 20);
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            for (int i = 1; i < 6; i++)
            {
                ct.sendTextByName(Ele_SignIn_UsernameFileld_Name, TD_Validusername);
                ct.sendTextByName(Ele_SignIn_PasswordField_Name, TD_InvalidPassword);
                ct.clickElementByXpath(Ele_SignIn_SignIn_ByXpath);
                //Thread.Sleep(2000);
                waitForElement("xpath", Ele_SignIn_InvalidCredentials_ErrorCard_Xpath, 50);
                errorMsg = ct.getTextByXpath(Ele_SignIn_InvalidCredentials_ErrorCard_Xpath);
                Console.WriteLine("Attempt Number : " + i + " Error message is : " + errorMsg);
                System.Diagnostics.Debug.WriteLine("Attempt Number : " + i + " Error message is : " + errorMsg);
                Thread.Sleep(2000);
            }

            string assertMessage = (" Alert displayed was not as expected ");
            Assert.IsTrue(errorMsg == TD_SignIn_AccountLocked_OfterFinalAttempt, assertMessage);
        }
        [TestMethod]
        public void MultipleLoginAttemptsLockedOutMessage_Scenario()
        {
            ct.launchBrowserWithUrl("Firefox", TD_SignIn_Page_Url);
            MultipleLoginAttemptsLockedOutMessage();
            ct.quitWebDriver();
        }
    }
}
