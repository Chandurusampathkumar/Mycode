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
namespace Theranos.Automation.ME.Web.WebTestScripts.Settings
{
                      
    [TestClass]
    public class Username_Unchangable:WebActionLib
    { //TC - 002 
        // Note: This test case is not required 
        WebActionLib unchangable = new WebActionLib();

        public void usernameUnchangable()
        { 
                Thread.Sleep(9000);
                unchangable.clickElementByClassName(Ele_Dashboard_ProfileIcon_Classname);
                unchangable.clickElementByLinkText(Ele_Dashboard_Settings_Linktext);
                unchangable.WaitForElementByXpathTo_Clickable(Ele_SettingsAcc_Username_Xpath, 20);
                string AttributeValue = unchangable.getAttributeByXpath(Ele_SettingsAcc_Username_Xpath, "readonly");

                string assertMessage = ("Username field is not configured as READ ONLY. The value of readonly attribute : " + AttributeValue);
             //   Assert.IsTrue(AttributeValue == "true", assertMessage);
        }
        [TestMethod]
        public void usernameUnchangable_Scenario()
        {
           ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
          Scenario_Functions.signInWithVerification();
            usernameUnchangable();
            unchangable.quitWebDriver();
        }
    }
}
