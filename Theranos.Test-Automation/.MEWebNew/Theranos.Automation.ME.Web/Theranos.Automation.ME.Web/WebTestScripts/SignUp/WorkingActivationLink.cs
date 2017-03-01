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
using OpenQA.Selenium.Interactions;
using Theranos.Automation.ME.Web.ExcelReader;
using Theranos.Automation.ME.Web.WebTestScripts.FileReader;

namespace Theranos.Automation.ME.Web.WebTestScripts.SignUp
{
   
    [TestClass]
    public class WorkingActivationLink : WebActionLib
    {

        WebActionLib Wl = new WebActionLib();
        Get_Code cd = new Get_Code();
        public void activationLink()
        {

            Wl.launchBrowserWithUrl("Firefox", TD_SignIn_Page_Url);
            Wl.maximizeWindow();
            Thread.Sleep(4000);

            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            waitForElement("xpath", Ele_SignIn_SignUpLink_ByXpath, 50);
            Wl.clickElementByXpath(Ele_SignIn_SignUpLink_ByXpath);  // Click signup link on login page

            ///Thread.Sleep(2000);
            waitForElement("name", Ele_SignUp_Email_ByName, 50);
            Wl.sendTextByName(Ele_SignUp_Email_ByName, ReadExcel.Email);   // set Email id
            Wl.clickTab();
            //Thread.Sleep(2000);
            waitForElement("name", Ele_Signup_UserName_ByName, 50);
            Wl.sendTextByName(Ele_Signup_UserName_ByName, ReadExcel.NewUserName);  //Set username
            Wl.clickTab();
            ///Thread.Sleep(4000);
            waitForElement("xpath", Ele_SignUp_PasswordField_ByXpath, 50);
            Wl.sendTextByXpath(Ele_SignUp_PasswordField_ByXpath, TD_password_valid);  //set password
            Wl.clickTab();

            Wl.sendTextByName(Ele_Signup_ques1_ByName, ReadExcel.Question1);
            Wl.clickTab();

            Wl.sendTextByName(Ele_Signup_ques2_BYName, ReadExcel.Question1);
            Wl.clickTab();

            Wl.sendTextByName(Ele_Signup_ques3_ByName, ReadExcel.Question3);
            Wl.clickTab();
            Thread.Sleep(5000);
            ///   waitForElement("name", Ele_Signup_Atleat13_Name, 50);
            Wl.clickElementById(Ele_Signup_Atleat13_ID);
            Wl.clickTab();

            Thread.Sleep(3000);
            // waitForElement("xpath", Ele_SignUp_CreateAccount_ByXpath, 50);
            Wl.clickElementByXpath(Ele_SignUp_CreateAccount_ByXpath);      // click on create account

        }
        // Check email(In new tab) for activation in mail
        public void activateaccount()
        {
            cd.YopMailsendemailcaptcha(TD_yopmail_Page_Url, ReadExcel.Email);
            Thread.Sleep(1000);
            Wl.switchToOtherTab();
            Wl.switchToOtherTab();
            Wl.closeCurrentTab();
            ///Thread.Sleep(5000);
            waitForElement("xpath", Ele_ActivatedPage_SuccessMessage_ByXpath, 50);
            string successmessage = Wl.getTextByXpath(Ele_ActivatedPage_SuccessMessage_ByXpath);
            Console.WriteLine(" Message displayed is : " + successmessage);
            string assertMessage = " Activation message display is Not as expected ";
            Assert.IsTrue(successmessage == TD_Activation_SuccessMessage, assertMessage);
        }
        /// <summary>
        ///  TC - 062
        /// </summary>
        [TestMethod]
        public void activationLink_Scenario()
        {
                ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, true, "new");
                activationLink();
                activateaccount();
          //      Wl.quitWebDriver();
          
        }

        public void deselectatleastcheckbox()
        {

            Wl.launchBrowserWithUrl("Firefox", TD_SignIn_Page_Url);
            Wl.maximizeWindow();
            Thread.Sleep(4000);

            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            waitForElement("xpath", Ele_SignIn_SignUpLink_ByXpath, 50);
            Wl.clickElementByXpath(Ele_SignIn_SignUpLink_ByXpath);  // Click signup link on login page

            ///Thread.Sleep(2000);
            waitForElement("name", Ele_SignUp_Email_ByName, 50);
            Wl.sendTextByName(Ele_SignUp_Email_ByName, ReadExcel.Email);   // set Email id
            Wl.clickTab();
            //Thread.Sleep(2000);
            waitForElement("name", Ele_Signup_UserName_ByName, 50);
            Wl.sendTextByName(Ele_Signup_UserName_ByName, ReadExcel.NewUserName);  //Set username
            Wl.clickTab();
            ///Thread.Sleep(4000);
            waitForElement("xpath", Ele_SignUp_PasswordField_ByXpath, 50);
            Wl.sendTextByXpath(Ele_SignUp_PasswordField_ByXpath, TD_password_valid);  //set password
            Wl.clickTab();

            Wl.sendTextByName(Ele_Signup_ques1_ByName, ReadExcel.Question1);
            Wl.clickTab();

            Wl.sendTextByName(Ele_Signup_ques2_BYName, ReadExcel.Question1);
            Wl.clickTab();

            Wl.sendTextByName(Ele_Signup_ques3_ByName, ReadExcel.Question3);
            Wl.clickTab();
            Thread.Sleep(5000);
            
            Wl.clickElementByXpath(Ele_SignUp_CreateAccount_ByXpath);
            String errortext = Wl.getTextByXpath(Ele_errormessage_required_xpath);
          //  Console.WriteLine("ooooooo==" + errortext);

        }
        /// <summary>
        /// Tc- 80
        /// </summary>
        [TestMethod]
        public void checkbox_minimumage()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 3, true, "new");
            deselectatleastcheckbox();
            Wl.quitWebDriver();
        }

        /// <summary>
        /// TC-90
        /// </summary>
        [TestMethod]
        public void Signup_Withoutactivation()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 3, true, "new");
            activationLink();
            Wl.quitWebDriver();
        }

        /// <summary>
        /// TC-92
        /// </summary>
        [TestMethod]
        public void lounch_application()
        {
            Wl.launchBrowserWithUrl("Firefox", TD_SignIn_Page_Url);
            Wl.maximizeWindow();
            Thread.Sleep(4000);
            Wl.quitWebDriver();
        }

        /// <summary>
        /// TC-93
        /// </summary>
        [TestMethod]
        public void LoginFrom_newAccount()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 2, false, "Old");
            Scenario_Functions.signin_forUnlinked();
            Wl.quitWebDriver();
        }

        /// <summary>
        /// TC-95
        /// </summary>
        [TestMethod]
        public void LoginWith_Activationcode()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            Wl.quitWebDriver();
        }
    }
}
