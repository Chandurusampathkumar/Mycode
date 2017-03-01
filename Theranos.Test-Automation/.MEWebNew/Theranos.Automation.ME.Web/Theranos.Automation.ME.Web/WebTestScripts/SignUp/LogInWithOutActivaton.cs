using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;

using Theranos.Automation.ME.Web.WebTestScripts.FileReader;
using Theranos.Automation.ME.Web.ExcelReader;

namespace Theranos.Automation.ME.Web.WebTestScripts.SignUp
{
    // TC - 021
    [TestClass]
    public class LogInWithOutActivaton : WebActionLib
    {
        WebActionLib Wa = new WebActionLib();

        public void loginWithoutActivation()
        {


            Wa.launchBrowserWithUrl("Firefox", TD_SignIn_Page_Url);
            Wa.maximizeWindow();
            Thread.Sleep(4000);
            ///  waitForElement("xpath", Ele_SignIn_SignUpLink_ByXpath, 50);

            Wa.clickElementByXpath(Ele_SignIn_SignUpLink_ByXpath);  // Click signup link on login page

            Thread.Sleep(2000);
            ///  waitForElement("name", Ele_SignUp_Email_ByName, 50);

            Wa.sendTextByName(Ele_SignUp_Email_ByName, ReadExcel.Email);   // set Email id
            Wa.clickTab();
            // waitForElement("name", Ele_Signup_UserName_ByName, 50);
            Thread.Sleep(2000);

            Wa.sendTextByName(Ele_Signup_UserName_ByName, ReadExcel.NewUserName);  //Set username
            Wa.clickTab();
            Thread.Sleep(4000);
            ///  waitForElement("xpath", Ele_SignUp_PasswordField_ByXpath, 50);
            Wa.sendTextByXpath(Ele_SignUp_PasswordField_ByXpath, TD_password_valid);  //set password
            Wa.clickTab();

            Wa.sendTextByName(Ele_Signup_ques1_ByName, ReadExcel.Question1);
            Wa.clickTab();

            Wa.sendTextByName(Ele_Signup_ques2_BYName, ReadExcel.Question2);
            Wa.clickTab();

            Wa.sendTextByName(Ele_Signup_ques3_ByName, ReadExcel.Question3);
            Wa.clickTab();
            //waitForElement("name", Ele_Signup_Atleat13_Name, 50);
            Thread.Sleep(5000);

            Wa.clickElementById(Ele_Signup_Atleat13_ID);
            Wa.clickTab();

            Thread.Sleep(3000);
            /// waitForElement("xapth", Ele_SignUp_CreateAccount_ByXpath, 50);
            Wa.clickElementByXpath(Ele_SignUp_CreateAccount_ByXpath);      // click on create account

            System.Diagnostics.Debug.WriteLine(" User name used is : " + ReadExcel.NewUserName);
            Console.WriteLine(" User name used is : " + ReadExcel.NewUserName);
            System.Diagnostics.Debug.WriteLine(" Password used is : " + TD_password_valid);
            Console.WriteLine(" Password used is : " + TD_password_valid);
            System.Diagnostics.Debug.WriteLine(" Email id Used is : " + ReadExcel.Email);
            Console.WriteLine(" Email id Used is : " + ReadExcel.Email);

            // Login without activation

            Wa.clickElementByXpath(Ele_ActivatedPage_Login_ByXpath);  // Click on login which open new page with requird fields
            Wa.sendTextByName("username", ReadExcel.NewUserName);    // Send username
            Wa.sendTextByName("password", TD_password_valid);        //send password

            string url_BeforeClickonLogin = Wa.getCurrentPageUrl();  // get page url
            Console.WriteLine(" Url Before SignIn : " + url_BeforeClickonLogin);
            Wa.clickElementByXpath(Ele_SignIn_SignIn_ByXpath);     // click on sign in  

            Thread.Sleep(3000);
            string url_OfterClickOnLogin = Wa.getCurrentPageUrl();
            Console.WriteLine(" Url ofter SignIn : " + url_OfterClickOnLogin);
            Thread.Sleep(1000);
            //waitForElement("xapth", Ele_SignIn_NotActivated_ErrorCard_Xpath, 50);
            string error_Message = Wa.getTextByXpath(Ele_SignIn_NotActivated_ErrorCard_Xpath); //get error message displayed

            string assertMessage = "Not as expected";
            Assert.IsTrue(url_BeforeClickonLogin == url_OfterClickOnLogin, assertMessage); // verifying

            Console.WriteLine("Page didn't moved to dash board");
            Console.WriteLine(" Page is showing following expected error : " + error_Message);

            // Quit all webDriver sessions
            Wa.quitWebDriver();
        }
        [TestMethod]
        public void loginWithoutActivations_scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 3, true, "new");
            loginWithoutActivation();
            Wa.quitWebDriver();
        }
    }
}
