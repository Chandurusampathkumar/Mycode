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
namespace Theranos.Automation.ME.Web.WebTestScripts.ShoppingCart
{
    [TestClass]
    public class Emptyshoppingcart : WebActionLib
    {
        // TC- 055
        WebActionLib we = new WebActionLib();

        public void emptyshoppingcart()
        {

            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            String cartstatuslabel = Scenario_Functions.shoppingcartverification();

            String Actualcartstatus = "There are no items in your shopping cart. You can add tests and panels from the test menu.";
           /// Assert.Equals(cartstatuslabel, Actualcartstatus);

        }
        [TestMethod]
        public void emptyshoppingcart_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            emptyshoppingcart();
            we.quitWebDriver();
        }
    }
}
