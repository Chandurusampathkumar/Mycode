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

namespace Theranos.Automation.ME.Web.WebTestScripts.LabOrders
{
    [TestClass]
    public class UploadLaborder : WebActionLib
    {
        // Testcase for Tc-014
        WebActionLib won = new WebActionLib();

        public void uploadLaborders(int count)
        {
            won.clickElementByXpath(Ele_DashBoard_Order_Xpath);
         //   String previouscount = won.getTextByXpath(Element_Ordernumbers_Count_Xpath);
         
            for (int i = 0; i <= count; i++)
            {
                Thread.Sleep(3000);

                won.sendTextByXpath(Ele_orders_UploadButton_xpath, TD_UploadFilepath);
            }

        }
        [TestMethod]
        public void uploadLaborders_scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            uploadLaborders(1);
            won.quitWebDriver();
        }

     }
}
