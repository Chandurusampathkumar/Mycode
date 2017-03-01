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
using System.Collections;

namespace Theranos.Automation.ME.Web.WebTestScripts.SignIn
{
    [TestClass]
    public class ForgetPassword : WebActionLib
    {
        // For TestCase TC=013
      
        WebActionLib help = new WebActionLib();

        public void forgetpassword()
        {
            help.clickElementByXpath(Ele_NeedHelp_ResetPassword_Xpath);
            help.sendTextByXpath(Ele_ResetPassword_Usernamefield_xpath, ReadExcel.NewUserName);
            waitForElement("xpath", Ele_ResetPassword_Submit_Xpath, 50);
            Thread.Sleep(5000);
            //help.WaitForElementByXpathToLoad(Ele_ResetPassword_Submit_Xpath, 50);
            help.clickElementByXpath(Ele_ResetPassword_Submit_Xpath);
            Get_Code.YopMailRestPasswordLink(ReadExcel.Email, TD_yopmail_Page_Url);
           
            Thread.Sleep(5000);
            string currentUrl = Driver.Url;
            Console.WriteLine("-----------" + currentUrl);
            List<String> tabs = new List<String>(Driver.WindowHandles);
            Console.WriteLine("total----" + tabs.Count);
            Driver.SwitchTo().Window(tabs[1]);
            string currentUrl2 = Driver.Url;
            Console.WriteLine("-----------" + currentUrl2);
           
            Thread.Sleep(5000);
           // waitForElement("xpath", Element_changePassword_Youranswerfield_Xpath, 50);
            help.clickElementByXpath(Element_changePassword_Youranswerfield_Xpath);
            help.sendTextByXpath(Element_changePassword_Youranswerfield_Xpath, ReadExcel.Question1);
            help.sendTextByXpath(Element_changePassword_newpasswordField_Xpath, TD_password_valid);
            help.clickElementByXpath(Element_changePassword_ContinueButton_Xpath);
            String validatedpage = help.getTextByXpath(Ele_Forgetpassword_msg_xpath);
            Console.WriteLine(validatedpage);
        }
        [TestMethod]
        public void forgetpassword_Scenario()
        {
           ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");

            Scenario_Functions.needHelp_Loginpage();
            forgetpassword();
            help.quitWebDriver();
        }

        /// <summary>
        /// Tc-97
        /// </summary>
        [TestMethod]
        public void ResetAPassword_ClickEmailLink()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.needHelp_Loginpage();

            help.clickElementByXpath(Ele_NeedHelp_ResetPassword_Xpath);
            help.sendTextByXpath(Ele_ResetPassword_Usernamefield_xpath, ReadExcel.NewUserName);
            waitForElement("xpath", Ele_ResetPassword_Submit_Xpath, 50);
            Thread.Sleep(5000);
            //help.WaitForElementByXpathToLoad(Ele_ResetPassword_Submit_Xpath, 50);
            help.clickElementByXpath(Ele_ResetPassword_Submit_Xpath);
            Get_Code.YopMailRestPasswordLink(ReadExcel.Email, TD_yopmail_Page_Url);

            help.quitWebDriver();
        }

        
        public void invaliddata_reset(String answer, String password)
        {
            help.clickElementByXpath(Ele_NeedHelp_ResetPassword_Xpath);
            help.sendTextByXpath(Ele_ResetPassword_Usernamefield_xpath, ReadExcel.NewUserName);
            waitForElement("xpath", Ele_ResetPassword_Submit_Xpath, 50);
            Thread.Sleep(5000);
            //help.WaitForElementByXpathToLoad(Ele_ResetPassword_Submit_Xpath, 50);
            help.clickElementByXpath(Ele_ResetPassword_Submit_Xpath);
            Get_Code.YopMailRestPasswordLink(ReadExcel.Email, TD_yopmail_Page_Url);

            Thread.Sleep(5000);
            string currentUrl = Driver.Url;
            Console.WriteLine("-----------" + currentUrl);
            List<String> tabs = new List<String>(Driver.WindowHandles);
            Console.WriteLine("total----" + tabs.Count);
            Driver.SwitchTo().Window(tabs[1]);
            string currentUrl2 = Driver.Url;
            Console.WriteLine("-----------" + currentUrl2);

            Thread.Sleep(5000);
            // waitForElement("xpath", Element_changePassword_Youranswerfield_Xpath, 50);
            help.clickElementByXpath(Element_changePassword_Youranswerfield_Xpath);
            help.sendTextByXpath(Element_changePassword_Youranswerfield_Xpath, answer);
            help.sendTextByXpath(Element_changePassword_newpasswordField_Xpath, password);
            help.clickElementByXpath(Element_changePassword_ContinueButton_Xpath);
            Thread.Sleep(6000);
            String validatedpage = help.getTextByXpath(Ele_Restlink_Wrongdata_errormsg_xpath);
            Console.WriteLine("errormsg---------"+validatedpage);
        }


        /// <summary>
        /// Tc-91
        /// </summary>
        [TestMethod]
        public void invalid_restlinkactivation()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");

            Scenario_Functions.needHelp_Loginpage();
            invaliddata_reset(TD_invalidAnswer, TD_InvalidPassword2);
           // help.quitWebDriver();
        }
        /// <summary>
        /// 96
        /// </summary>
        [TestMethod]
        public void invalid_Ans_restlinkactivation()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");

            Scenario_Functions.needHelp_Loginpage();
            invaliddata_reset(TD_invalidAnswer, TD_Validusername);
            // help.quitWebDriver();
        }

        /// <summary>
        /// TC-74
        /// </summary>
        [TestMethod]
        public void Loginwith_verificationcode()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");

            Scenario_Functions.needHelp_Loginpage();
            invaliddata_reset(TD_invalidAnswer, TD_Validusername);
            help.quitWebDriver();
        }
    }
}
