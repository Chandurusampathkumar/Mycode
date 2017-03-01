using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;
using Theranos.Automation.ME.Web.WebTestScripts.ShoppingCart;
using Theranos.Automation.ME.Web.Web;
using Theranos.Automation.ME.Web.ExcelReader;

namespace Theranos.Automation.ME.Web.WebTestScripts.Arranged_Test_suits
{
    [TestClass]
    public class Shoppingcart_TestSuits:WebActionLib
    {
        Emptyshoppingcart esc = new Emptyshoppingcart();
        AddRemove_From_TestCartPage arfc = new AddRemove_From_TestCartPage();
        AddingTest_ToCart_TotalTest attc = new AddingTest_ToCart_TotalTest();

       [TestMethod]
        public void shoppingcarttestsuit()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");

            esc.emptyshoppingcart_Scenario();

            attc.countingCartTest_scenario();

            arfc.AddandRemovetest_Scenario();
        }
    }
}
