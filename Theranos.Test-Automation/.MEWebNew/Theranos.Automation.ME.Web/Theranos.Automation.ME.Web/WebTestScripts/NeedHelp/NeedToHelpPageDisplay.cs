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
    public class NeedToHelpPageDisplay : WebActionLib
    {
        // TC for Tc-27
        WebActionLib help = new WebActionLib();
      
        public void needtohelppagedisplay()
        {

          ///  help.clickElementByXpath(Ele_NeedHelp_PageLable_xpath);
            string needhelp = help.getTextByXpath(Ele_NeedHelp_PageLable_xpath);

            string assertMessage = ("Need help?");
            Assert.IsTrue(needhelp.Equals(assertMessage));
        }

        [TestMethod]
        public void needtohelppagedisplay_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.needHelp_Loginpage();
            needtohelppagedisplay();
            help.quitWebDriver();
        
           }
    }
}
