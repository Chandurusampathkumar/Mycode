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

namespace Theranos.Automation.ME.Web.WebTestScripts.SignUp
{
                        // TC - 063
    [TestClass]
    public class ExistedUsername:WebActionLib
    {
       WebActionLib we = new WebActionLib();   
        public void existedUsername()
        {
           

            we.launchBrowserWithUrl("Firefox", TD_SignIn_Page_Url);
            we.maximizeWindow();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            we.WaitForElementByXpathTo_Clickable(Ele_SignIn_SignUpLink_ByXpath, 20);
            we.clickElementByXpath(Ele_SignIn_SignUpLink_ByXpath);
            we.waitForElementByNameTo_Clickable(Ele_Signup_UserName_ByName,20);

            we.sendTextByName(Ele_SignUp_Email_ByName, ReadExcel.Email);
            we.sendTextByName(Ele_Signup_UserName_ByName, ReadExcel.NewUserName);  // Submit existed username
            we.sendTextByXpath(Ele_SignUp_PasswordField_ByXpath, TD_password_valid);
            waitForElement("xpath", Ele_SignUp_ExistedUser_Error_ByXpPath, 50);
            ///Thread.Sleep(4000);
            we.WaitForElementByXpathTo_Clickable(Ele_SignUp_ExistedUser_Error_ByXpPath, 20);
            string Error = we.getTextByXpath(Ele_SignUp_ExistedUser_Error_ByXpPath);   // Capture error message displayed
            Console.WriteLine("Errormessage=======" + Error);
        }
        [TestMethod]
        public void existedUsername_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            existedUsername();
            we.quitWebDriver();
        }
    }
}
