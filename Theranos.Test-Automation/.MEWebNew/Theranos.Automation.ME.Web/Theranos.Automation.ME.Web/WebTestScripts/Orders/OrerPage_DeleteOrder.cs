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

namespace Theranos.Automation.ME.Web.WebTestScripts.Orders
{
    [TestClass]
    public class OrerPage_DeleteOrder : WebActionLib
    {
        // TC- 048
        WebActionLib del = new WebActionLib();

        public void deleteorderfromorderpage()
        {
            del.clickElementByXpath(Ele_DashBoard_Order_Xpath);
            Thread.Sleep(2000);
            del.clickElementByXpath(Ele_Orderpage_ReadyOrderTesting_Xpath);
            del.clickElementByClassName(Ele_Orderpage_readyorder_options_classname);
            del.waitForElement("xpath", Ele_Orderpage_ReadyOrderOPtion_Delete_Xpath, 50);
            del.clickElementByXpath(Ele_Orderpage_ReadyOrderOPtion_Delete_Xpath);
        }
        
        [TestMethod]
        public void deleteorderfromorderpage_scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            deleteorderfromorderpage();
            del.quitWebDriver();
        }
    }
}
