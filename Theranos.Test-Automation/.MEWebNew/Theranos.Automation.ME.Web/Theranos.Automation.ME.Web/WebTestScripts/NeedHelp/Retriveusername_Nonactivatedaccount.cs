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
using Theranos.Automation.ME.Web.WebTestScripts.SignUp;
namespace Theranos.Automation.ME.Web.WebTestScripts.NeedHelp
{
    [TestClass]
   public class Retriveusername_Nonactivatedaccount :WebActionLib
    {
        
        WebActionLib help = new WebActionLib();
        WorkingActivationLink activate = new WorkingActivationLink();
       //TC-29
        [TestMethod]
        public void retriveusername_nonactivatedmailaccount_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 3, false, "Old");
           
            Scenario_Functions.needHelpToRetriveUsername_notification(ReadExcel.Email);
            string notification = help.getTextByXpath(Ele_RetriveUserName_NonActivatedMailId_xpath);
            string assertMessage = ("We've sent an email to " + ReadExcel.Email + " with your username.");
           // Assert.IsTrue(notification.Equals(assertMessage));
            help.quitWebDriver();
        }
        //TC-31
        [TestMethod]
        public void retriveusername_activatedmailaccount_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 2, false, "Old");
            Scenario_Functions.needHelpToRetriveUsername_notification(ReadExcel.Email);
            string notification = help.getTextByXpath(Ele_RetriveUserName_NonActivatedMailId_xpath);
            string assertMessage = ("We've sent an email to " + ReadExcel.Email + " with your username.");
           // Assert.IsTrue(notification.Equals(assertMessage));
            help.quitWebDriver();
        }
        //TC-30
        [TestMethod]
        public void retriveUsername_notexisted_mailinotification_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 3, true, "new");
            Scenario_Functions.needHelpToRetriveUsername_notification(TD_wrongmailid);
            string notification = help.getTextByXpath(Ele_RetriveUserName_nonActivatedMailId_xpath);
            string assertMessage = ("A profile with the entered email does not exist.Please try again");
           // Assert.IsTrue(notification.Equals(assertMessage));
            help.quitWebDriver();
        }
    }
}
