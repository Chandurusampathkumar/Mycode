using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;
using Theranos.Automation.ME.Web.WebTestScripts;
using Theranos.Automation.ME.Web.Web;
using Theranos.Automation.ME.Web.ExcelReader;

namespace Theranos.Automation.ME.Web.WebTestScripts.TestMenu
{
    [TestClass]
    public class AccountLinking_Afteradding_Testtocart : WebActionLib
    {
        //testcase TC-008
        WebActionLib unlink = new WebActionLib();
       
        public void account_linking_after_testtocart()
        {
            unlink.waitForElement("linktext", Ele_DashBoard_Test_linktext, 30);
            Scenario_Functions.addtesttocart_Bytestmenu_unlinked(TD_Testname1);
            Scenario_Functions.resendvisitcode();
            string psicode = Get_Code.getPSIcode(TD_yopmail_Page_Url, ReadExcel.Email);
            Scenario_Functions.entervisitcode(psicode);
        }

        [TestMethod]
        public void account_linking_after_testtocart_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "Old");
            Scenario_Functions.signin_forUnlinked();
            account_linking_after_testtocart();
            unlink.quitWebDriver();
        }

    }
}
