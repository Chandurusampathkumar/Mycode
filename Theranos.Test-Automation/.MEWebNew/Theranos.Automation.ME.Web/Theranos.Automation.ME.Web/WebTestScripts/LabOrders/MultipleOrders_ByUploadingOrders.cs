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
using Theranos.Automation.ME.Web.WebTestScripts.LabOrders;
using Theranos.Automation.ME.Web.ExcelReader;


namespace Theranos.Automation.ME.Web.WebTestScripts.LabOrders
{
    [TestClass]
    public class MultipleOrders_ByUploadingOrders : WebActionLib
    { 
        // tc for Tc-20

        WebActionLib link = new WebActionLib();
        UploadLaborder lbo = new UploadLaborder();
        public void multipleOrdersbyUploadingorders()
        {    
              // this is for repeting the same steps for three times
                 lbo.uploadLaborders(3);
        }

        [TestMethod]
        public void multipleOrdersbyUploadingorders_Scenario()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
            Scenario_Functions.signInWithVerification();
            multipleOrdersbyUploadingorders();
            link.quitWebDriver();
        }
    }
}
