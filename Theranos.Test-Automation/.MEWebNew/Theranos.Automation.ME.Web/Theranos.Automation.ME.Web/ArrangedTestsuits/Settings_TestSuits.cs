using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;
using Theranos.Automation.ME.Web.WebTestScripts.Settings;
using Theranos.Automation.ME.Web.Web;
using Theranos.Automation.ME.Web.ExcelReader;

namespace Theranos.Automation.ME.Web.WebTestScripts.Arranged_Test_suits
{
 [TestClass]   
    public class Settings_TestSuits:WebActionLib
    {
     //   Username_Display und = new Username_Display();
        Username_Unchangable unu = new Username_Unchangable();

     [TestMethod]
        public void settingtestsuits()
        {
            ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");

         //   und.usernameDisplay_Scenario();

            unu.usernameUnchangable_Scenario();
        }
    }
}
