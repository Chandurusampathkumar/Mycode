using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;

using Theranos.Automation.ME.Web.WebTestScripts.NeedHelp;
using Theranos.Automation.ME.Web.WebTestScripts.ShoppingCart;
using Theranos.Automation.ME.Web.Web;
using Theranos.Automation.ME.Web.WebTestScripts.SignIn;

using Theranos.Automation.ME.Web.ExcelReader;
namespace Theranos.Automation.ME.Web.WebTestScripts.Arranged_Test_suits
{
    [TestClass]
    public class NeedHelp_TestSuits :WebActionLib
    {
        NeedToHelpPageDisplay nth = new NeedToHelpPageDisplay();
        RetrieveUsername_Page rup = new RetrieveUsername_Page();
        ForgetPassword fp = new ForgetPassword();
        ResendActivationLink Ra = new ResendActivationLink();
        ResetPassword rset = new ResetPassword();
        Retriveusername_Nonactivatedaccount nonact = new Retriveusername_Nonactivatedaccount();

        [TestMethod]
        public void needhelptestsuits()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");

            nth.needtohelppagedisplay_Scenario();
         
            rup.needHelpToRetriveUsername_Scenario();

            fp.forgetpassword_Scenario();
            Ra.resendactivaton_Activatedusername_Scenario();
            Ra.resendactivaton_NonActivatedusername_Scenario();
            Ra.resendactivaton_Invalidusername_Scenario();
            rset.resetpassword_validusername_Scenario();
            rset.resetpassword_invalidusername_Scenario();
            rset.resetpassword_nonactivatedusername_Scenario();

            nonact.retriveusername_nonactivatedmailaccount_Scenario();
            nonact.retriveusername_activatedmailaccount_Scenario();
            nonact.retriveUsername_notexisted_mailinotification_Scenario();
        }
    }
}
