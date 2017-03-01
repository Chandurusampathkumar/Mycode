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
using OpenQA.Selenium.Interactions;
using Theranos.Automation.ME.Web.ExcelReader;
using Theranos.Automation.ME.Web.WebTestScripts.FileReader;
using Theranos.Automation.ME.Web.WebTestScripts.TestMenu;
namespace Theranos.Automation.ME.Web.WebTestScripts.SignUp
{
    [TestClass]
   public class Provisionalaccount_PSC :WebActionLib
    {
       WorkingActivationLink signup = new WorkingActivationLink();
       WebActionLib psc = new WebActionLib();
       Get_Code cd = new Get_Code();
       Order_From_UnlinkedaAccount provs = new Order_From_UnlinkedaAccount();

        [TestMethod]
       public void provisionalaccountpsclinking()
       {
           ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, true, "new");
           signup.activationLink();

           cd.YopMailsendemailcaptcha(TD_yopmail_Page_Url, ReadExcel.Email);
           Thread.Sleep(1000);
           signup.switchToOtherTab();
           signup.switchToOtherTab();
           signup.closeCurrentTab();
           signup.closeCurrentTab();

           Scenario_Functions.VerificationWithoutinitialize();
           provs.orderFromUnlinkedAccount();

       //    psc.quitWebDriver();

       }
    }
}
