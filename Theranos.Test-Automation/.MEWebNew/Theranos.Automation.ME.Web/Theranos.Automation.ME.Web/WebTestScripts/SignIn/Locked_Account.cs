using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;
using Theranos.Automation.ME.Web.Web;
using Theranos.Automation.ME.Web.WebTestScripts.FileReader;
using Theranos.Automation.ME.Web.ExcelReader;

namespace Theranos.Automation.ME.Web.WebTestScripts.SignIn    


{
    // TC-026
    [TestClass]
    public class Locked_Account : WebActionLib
    {
        WebActionLib on = new WebActionLib();
        string errorMsg;
     
        public void lockedAccount()
        {
            Thread.Sleep(5000);
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            // Lockout an Username
            for (int i = 1; i < 8; i++)
            {
                on.sendTextByName(Ele_SignIn_UsernameFileld_Name, TD_Validusername);
                on.sendTextByName(Ele_SignIn_PasswordField_Name, TD_InvalidPassword);
                on.clickElementByXpath(Ele_SignIn_SignIn_ByXpath);
                Thread.Sleep(2000);
                //  errorMsg =on.getTextByXpath(Ele_SignIn_InvalidCredentials_ErrorCard_Xpath);
                //  Console.WriteLine("Attempt Number : " +i+ " Error message is : " +errorMsg);
                //  System.Diagnostics.Debug.WriteLine("Attempt Number : " + i + " Error message is : " + errorMsg);
            }

            // Verify login with locked account
            on.waitForElementByNameTo_Clickable(Ele_SignIn_UsernameFileld_Name, 20);
            on.sendTextByName(Ele_SignIn_UsernameFileld_Name, TD_Validusername);
            on.sendTextByName(Ele_SignIn_PasswordField_Name, TD_password_valid); // Submit valid Password
            on.clickElementByXpath(Ele_SignIn_SignIn_ByXpath);
            on.WaitForElementByXpathTo_Clickable(Ele_SignIn_InvalidCredentials_ErrorCard_Xpath, 20);
            errorMsg = on.getTextByXpath(Ele_SignIn_InvalidCredentials_ErrorCard_Xpath);
            Console.WriteLine(" Message displayed is " + errorMsg);
            System.Diagnostics.Debug.WriteLine(" Message displayed is " + errorMsg);
            string assertMessage = (" Message displayed was not as expected ");
            Assert.IsTrue(errorMsg == TD_SignIn_AccountLocked_OfterFinalAttempt, assertMessage);

        }
        [TestMethod]
        public void lockedAccount_Scenario()
        {
            on.launchBrowserWithUrl("Firefox", TD_SignIn_Page_Url);
            lockedAccount();
            on.quitWebDriver();
        }
    }
}
