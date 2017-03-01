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


namespace Theranos.Automation.ME.Web.WebTestScripts.NeedHelp
{
    [TestClass]
    public class RetrieveUsername_Page : WebActionLib
    {  
        //TC- 028
        WebActionLib help = new WebActionLib();

        public void needHelpToRetriveUsername()
        {
            help.clickElementByXpath(Ele_NeedHelp_RetriveUsername_xpath);
            string url = help.getCurrentPageUrl();
            string assertMessage = ("The loaded page url is : "+url+" which is not expected ");
            Assert.IsTrue(url == TD_URL_NeedHelp_RetriverUsername, assertMessage);
        }
        [TestMethod]
        public void needHelpToRetriveUsername_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.needHelp_Loginpage();
            needHelpToRetriveUsername();
            help.quitWebDriver();
        }

        /// <summary>
        /// TC-40
        /// </summary>
        [TestMethod]
        public void needHelpToRetriveUsername_multiplemailid()
        {
            Scenario_Functions.needHelpToRetriveUsername_notification(TD_commonmailID_twouser);
            string notification = help.getTextByXpath(Ele_RetriveUserName_nonActivatedMailId_xpath);
            string assertMessage = ("Multiple accounts are linked to the same email. For security reasons, please contact us at support@theranos.com.");
            Assert.IsTrue(notification.Equals(assertMessage));
            help.quitWebDriver();
        }
    }
}
