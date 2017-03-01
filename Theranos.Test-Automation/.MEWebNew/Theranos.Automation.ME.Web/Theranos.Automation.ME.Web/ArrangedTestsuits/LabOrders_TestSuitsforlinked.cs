using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Theranos.Automation.ME.Web;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using Theranos.Automation.ME.Web.Utility;
using Theranos.Automation.ME.Web.WebTestScripts.LabOrders;

using Theranos.Automation.ME.Web.Web;
using Theranos.Automation.ME.Web.ExcelReader;
namespace Theranos.Automation.ME.Web.WebTestScripts.Arranged_Test_suits
{
    [TestClass]
   public class LabOrders_TestSuitsforlinked:WebActionLib
    {
       DirectOrdering_Testmenu_MultipleOrders_LinkedAccount directorder = new DirectOrdering_Testmenu_MultipleOrders_LinkedAccount();
       UploadLaborder uploadlaborder = new UploadLaborder();
       MultipleOrders_ByUploadingOrders uploadorder = new MultipleOrders_ByUploadingOrders();


        [TestMethod]
       public void labordertestsuits_linked()
       {
           ReadExcel.Excelindexvalue(TD_Testdata_Filepath, 1, false, "OldLInked");
          
           directorder.directOrderingTestmenuMultpleOrdersLinkedAccount_Scenario();
           uploadorder.multipleOrdersbyUploadingorders_Scenario();
           uploadlaborder.uploadLaborders_scenario();
          
       }
    }
}
