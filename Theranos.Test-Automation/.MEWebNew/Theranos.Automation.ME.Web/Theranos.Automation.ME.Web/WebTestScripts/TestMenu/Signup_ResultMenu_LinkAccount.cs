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
    public class Signup_ResultMenu_LinkAccount : WebActionLib
    {
        //Testcae for TestConfiguration-010
        WebActionLib unlink = new WebActionLib();

        public void signupResultMenuLinkAccount()
        {
            // Login with unlink account

           // Thread.Sleep(5000);
          //  Driver.Navigate().Refresh();
           /// unlink.WaitForElementByXpathTo_Clickable(ResultBtn_ByXpath, 30);

            unlink.clickElementByXpath(ResultBtn_ByXpath);
            Thread.Sleep(5000);
            // Click on order Menu and Enter visit code along with first name, lastname and date of birth then submit.
            Scenario_Functions.resendvisitcode();
            string psicode = Get_Code.getPSIcode(TD_yopmail_Page_Url, ReadExcel.Email);
            Scenario_Functions.entervisitcode(psicode);
        }
        [TestMethod]
        public void signupResultMenuLinkAccount_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "Old");
            Scenario_Functions.signin_forUnlinked();
            signupResultMenuLinkAccount();
            unlink.quitWebDriver();
        }
    }

}
