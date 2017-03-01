using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;
using Theranos.Automation.ME.Web.WebTestScripts.TestMenu;
using Theranos.Automation.ME.Web.Web;
using Theranos.Automation.ME.Web.ExcelReader;
namespace Theranos.Automation.ME.Web.WebTestScripts.Arranged_Test_suits
{
    [TestClass]
   public class TestMenu_TestSuits_linked :WebActionLib
    {
        AccountLinking_Afteradding_Testtocart testcart = new AccountLinking_Afteradding_Testtocart();
        AccountLinking_Settings_TesteMenu_Addtocart_Resendcode resendcode = new AccountLinking_Settings_TesteMenu_Addtocart_Resendcode();
        Signup_OrderMenu_LinkAccount_InvalidVisitcode visitcode = new Signup_OrderMenu_LinkAccount_InvalidVisitcode();
        Signup_ResultMenu_LinkAccount resltmenu = new Signup_ResultMenu_LinkAccount();
        Signup_OrderMenu_LinkAccount_Clickhere clickhere = new Signup_OrderMenu_LinkAccount_Clickhere();
        //   TestMenu_Verify_ErrorStatement_ByWrongUser_credentials errorststement = new TestMenu_Verify_ErrorStatement_ByWrongUser_credentials();

        [TestMethod]
        public void testmenutestsuits_unlinked()
        {
           
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            ///  Scenario_Functions.signin_forLinkedaccount();
            resendcode.accountLinking_settings_testeMenu_addtocart_resendcode_Scenario(); //link

            clickhere.signupOrderMenuLinkAccountClickhere_scenario(); //link
            //   errorststement.verify_error_statement_using_wrongCredentals_Scenario();

        }
    }
}
