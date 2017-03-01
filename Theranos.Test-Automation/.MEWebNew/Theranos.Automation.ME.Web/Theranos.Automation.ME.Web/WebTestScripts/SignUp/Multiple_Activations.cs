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
using Theranos.Automation.ME.Web.WebTestScripts.FileReader;
using Theranos.Automation.ME.Web.ExcelReader;

namespace Theranos.Automation.ME.Web.WebTestScripts.SignUp
{
                    // TC - 023
    [TestClass]
    public class Multiple_Activations:WebActionLib
    {
        WebActionLib Wl = new WebActionLib();

        public void multipleActivations()
        {
           
            Wl.launchBrowserWithUrl("Firefox", TD_SignIn_Page_Url);
            Wl.maximizeWindow();
            //Thread.Sleep(4000);

            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            waitForElement("xapth", Ele_SignIn_SignUpLink_ByXpath, 50);
            Wl.clickElementByXpath(Ele_SignIn_SignUpLink_ByXpath);  // Click signup link on login page

            ///Thread.Sleep(2000);
            waitForElement("name", Ele_SignUp_Email_ByName, 50);
            Wl.sendTextByName(Ele_SignUp_Email_ByName, ReadExcel.Email);   // set Email id
            Wl.clickTab();
            ///Thread.Sleep(2000);
            waitForElement("name", Ele_Signup_UserName_ByName, 50);
            Wl.sendTextByName(Ele_Signup_UserName_ByName, ReadExcel.NewUserName);  //Set username
            Wl.clickTab();
            ///Thread.Sleep(4000);
            waitForElement("xpath", Ele_SignUp_PasswordField_ByXpath, 50);
            Wl.sendTextByXpath(Ele_SignUp_PasswordField_ByXpath, TD_password_valid);  //set password
            Wl.clickTab();

            Wl.sendTextByName(Ele_Signup_ques1_ByName, ReadExcel.Question1);
            Wl.clickTab();

            Wl.sendTextByName(Ele_Signup_ques2_BYName, ReadExcel.Question2);
            Wl.clickTab();

            Wl.sendTextByName(Ele_Signup_ques3_ByName, ReadExcel.Question3);
            Wl.clickTab();
            //Thread.Sleep(5000);
            waitForElement("id", Ele_Signup_Atleat13_ID, 50);
            Wl.clickElementById(Ele_Signup_Atleat13_ID);
            Wl.clickTab();

            //Thread.Sleep(3000);
            waitForElement("xpath", Ele_SignUp_CreateAccount_ByXpath, 50);
            Wl.clickElementByXpath(Ele_SignUp_CreateAccount_ByXpath);      // click on create account

            System.Diagnostics.Debug.WriteLine(" User name used is : " + ReadExcel.NewUserName);
            Console.WriteLine(" User name used is : " + ReadExcel.NewUserName);
            System.Diagnostics.Debug.WriteLine(" Password used is : " + TD_password_valid);
            Console.WriteLine(" Password used is : " + TD_password_valid);
            System.Diagnostics.Debug.WriteLine(" Email id Used is : " + ReadExcel.Email);
            Console.WriteLine(" Email id Used is : " + ReadExcel.Email);

            // Check email(In new tab) for activation in mail


            Wl.switchToNewTab();
            Wl.passUrlToAddressBar(TD_yopmail_Page_Url);
            ///Thread.Sleep(5000);
            waitForElement("id", Ele_Yop_MailField_Id, 50);
            Wl.sendTextById(Ele_Yop_MailField_Id, ReadExcel.Email); // Submit email Id
            Wl.clickElementByClassName(Ele_Yop_CheckInbox_Class);        // click on Check Inbox
            ///Thread.Sleep(4000);
            waitForElement("id", Ele_Yop_MailBodyFreame_Id, 50);
            Wl.switchToFrameByElement(Driver.FindElement(By.Id(Ele_Yop_MailBodyFreame_Id)));

            // Account activation
            for (int i = 0; i < 5; i++ )
            {
                Wl.controlClickByXpath(Ele_Yop_ClickActivate_Xpath);  // Click on activation Link.Link opens in new tab
                Thread.Sleep(1000);
                Wl.switchToOtherTab();
                Wl.switchToOtherTab();
            }                 
        }
        [TestMethod]
        public void multipleActivations_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 3, true, "new");
            multipleActivations();
            Wl.quitWebDriver();
        }
    }
}
