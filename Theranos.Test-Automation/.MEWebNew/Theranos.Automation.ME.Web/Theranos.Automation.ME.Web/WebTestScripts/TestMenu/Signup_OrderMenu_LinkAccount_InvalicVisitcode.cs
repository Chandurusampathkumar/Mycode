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
namespace Theranos.Automation.ME.Web.WebTestScripts.TestMenu
{
    [TestClass]
    public class Signup_OrderMenu_LinkAccount_InvalidVisitcode : WebActionLib
    {
        //TC-012
        WebActionLib unlink = new WebActionLib();

        public void signupOrderMenuLinkAccountinvalidvisitcode()
        {
            Thread.Sleep(5000);
            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(60));
            unlink.clickElementByXpath(Ele_DashBoard_Order_Xpath);
         
            /*
             * Here  entering the invalid visit code as numerics from excelsheet.
             */
            Scenario_Functions.entervisitcode(ReadExcel.numerics);
            String errormsg = unlink.getTextByXpath(Element_SignIn_unlinkAccount_Errormessage_Xpath);
            Console.WriteLine("Expected ==" + errormsg);
            Thread.Sleep(3000);
        }
        [TestMethod]
        public void signupOrderMenuLinkAccountinvalidvisitcode_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 2, false, "Old");
            Scenario_Functions.signin_forUnlinked();
            signupOrderMenuLinkAccountinvalidvisitcode();
            unlink.quitWebDriver();
        }
    }
}
