using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;
//using Theranos.Automation.ME.Web.WebTestScripts.Arraangedtestcases;
using Theranos.Automation.ME.Web.WebTestScripts.SignUp;
using Theranos.Automation.ME.Web.WebTestScripts.SignIn;
using Theranos.Automation.ME.Web.WebTestScripts.TestMenu;
using Theranos.Automation.ME.Web.Web;
using Theranos.Automation.ME.Web.WebTestScripts.ShoppingCart;
using Theranos.Automation.ME.Web.WebTestScripts.NeedHelp;
using Theranos.Automation.ME.Web.WebTestScripts.TestMenuAll;
using Theranos.Automation.ME.Web.WebTestScripts.LabOrders;

namespace Theranos.Automation.ME.Web.WebTestScripts.Arrangedtestcases
{
    [TestClass]
    public class ScenarioforLInkedAccount : WebActionLib
    {
       WebActionLib link = new WebActionLib();
       UploadLaborder mltpl = new UploadLaborder();
       AddingTest_ToCart_TotalTest alin = new AddingTest_ToCart_TotalTest();
       AddRemove_From_TestCartPage adrm = new AddRemove_From_TestCartPage();
       DirectOrdering_Testmenu_MultipleOrders_LinkedAccount domol = new DirectOrdering_Testmenu_MultipleOrders_LinkedAccount();
       SearchSingleTest_DisplayTest sstd = new SearchSingleTest_DisplayTest();
        
        [TestMethod]
        public void scenarioforLinkedaccount()
       {
           Scenario_Functions.signInWithVerification();
           Thread.Sleep(3000);
       ///    alin.countingCartTest();  //TC-56 ////
           adrm.AddandRemovetest();  //TC-60
           mltpl.uploadLaborders(1); //TC-20
           Thread.Sleep(8000);
            ///need internet speed after uploading the orders    ///
           domol.directOrderingTestmenuMultpleOrdersLinkedAccount();    //Tc-18
      ///    sstd.searchandisplayTest(); //TC,- 65, 66, 68, 69     ////
           link.quitWebDriver();
       }
    }
}