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

    // TC-061
    [TestClass]
    public class SignUp : WebActionLib
    {


        WebActionLib Lib = new WebActionLib();

        public void signUp()
        {
            Lib.launchBrowserWithUrl("Firefox", TD_SignIn_Page_Url);
            Lib.maximizeWindow();
            Thread.Sleep(4000);

            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            waitForElement("xpath", Ele_SignIn_SignUpLink_ByXpath, 50);
            Lib.clickElementByXpath(Ele_SignIn_SignUpLink_ByXpath);  // Click signup link on login page

            Thread.Sleep(2000);
            /// waitForElement("name", Ele_SignUp_Email_ByName, 50);
            Lib.sendTextByName(Ele_SignUp_Email_ByName, ReadExcel.Email);   // set Email id
            Lib.clickTab();
            Thread.Sleep(2000);
            /// waitForElement("name", Ele_Signup_UserName_ByName, 50);
            Lib.sendTextByName(Ele_Signup_UserName_ByName, ReadExcel.NewUserName);  //Set username
            Lib.clickTab();
            Thread.Sleep(4000);
            //waitForElement("xpath", Ele_SignUp_PasswordField_ByXpath, 50);
            Lib.sendTextByXpath(Ele_SignUp_PasswordField_ByXpath, TD_password_valid);  //set password
            Lib.clickTab();

            Lib.sendTextByName(Ele_Signup_ques1_ByName, ReadExcel.Question1);
            Lib.clickTab();

            Lib.sendTextByName(Ele_Signup_ques2_BYName, ReadExcel.Question2);
            Lib.clickTab();

            Lib.sendTextByName(Ele_Signup_ques3_ByName, ReadExcel.Question3);
            Lib.clickTab();
            Thread.Sleep(5000);
            /// waitForElement("name", Ele_Signup_Atleat13_Name, 50);
            Lib.clickElementById(Ele_Signup_Atleat13_ID);
            Lib.clickTab();

            Thread.Sleep(3000);
            /// waitForElement("xpath", Ele_SignUp_CreateAccount_ByXpath, 50);
            Lib.clickElementByXpath(Ele_SignUp_CreateAccount_ByXpath);      // click on create account

            Lib.switchToNewTab();
            Lib.passUrlToAddressBar(TD_yopmail_Page_Url);
            Thread.Sleep(5000);
            //   waitForElement("id", Ele_Yop_MailField_Id, 50);
            Lib.sendTextById(Ele_Yop_MailField_Id, ReadExcel.Email); // Submit email Id
            Lib.clickElementByClassName(Ele_Yop_CheckInbox_Class);        // click on Check Inbox
            Thread.Sleep(4000);
            //  waitForElement("id", Ele_Yop_MailBodyFreame_Id, 50);
            Lib.switchToFrameByElement(Driver.FindElement(By.Id(Ele_Yop_MailBodyFreame_Id)));

            // Account activation
            //  waitForElement("xpath", Ele_Yop_ClickActivate_Xpath, 50);
            Lib.controlClickByXpath(Ele_Yop_ClickActivate_Xpath);  // Click on activation Link.Link opens in new tab
            Thread.Sleep(3000);
        }
        [TestMethod]
        public void signUp_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, true, "new");
            signUp();
            Lib.quitWebDriver();
        }

    }
}
