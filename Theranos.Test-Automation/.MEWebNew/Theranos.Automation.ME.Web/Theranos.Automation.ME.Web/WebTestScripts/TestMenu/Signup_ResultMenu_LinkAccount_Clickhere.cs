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

namespace Theranos.Automation.ME.Web.WebTestScripts.TestMenu
{
    [TestClass]
    public class Signup_OrderMenu_LinkAccount_Clickhere : WebActionLib
    {
        //Testcae for TestConfiguration-011
        WebActionLib unlink = new WebActionLib();
      
        public void signupOrderMenuLinkAccountClickhere()
        {
            unlink.clickElementByLinkText(Ele_Dashboard_Entervisitcode_linktext);
                Scenario_Functions.resendvisitcode();
           
        }
        [TestMethod]
        public void signupOrderMenuLinkAccountClickhere_scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 2, false, "Old");
            Scenario_Functions.signin_forLinkedaccount();
            signupOrderMenuLinkAccountClickhere();
            unlink.quitWebDriver();
        }
    }
}
