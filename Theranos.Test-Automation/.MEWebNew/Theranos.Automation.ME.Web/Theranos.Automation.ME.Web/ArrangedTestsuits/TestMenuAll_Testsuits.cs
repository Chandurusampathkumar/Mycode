using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;
using Theranos.Automation.ME.Web.WebTestScripts.TestMenuAll;
using Theranos.Automation.ME.Web.Web;
using Theranos.Automation.ME.Web.ExcelReader;

namespace Theranos.Automation.ME.Web.WebTestScripts.Arranged_Test_suits
{
     [TestClass]
  public class TestMenuAll_Testsuits:WebActionLib
    {
         SearchSingleTest_DisplayTest displytest = new SearchSingleTest_DisplayTest();
         TestMenu_Scroll_AllTestTypes alltesttypes = new TestMenu_Scroll_AllTestTypes();
          
         ///[TestMethod]
         public void testmenuall_testsuits()
         {
             ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
             //displytest.searchandisplayTest_Scenario();
             alltesttypes.scrolltestetype_Scenario();
         }
   
    }
}
