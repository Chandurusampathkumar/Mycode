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
using Theranos.Automation.ME.Web.ExcelReader;

namespace Theranos.Automation.ME.Web.WebTestScripts.SignIn
{
     // TC - 022
    [TestClass]
    public class SignIn_With_Invalid_UserName:WebActionLib
    {
        WebActionLib eb = new WebActionLib();

        public  void signInWithInvalidUsername()
        {
            
            eb.WaitForElementByXpathTo_Clickable(Ele_SignIn_InvalidUsername_ErrorCard_Xpath,20);
            string ErrorMessage = eb.getTextByXpath(Ele_SignIn_InvalidUsername_ErrorCard_Xpath);
            Console.WriteLine(" Alert message displayed is : " + ErrorMessage);
            string assertMessage = (" Alert displayed was not as expected ");
           // Assert.IsTrue(ErrorMessage == TD_InvalidUsername_ErrorMessage, assertMessage);
           
        }

        public void signin_forLinkedaccount()
        {
           /// ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, true, "");

            WebActionLib unlink = new WebActionLib();
            unlink.launchBrowserWithUrl("Firefox", TD_SignIn_Page_Url);
            unlink.maximizeWindow();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            unlink.sendTextByName(Ele_SignIn_UsernameFileld_Name, ReadExcel.NewUserName);
            unlink.sendTextByName(Ele_SignIn_PasswordField_Name, TD_password_valid);
            unlink.clickElementByXpath(Ele_SignIn_SignIn_ByXpath);

        }
        [TestMethod]
        public void signInWithInvalidUsername_scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 3, true, "new");
            signin_forLinkedaccount();
            signInWithInvalidUsername();
            eb.quitWebDriver();
        }


        public static void signInWithVerification()
        {
            /// ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");

            WebActionLib sg = new WebActionLib();
            sg.launchBrowserWithUrl("Firefox", TD_SignIn_Page_Url);
            sg.maximizeWindow();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            sg.sendTextByName(Ele_SignIn_UsernameFileld_Name, ReadExcel.NewUserName); ///ReadExcel.NewUserName
            sg.sendTextByName(Ele_SignIn_PasswordField_Name, TD_password_valid);
            sg.clickElementByXpath(Ele_SignIn_SignIn_ByXpath);

            string verificationcode = Get_Code.getVerificationCode(ReadExcel.Email, TD_yopmail_Page_Url);
            System.Diagnostics.Debug.WriteLine(verificationcode);
            sg.sendTextByXpath(Ele_SignIn_TwoStepAuthField_Xpath, verificationcode);  // Pass activation code to the field

            sg.clickElementByXpath(Ele_trustmebrowsercheckbox_xpath);
            sg.clickElementByXpath(Ele_SignIn_TwoStepAuth_Done_Xpath);    // Click on done

        }
        /// <summary>
        /// TC-75
        /// </summary>
        [TestMethod]
        public void trustmebrowser_withCheckbox()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "Oldlinked");
            signInWithVerification();
        //    Thread.Sleep(5000);
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
            eb.clickElementByClassName(Ele_Dashboard_ProfileIcon_Classname);
            eb.clickElementByLinkText(Ele_Dashboard_Logout_linktext);
            eb.quitWebDriver();
        }

        /// <summary>
        /// TC-76
        /// </summary>
        [TestMethod]
        public void trustmebrowser_withoutcheckbox()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "Oldlinked");
            Scenario_Functions.signInWithVerification();
            Thread.Sleep(5000);
            eb.clickElementByClassName(Ele_Dashboard_ProfileIcon_Classname);
            eb.clickElementByLinkText(Ele_Dashboard_Logout_linktext);
            eb.quitWebDriver();
        }
    }
}
