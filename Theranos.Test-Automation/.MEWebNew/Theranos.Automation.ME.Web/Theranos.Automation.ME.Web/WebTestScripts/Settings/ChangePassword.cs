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
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Theranos.Automation.ME.Web.WebTestScripts.Settings
{

    [TestClass]
    public class ChangePassword : WebActionLib
    {
        
        WebActionLib ch = new WebActionLib();

         public void changepassword()
        {
            ch.clickElementByJavaScriptXpath(Ele_SettingsChangePassword_Editbtn_xpath);
            ch.sendTextByName(Ele_changePassword_currentpassword_Name, TD_password_valid);
            ch.sendTextByName(Ele_SettingsChangePassword_NewPassword_Name, TD_password_valid);
            ch.clickElementByXpath(Ele_SettingsChangePassword_Savebtn_xpath);
        }
       
        public void changepassword_minEightchar()
        {
            ch.clickElementByJavaScriptXpath(Ele_SettingsChangePassword_Editbtn_xpath);
            ch.sendTextByName(Ele_changePassword_currentpassword_Name, TD_password_valid);
            ch.sendTextByName(Ele_SettingsChangePassword_NewPassword_Name, TD_InvalidPassword);
            Thread.Sleep(6000);
            ch.clickElementByXpath(Ele_Changepassword_minEightchar_Xpath);
            Thread.Sleep(10000);
            String errormsg = ch.getTextByXpath(Ele_Changepassword_minEightchar_Xpath);
            Console.WriteLine("ErrorMsgis=="+ch);
            //Minimum 8 characters
        }

        public void changepassword_hiddenpassword()
        {  
            ch.clickElementByJavaScriptXpath(Ele_SettingsChangePassword_Editbtn_xpath);
            ch.sendTextByName(Ele_changePassword_currentpassword_Name, TD_password_valid);
            ch.sendTextByName(Ele_SettingsChangePassword_NewPassword_Name, TD_password_valid);
            ch.clickElementByXpath(Ele_SettingsNewpassword_Hiddeneyeicon_xpath);
            IWebElement ele = Driver.FindElement(By.Name(Ele_SettingsChangePassword_NewPassword_Name));
            string hidden = ele.GetAttribute("value");        
            Assert.AreEqual(TD_password_valid, hidden);
            ch.clickElementByXpath(Ele_SettingsChangePassword_Savebtn_xpath);
        
        }
        public void edidprofile_password()
        {
            ch.clickElementByClassName(Ele_Dashboard_ProfileIcon_Classname);
            ch.clickElementByLinkText(Ele_Dashboard_Settings_Linktext);
        
        }

        /// <summary>
        /// Tc-001
        /// </summary>
        [TestMethod]
        public void changepassword_displayusername_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            Thread.Sleep(16000);
            edidprofile_password();
            String lable = ch.getTextByXpath(Ele_Settingpage_usernamedisplay_xpath);
            Assert.AreEqual(ReadExcel.NewUserName, lable);
            ch.quitWebDriver();
        }

        /// <summary>
        /// Tc-002
        /// </summary>
        [TestMethod]
        public void changepassword_usernameedit_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            Thread.Sleep(16000);
            edidprofile_password();
            ch.clickbuttonbyxpath(Ele_Settingpage_usernamedisplay_xpath);
            ch.quitWebDriver();
        }

        /// <summary>
        /// Tc-03
        /// </summary>
        [TestMethod]
        public void changepassword_hiddenpassword_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            Thread.Sleep(16000);
            edidprofile_password();

            changepassword_hiddenpassword();
            ch.quitWebDriver();
        }

        /// <summary>
        /// TC-004
        /// </summary>
         [TestMethod]
        public void changepassword_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
           
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(150));
            Thread.Sleep(16000);
            edidprofile_password();
            changepassword();
             ch.quitWebDriver();
        }
         /// <summary>
         ///  TC-005
         /// </summary>

         [TestMethod]
         public void changepassword_minEightchar_Scenario()
         {
             ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
             Scenario_Functions.signInWithVerification();
             Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(150));
             Thread.Sleep(16000);
             edidprofile_password();

             changepassword_minEightchar();
             ch.quitWebDriver();
         }

        

    }
}
