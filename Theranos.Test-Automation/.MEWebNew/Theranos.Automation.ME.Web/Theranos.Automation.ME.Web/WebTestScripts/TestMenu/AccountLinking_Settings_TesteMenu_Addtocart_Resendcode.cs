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
    public class AccountLinking_Settings_TesteMenu_Addtocart_Resendcode : WebActionLib
    {
        //testcase TC-009
        // signin with unlinked account.
        WebActionLib unlink = new WebActionLib();

        public void accountLinking_settings_testeMenu_addtocart_resendcode()
        {
            unlink.waitForElement("linktext", Ele_DashBoard_Test_linktext, 30);
            Scenario_Functions.addtesttocart_Bytestmenu_unlinked(TD_Testname1);
            Scenario_Functions.resendvisitcode();
            string psicode = Get_Code.getPSIcode(TD_yopmail_Page_Url, ReadExcel.Email);
            Scenario_Functions.entervisitcode(psicode);


        }
        [TestMethod]
        public void accountLinking_settings_testeMenu_addtocart_resendcode_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "Old");
            Scenario_Functions.signin_forLinkedaccount();
          
            accountLinking_settings_testeMenu_addtocart_resendcode();
            unlink.quitWebDriver();
        }
    }
}
