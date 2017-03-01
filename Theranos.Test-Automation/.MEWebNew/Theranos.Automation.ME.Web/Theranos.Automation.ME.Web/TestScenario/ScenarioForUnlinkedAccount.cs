using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;
using Theranos.Automation.ME.Web.WebTestScripts.SignUp;
using Theranos.Automation.ME.Web.WebTestScripts.SignIn;
using Theranos.Automation.ME.Web.WebTestScripts.TestMenu;
using Theranos.Automation.ME.Web.WebTestScripts.LabOrders;
using Theranos.Automation.ME.Web.WebTestScripts.Settings;
using Theranos.Automation.ME.Web.Web;

namespace Theranos.Automation.ME.Web.WebTestScripts.Arrangedtestcases
{
    [TestClass]
   public class ScenarioForUnlinkedAccount
    {
      
       WebActionLib link = new WebActionLib();
       WorkingActivationLink wal = new WorkingActivationLink();
       AccountLinking_Afteradding_Testtocart alin = new AccountLinking_Afteradding_Testtocart();
       SignUp.SignUp su = new SignUp.SignUp();
       DirectOrdering_TestmenuOrders_UnlinkedAccount orderunlink = new DirectOrdering_TestmenuOrders_UnlinkedAccount();
       Order_From_UnlinkedaAccount fromunlink = new Order_From_UnlinkedaAccount();
       ChangePassword cp = new ChangePassword();
      // Scenario_Functions sf = new Scenario_Functions();

       [TestMethod]
       public void scenarioforUnLinkedaccount()
       {
           su.signUp(); //TC-061

           ///note to add tc42 we nead to sign up and we need to activate the account by yop mail

           Thread.Sleep(2000);
           link.switchToOtherTab();
           link.closeCurrentTab();
           link.switchToOtherTab();
           link.switchToOtherTab();
           link.closeCurrentTab();
           Scenario_Functions.VerificationWithoutinitialize();
           cp.changepassword();
           alin.account_linking_after_testtocart();  //Tc-008
           Thread.Sleep(3000);
           link.clickElementByClassName("i-close");
          
          // orderunlink.directordering_testmenuorders_Scenario(); //TC-015
           ///fromunlink.orderFromUnlinkedAccount_Scenario(); //TC-42

       }
    }
}
